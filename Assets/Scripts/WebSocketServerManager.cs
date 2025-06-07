using UnityEngine;

public class WebSocketServerManager : MonoBehaviour
{
    public WebSocketServer.WebSocketServer server; // 拖入場景中的 WebSocketServer 物件

    public void BroadcastTestMessage(float x, float y)
    {
        string json = $"{{\"data\":[{{\"roller_id\":1,\"point\":[{x},{y}]}}]}}";

        // 使用 WebSocketServer.cs 中已寫好的方法
        server.SendMessageToClient(json);

        //Debug.Log("Sent: " + json);
    }
}
