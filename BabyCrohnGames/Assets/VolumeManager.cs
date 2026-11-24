using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider; // السلايدر ديال الصوت

    void Start()
    {
        // جيب آخر قيمة ديال الصوت، إلا ماكانش مخزون عطيو 1
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 1f);
        AudioListener.volume = savedVolume;

        // خلي السلايدر يبدا بالقيمة المخزونة
        volumeSlider.value = savedVolume;

        // كل ما يبدل اللاعب السلايدر، تغير الصوت وتتخزن القيمة
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float value)
    {
        AudioListener.volume = value; // بدل الصوت
        PlayerPrefs.SetFloat("GameVolume", value); // خزن القيمة
        PlayerPrefs.Save();
    }
}
