using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iCAPS11
{
    public class WebSocketManager
    {
        public delegate void MessageReceivedHandler(object sender, MessageEventArgs e);

        public class MessageEventArgs : EventArgs
        {
            public WebSocket SendClient { get; private set; }
            public string Message { get; private set; }

            public MessageEventArgs(WebSocket client, string message)
            {
                SendClient = client;
                Message = message;
            }
        }

        public class Server
        {
            private HttpListener httpListener;
            private List<WebSocket> clients = new List<WebSocket>();
            public event MessageReceivedHandler MessageReceived;
            public bool Connected { get; private set; } = false;

            public Server(int port)
            {
                httpListener = new HttpListener();
                httpListener.Prefixes.Add($"http://*:{port}/");
            }

            public async void Start()
            {
                httpListener.Start();
                Connected = true;
                Console.WriteLine("WebSocket 伺服器已啟動");

                while (true)
                {
                    HttpListenerContext context = await httpListener.GetContextAsync();
                    if (context.Request.IsWebSocketRequest)
                    {
                        ProcessWebSocketClient(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
            }

            private async void ProcessWebSocketClient(HttpListenerContext context)
            {
                WebSocketContext wsContext = await context.AcceptWebSocketAsync(null);
                WebSocket webSocket = wsContext.WebSocket;
                clients.Add(webSocket);
                Console.WriteLine("新的 WebSocket 客戶端已連接");

                byte[] buffer = new byte[1024];
                while (webSocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine("收到客戶端訊息: " + message);

                    MessageReceived?.Invoke(this, new MessageEventArgs(webSocket, message));
                }
            }

            public async void SendToAllClients(string message)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                foreach (var client in clients)
                {
                    if (client.State == WebSocketState.Open)
                    {
                        await client.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
            }
        }

        public class Client
        {
            private ClientWebSocket clientWebSocket = new ClientWebSocket();
            public event MessageReceivedHandler MessageReceived;
            public bool Connected { get; private set; } = false;

            public async void Connect(string serverUri)
            {
                await clientWebSocket.ConnectAsync(new Uri(serverUri), CancellationToken.None);
                Connected = true;
                Console.WriteLine("已連接至 WebSocket 伺服器");
                ReceiveMessages();
            }

            private async void ReceiveMessages()
            {
                byte[] buffer = new byte[1024];
                while (clientWebSocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine("收到伺服器訊息: " + message);
                    MessageReceived?.Invoke(this, new MessageEventArgs(clientWebSocket, message));
                }
            }

            public async void Send(string message)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }

            public async void Close()
            {
                await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                Connected = false;
            }
        }
    }
}
