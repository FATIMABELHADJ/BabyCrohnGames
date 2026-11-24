using UnityEngine;
using UnityEngine.Playables;

public class BabySickManager : MonoBehaviour
{
    public PlayableDirector timeline;

    void Start()
    {
        timeline.Play();  // يبدأ المشهد أوتوماتيكياً
    }
}
