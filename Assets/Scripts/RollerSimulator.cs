using UnityEngine;

public class RollerSimulator : MonoBehaviour
{
    public WebSocketServerManager manager;
    public Camera targetCamera; // 拖入主攝影機（若為 UI 可設為 null）

    [Header("傳送控制")]
    [Tooltip("每秒最多傳送幾筆資料")]
    public int sendRatePerSecond = 30; // 可從 Inspector 設定

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
        //// 若 Inspector 動態修改 sendRate，更新 interval
        //sendInterval = 1f / Mathf.Max(1, sendRatePerSecond);

        //if (Input.GetMouseButton(0)) // 按住左鍵 送uv座標
        //{
        //    //sendTimer += Time.deltaTime;
        //    //while (sendTimer >= sendInterval)
        //    //{
        //    //    sendTimer -= sendInterval;

        //    //    Vector2 screenPos = Input.mousePosition;

        //    //    float x = Mathf.Clamp01(screenPos.x / Screen.width);
        //    //    float y = 1f - Mathf.Clamp01(screenPos.y / Screen.height); // 翻轉 Y 軸

        //    //    manager.BroadcastTestMessage(x, y);
        //    //    messagesSentThisSecond++;
        //    //}

        //    Vector2 screenPos = Input.mousePosition;

        //    float x = Mathf.Clamp01(screenPos.x / Screen.width);
        //    float y = 1f - Mathf.Clamp01(screenPos.y / Screen.height); // 翻轉 Y 軸

        //    manager.BroadcastTestMessage(x, y);
        //    messagesSentThisSecond++;

        //}
        //else
        //{
        //    sendTimer = 0f; // 放開滑鼠就歸零
        //}

        //// 每秒輸出一次傳送筆數
        //secondTimer += Time.deltaTime;
        //if (secondTimer >= 1f)
        //{
        //    Debug.Log($"[Server] 每秒送出筆數：{messagesSentThisSecond}");
        //    messagesSentThisSecond = 0;
        //    secondTimer = 0f;
        //}
        if (Input.GetKeyDown(KeyCode.P)) // 送姿態資料
        {
            manager.SendPoseOnce();
        }
    }
}
