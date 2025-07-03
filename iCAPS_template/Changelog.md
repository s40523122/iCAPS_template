# Changelog

### V2.0.0
- 更新專案版本至 .NET Framework 4.8.0
- 製作 .dll 檔，方便日後更新
- 自動搜尋 Forms 資料夾內文件，並建立成 menu
- 按鈕圖示對應表單icon(可黑轉白)，文字對應表單文字

### V2.0.1
- 新增 ScalePadding 工具
- 新增 ScaleButton 工具

### V2.0.2
- 修改 HttpRequest 套件(無法向下兼容)
	- 返回資料從 string 更改為 int
	- 新增 ResponseMessage 作為回應字串來源
### V2.1.0
- 新增彈出式右側框設計

### V2.1.1
- 修改 DoubleImg 切換不正確問題
- MsgBox 增加非同步自動關閉的 ShowFlash 功能
- HttpRequest 增加自訂 Timeout 秒數機制

### V2.1.2
- 新增 SocketManager 工具

### V2.1.3
- 新增 WebSocket 工具
- 修護菜單顯示異常問題

### V2.2.0
- 修改自動添加分頁機制，公開版不再依賴 Forms
- 1. 若繼承後未指定 Forms 路徑，自動開啟視窗設定
- 2. 編譯時自動寫入分頁類別名稱，公開版可直接使用

### V2.2.1
- 修正 MsgBox.Show() 關閉時，會使母視窗最小化問題

### V2.3.0
- 增加泡泡視窗，允許使用者設定當視窗最小化時，以泡泡視窗呈現

### V2.3.1
- 新增當前時間顯示

### V2.3.2
- 更新 CefSharp 套件至 137.0.100 版本，解決風險問題

### V2.3.3
- INI寫入函數增加自動建立資料夾，現在無論資料夾或檔案是否存在都會自動建立並寫入