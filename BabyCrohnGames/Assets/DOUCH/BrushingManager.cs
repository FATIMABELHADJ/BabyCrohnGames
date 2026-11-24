using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BrushingManager : MonoBehaviour
{
    public Slider brushingSlider;
    public float brushingSpeed = 20f;
    private bool isBrushing = false;

    void Update()
    {
        if (isBrushing)
        {
            brushingSlider.value += brushingSpeed * Time.deltaTime;

            if (brushingSlider.value >= brushingSlider.maxValue)
            {
                isBrushing = false;
                SceneManager.LoadScene("NV"); // بدّل الاسم هنا
            }
        }
    }

    public void StartBrushing()
    {
        isBrushing = true;
    }
}
