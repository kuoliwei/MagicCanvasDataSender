using UnityEngine;

public class RollerSimulator : MonoBehaviour
{
    public WebSocketServerManager manager;
    public Camera targetCamera; // ��J�D��v���]�Y�� UI �i�]�� null�^

    [Header("�ǰe����")]
    [Tooltip("�C��̦h�ǰe�X�����")]
    public int sendRatePerSecond = 30; // �i�q Inspector �]�w

    private float sendInterval;    // 1 / sendRatePerSecond
    private float sendTimer = 0f;

    private int messagesSentThisSecond = 0;
    private float secondTimer = 0f;

    void Start()
    {
        sendInterval = 1f / sendRatePerSecond;
    }

    void Update()
    {
        //// �Y Inspector �ʺA�ק� sendRate�A��s interval
        //sendInterval = 1f / Mathf.Max(1, sendRatePerSecond);

        //if (Input.GetMouseButton(0)) // ������ �euv�y��
        //{
        //    //sendTimer += Time.deltaTime;
        //    //while (sendTimer >= sendInterval)
        //    //{
        //    //    sendTimer -= sendInterval;

        //    //    Vector2 screenPos = Input.mousePosition;

        //    //    float x = Mathf.Clamp01(screenPos.x / Screen.width);
        //    //    float y = 1f - Mathf.Clamp01(screenPos.y / Screen.height); // ½�� Y �b

        //    //    manager.BroadcastTestMessage(x, y);
        //    //    messagesSentThisSecond++;
        //    //}

        //    Vector2 screenPos = Input.mousePosition;

        //    float x = Mathf.Clamp01(screenPos.x / Screen.width);
        //    float y = 1f - Mathf.Clamp01(screenPos.y / Screen.height); // ½�� Y �b

        //    manager.BroadcastTestMessage(x, y);
        //    messagesSentThisSecond++;

        //}
        //else
        //{
        //    sendTimer = 0f; // ��}�ƹ��N�k�s
        //}

        //// �C���X�@���ǰe����
        //secondTimer += Time.deltaTime;
        //if (secondTimer >= 1f)
        //{
        //    Debug.Log($"[Server] �C��e�X���ơG{messagesSentThisSecond}");
        //    messagesSentThisSecond = 0;
        //    secondTimer = 0f;
        //}
        if (Input.GetKeyDown(KeyCode.P)) // �e���A���
        {
            manager.SendPoseOnce();
        }
    }
}
