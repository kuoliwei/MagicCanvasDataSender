using UnityEngine;

public class WebSocketServerManager : MonoBehaviour
{
    public WebSocketServer.WebSocketServer server; // ��J�������� WebSocketServer ����

    public void BroadcastTestMessage(float x, float y)
    {
        string json = $"{{\"data\":[{{\"roller_id\":1,\"point\":[{x},{y}]}}]}}";

        // �ϥ� WebSocketServer.cs ���w�g�n����k
        server.SendMessageToClient(json);

        //Debug.Log("Sent: " + json);
    }
}
