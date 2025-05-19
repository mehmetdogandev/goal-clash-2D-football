using UnityEngine;
using UnityEngine.UI;  // Slider için gerekli
using TMPro;          // Text için gerekli

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;  // Ses seviyesini kontrol etmek için slider
    public TextMeshProUGUI volumeText; // Ses seviyesini gösterecek metin

    void Start()
    {
        // Başlangıçta slider değeri ses kaynağının mevcut seviyesiyle eşleşsin
        volumeSlider.value = MenuMusicPlayer.instance.audioSource.volume;

        // Slider'ın değerini değiştirdiğimizde ses seviyesini güncelle
        volumeSlider.onValueChanged.AddListener(UpdateVolume);

        // Başlangıçta ses seviyesini göster
        UpdateVolume(volumeSlider.value);
    }

    // Slider değeri değiştiğinde çağrılacak fonksiyon
    public void UpdateVolume(float value)
    {
        // MenuMusicPlayer objesindeki ses seviyesini slider değeri ile güncelle
        MenuMusicPlayer.instance.SetVolume(value);

        // Yüzdelik değeri metne dönüştürüp göster
        volumeText.text = (value * 100).ToString("F0") + "%";
    }
}
