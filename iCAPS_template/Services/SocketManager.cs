// 2025/03/14

using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace iCAPS
{
    class Sample
    {
        #region Server Sample
        SocketManager.Server server = new SocketManager.Server(5000);     // 連線，開放所有 Client 端連線，需加入指定 port

        private async void server_main()
        {
            server.Start();

            // 等待伺服器啟動並開始監聽
            await server.WaitForServerToStartAsync();
            if (server.Connected) Console.WriteLine("已開啟伺服器!");

            // 不論如何，送送訊息給已連接的 client (可選)
            server.SendToAllClient("Hi");

            // 訂閱訊息接收事件，接收訊息為 e.Message
            server.MessageReceived += ServerMessageReceived;

        }
        private void ServerMessageReceived(object sender, SocketManager.MessageEventArgs e)
        {
            //richTextBox1.Invoke((MethodInvoker)delegate
            //{
            //    richTextBox1.Text = "收到客戶端消息：" + e.Message;
            //});

            string response = "Received message: " + e.Message;
            server.SendToClient(e.SendClient, response); // 發送回應
        }
        #endregion

        #region Client Sample
        SocketManager.Client client = new SocketManager.Client("192.168.32.164", 5000);
        private async void client_main()
        {
            // 連線至指定 Server
            client.Connect();

            // 可用 client.Connected 檢查是否連線，初次檢查需等待連線1秒  (可選)
            await Task.Delay(1000);
            if (client.Connected) Console.WriteLine("已連線至伺服器!");

            // 傳送訊息至 Server 端
            client.Send("tell server i need");

            // 訂閱訊息接收事件，接收訊息為 e.Message
            client.MessageReceived += ClientMessageReceived; ;
        }

        private void ClientMessageReceived(object sender, SocketManager.MessageEventArgs e)
        {
            //richTextBox1.Invoke((MethodInvoker)delegate
            //{
            //    richTextBox1.Text = "收到客戶端消息：" + e.Message;
            //});

            string response = "Received message: " + e.Message;
        }
        #endregion
    }
    public class SocketManager
    {
        // 定義訊息接收事件與委派
        public delegate void MessageReceivedHandler(object sender, MessageEventArgs e);

        public class MessageEventArgs : EventArgs
        {
            public Socket SendClient { get; private set; }
            public string Message { get; private set; }

            public MessageEventArgs(string _message)
            {
                SendClient = null;
                Message = _message;
            }

            public MessageEventArgs(Socket _client, string _message)
            {
                SendClient = _client;
                Message = _message;
            }
        }

        public class Server
        {
            private Socket serverSocket;   // 用於監聽和接受連接的伺服器 Socket
            private System.Collections.Generic.List<Socket> connect_clients = new System.Collections.Generic.List<Socket>() { };
            private System.Collections.Generic.List<Socket> blacklist = new System.Collections.Generic.List<Socket>() { };
            private TaskCompletionSource<bool> startCompletionSource = new TaskCompletionSource<bool>(); // 用來通知外部程式伺服器啟動完成

            public event MessageReceivedHandler MessageReceived;    // 定義一個事件，使用 MessageReceivedHandler 委派
            
            public System.Collections.Generic.List<Socket> Blacklist { get => blacklist; }

            /// <summary>
            /// Socket 接收資料
            /// </summary>
            public string Log { get; private set; }

            /// <summary>
            /// Server 狀態
            /// </summary>
            public bool Connected { get; private set; } = false;

            // 監聽端點
            private IPEndPoint endPoint;

            public Server(int port)
            {
                // 設定監聽端點，監聽所有IP上的 port 端口
                endPoint = new IPEndPoint(IPAddress.Any, port);
            }

            /// <summary>
            /// 啟動伺服器
            /// </summary>
            public void Start()
            {
                // 在背景執行緒中啟動伺服器
                StartServer();
            }

            /// <summary>
            /// 啟動伺服器的主要邏輯
            /// </summary>
            private void StartServer()
            {
                try
                {
                    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    serverSocket.Bind(endPoint);
                    serverSocket.Listen(10); // 設置最大佇列長度為10
                    Connected = true;

                    // 當伺服器啟動並開始監聽時，設定 TaskCompletionSource 為成功
                    startCompletionSource.SetResult(true);
                    Task.Run(() =>
                    {
                        while (true)
                        {
                            // 等待客戶端連接
                            Socket _clientSocket = serverSocket.Accept();
                            connect_clients.Add(_clientSocket);
                            // 為每個客戶端連接啟動新的背景任務
                            HandleClient(_clientSocket);
                        }
                    });
                }
                catch (Exception ex)
                {
                    // 顯示啟動伺服器時的錯誤訊息
                    Log = "伺服器啟動失敗：" + ex.Message;
                    Console.WriteLine(Log);
                }
            }

            /// <summary>
            /// 這個方法用來等待伺服器啟動並開始監聽
            /// </summary>
            /// <returns></returns>
            public Task WaitForServerToStartAsync()
            {
                return startCompletionSource.Task; // 回傳 Task，讓外部程式可以 await 這個 Task，直到伺服器啟動完成
            }

            /// <summary>
            /// 處理與客戶端的通訊
            /// </summary>
            /// <param name="client"></param>
            private void HandleClient(Socket client)
            {
                try
                {
                    // 設置接收和發送超時為10秒
                    client.ReceiveTimeout = 5000; // 接收超時
                    client.SendTimeout = 5000; // 發送超時

                    Console.WriteLine($"有新客戶端連線：{client.RemoteEndPoint}");

                    while (client.Connected)
                    {
                        try
                        {
                            byte[] buffer = new byte[1024];
                            int received = client.Receive(buffer); // 接收來自客戶端的數據
                            if (received == 0) return; // 客戶端斷開連接

                            string message = Encoding.ASCII.GetString(buffer, 0, received);

                            // 在 UI 執行緒中顯示收到的消息
                            Log = "收到客戶端消息：" + message;
                            Console.WriteLine(Log);

                            // 當接收到新消息時，觸發事件
                            MessageReceived?.Invoke(this, new MessageEventArgs(client, message));
                        }
                        catch (SocketException ex)
                        {
                            if (ex.SocketErrorCode == SocketError.TimedOut)
                            {
                                continue;       // 接收超時，不退出循環，繼續等待消息
                            }
                            else
                            {
                                throw;      // 其他 Socket 錯誤，退出循環
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 顯示處理客戶端時的錯誤訊息(斷線)
                    Log = "處理客戶端時出錯：" + ex.Message;
                    Console.WriteLine(Log);

                    connect_clients.Remove(client);
                    client.Close(); // 關閉客戶端連接
                }
            }

            /// <summary>
            /// 將指定客戶端加入黑名單，廣播時便不會接收內容
            /// </summary>
            /// <param name="client"></param>
            public void AddToBlacklist(Socket client)
            {
                blacklist.Add(client);
            }

            /// <summary>
            /// 廣播至所有連線客戶端
            /// </summary>
            public void SendToAllClient(string message)
            {
                try
                {
                    if (connect_clients.Count > 0 )
                    {
                        foreach(Socket _client in connect_clients)
                        {
                            if(!_client.Connected) continue;
                            if (blacklist.Contains(_client)) continue;      // 跳過黑名單

                            // 發送消息到客戶端
                            byte[] data = Encoding.ASCII.GetBytes(message);
                            _client.Send(data);
                        }
                    }
                    else
                    {
                        Log = "沒有連接的客戶端。";
                        Console.WriteLine(Log);
                    }
                }
                catch (Exception ex)
                {
                    // 顯示發送消息時的錯誤訊息
                    Log = "發送消息到客戶端失敗：" + ex.Message;
                    Console.WriteLine(Log);
                }
            }

            /// <summary>
            /// 發送消息至指定客戶端
            /// </summary>
            public void SendToClient(Socket _client, string message)
            {
                try
                {
                    // 發送消息到客戶端
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    _client.Send(data);
                }
                catch (Exception ex)
                {
                    // 顯示發送消息時的錯誤訊息
                    Log = "發送消息到客戶端失敗：" + ex.Message;
                    Console.WriteLine(Log);
                }
            }

            /// <summary>
            /// 關閉 Server 端連線
            /// </summary>
            public void Close()
            {
                serverSocket.Close();
                Connected = false;
            }
        }

        public class Client
        {
            private Socket ClientSocket; // 用於與伺服器通訊的 Socket

            // 定義一個事件，使用 MessageReceivedHandler 委派
            public event MessageReceivedHandler MessageReceived;

            /// <summary>
            /// Client 狀態
            /// </summary>
            public bool Connected { get; private set; } = false;

            /// <summary>
            /// Socket 接收資料
            /// </summary>
            public string Log { get; private set; }

            // 伺服器端點
            private IPEndPoint endPoint;

            public Client(string Server_ip, int port)
            {
                // 設定伺服器端點，連接到指定ip的port
                endPoint = new IPEndPoint(IPAddress.Parse(Server_ip), port);
            }

            /// <summary>
            /// 連接伺服器
            /// </summary>
            public void Connect()
            {
                // 在背景執行緒中連接到伺服器
                Task.Run(() => ConnectToServer());
            }

            /// <summary>
            /// 連接到伺服器的主要邏輯
            /// </summary>
            private void ConnectToServer()
            {
                try
                {
                    ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ClientSocket.Connect(endPoint);

                    // 設置接收和發送超時為5秒
                    ClientSocket.ReceiveTimeout = 5000; // 接收超時
                    ClientSocket.SendTimeout = 5000; // 發送超時

                    // 顯示連接成功消息
                    Log = "已連接到伺服器！";
                    Console.WriteLine(Log);

                    Connected = true;

                    // 啟動背景任務以接收消息
                    Task.Run(() => ReceiveMessages());
                }
                catch (Exception ex)
                {
                    // 顯示連接伺服器時的錯誤訊息
                    Log = "連接伺服器失敗：" + ex.Message;
                    Console.WriteLine(Log);
                }
            }

            /// <summary>
            /// 接收來自伺服器的消息
            /// </summary>
            private void ReceiveMessages()
            {
                try
                {
                    while (Connected)
                    {
                        try
                        {
                            byte[] buffer = new byte[1024];
                            int received = ClientSocket.Receive(buffer); // 接收伺服器發來的數據
                            if (received == 0) return; // 伺服器斷開連接

                            string text = Encoding.ASCII.GetString(buffer, 0, received);
                            // 在 UI 執行緒中顯示收到的消息
                            Log = "收到伺服器消息：" + text;
                            Console.WriteLine(Log);

                            // 觸發事件
                            OnMessageReceived(text);
                        }
                        catch (SocketException ex)
                        {
                            if (ex.SocketErrorCode == SocketError.TimedOut)
                            {
                                // 接收超時，不退出循環，繼續等待消息
                                continue;
                            }
                            else
                            {
                                // 其他 Socket 錯誤，退出循環
                                throw;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 顯示接收消息時的錯誤訊息
                    Log = "接收伺服器消息時出錯：" + ex.Message;
                    Console.WriteLine(Log);

                    ClientSocket.Close(); // 關閉連接
                }
            }

            /// <summary>
            /// 發送消息至 Server 端
            /// </summary>
            public void Send(string message)
            {
                try
                {
                    if (ClientSocket != null && ClientSocket.Connected)
                    {
                        // 發送消息到伺服器
                        byte[] data = Encoding.ASCII.GetBytes(message);
                        ClientSocket.Send(data);
                    }
                    else
                    {
                        Log = "未連接到伺服器。";
                        Console.WriteLine(Log);
                    }
                }
                catch (Exception ex)
                {
                    // 顯示發送消息時的錯誤訊息
                    Log = "發送消息到伺服器失敗：" + ex.Message;
                    Console.WriteLine(Log);
                }
            }

            /// <summary>
            /// 關閉 Client 端連線
            /// </summary>
            public void Close()
            {
                ClientSocket.Close();
                Connected = false;
            }

            // 當接收到新消息時，觸發事件
            protected virtual void OnMessageReceived(string message)
            {
                MessageReceived?.Invoke(this, new MessageEventArgs(message));
            }
        }
    }
}
