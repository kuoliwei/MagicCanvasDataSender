// ��b�ɮפW���L using ����
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class WebSocketServerManager : MonoBehaviour
{
    public WebSocketServer.WebSocketServer server; // �A�쥻�N��

    #region �A���¤�k�]�O�d�^
    public void BroadcastTestMessage(float x, float y)
    {
        string json = $"{{\"data\":[{{\"roller_id\":1,\"point\":[{x},{y}]}}]}}";
        server.SendMessageToClient(json);
        // Debug.Log("Sent: " + json);
    }
    #endregion

    // ====== �U���}�l�G�H�鰩�[���ժ� ======
    [Header("Pose JSON�]��˭��e�^")]
    [TextArea(6, 18)]
    public string poseJsonRaw; // �� 3DPOSE_Output.txt �����e��q�K�i��

    [Header("Pose JSON �ӷ� (Resources)")]
    [Tooltip("��b Assets/Resources/ �U���ɦW�]���t���ɦW�^")]
    public string poseResourceName = "3DPOSE_Output";

    [Tooltip("�Ұʮɦ۰ʱq Resources ���J")]
    public bool autoLoadPoseFromResources = true;

    [Header("�e�X�W�v")]
    public float poseFps = 15f;

    private Coroutine poseLoopCo;

    void Awake()
    {
        if (autoLoadPoseFromResources)
            LoadPoseFromResources();  // �� �ҰʴN�� txt ���e��i poseJsonRaw
    }

    /// <summary>
    /// �q Assets/Resources/{poseResourceName}.txt ���J�ö�J poseJsonRaw
    /// </summary>
    public void LoadPoseFromResources()
    {
        var ta = Resources.Load<TextAsset>(poseResourceName);
        if (ta == null)
        {
            Debug.LogError($"[Server] �䤣�� Resources/{poseResourceName}.txt�]�� .json�^�C�нT�{�ɮצ�� Assets/Resources/");
            return;
        }
        poseJsonRaw = ta.text;
        Debug.Log($"[Server] �w���J Pose JSON�]{poseResourceName}�A{poseJsonRaw.Length} chars�^");
    }
    // �榸�e�X�]��ˡ^
    public void SendPoseOnce()
    {
        if (string.IsNullOrWhiteSpace(poseJsonRaw))
        {
            Debug.LogWarning("[Server] poseJsonRaw �O�Ū��A�L�k�e�X");
            return;
        }
        server.SendMessageToClient(poseJsonRaw);
        // Debug.Log("[Server] Pose JSON �w�e�X�]�榸�^");
    }

    // �s��e�X�]��ˡ^
    public void StartPoseLoop()
    {
        if (poseLoopCo != null) StopCoroutine(poseLoopCo);
        poseLoopCo = StartCoroutine(CoPoseLoop());
    }

    public void StopPoseLoop()
    {
        if (poseLoopCo != null) StopCoroutine(poseLoopCo);
        poseLoopCo = null;
    }

    private IEnumerator CoPoseLoop()
    {
        if (string.IsNullOrWhiteSpace(poseJsonRaw))
        {
            Debug.LogWarning("[Server] poseJsonRaw �O�Ū��A�L�k�Ұʳs��e�X");
            yield break;
        }

        var wait = new WaitForSeconds(1f / Mathf.Max(1f, poseFps));
        while (true)
        {
            server.SendMessageToClient(poseJsonRaw);
            yield return wait;
        }
    }
}
