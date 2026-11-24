using UnityEngine;

public class XRayTaskCompletion : MonoBehaviour
{
    public void OnCompleteXrayTask()
    {
        // استدعاء EndSceneAndReturn لتحديث المهمة والعودة إلى CheckList
        FindObjectOfType<EndSceneManager>().EndSceneAndReturn();
    }
}
