using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro'ya sahip UI nesneleri için gerekli sýnýftýr.
using UnityEngine.SceneManagement; // Sahne iþlemleri için gerekli sýnýftýr.

public class SahneGecisi : MonoBehaviour
{
    // Karakter ve Zorluk açýlýr listelerini tutacak olan deðiþkenler.
    public TMP_Dropdown karakter, zorluk;

    void Start()
    {
        // KarakterSecenegi isimli bir PlayerPrefs'ýn deðeri alýnýr,
        // böyle bir deðer yok ise 0 deðeri alýnýr.
        int saklananKarakterSecenegi = PlayerPrefs.GetInt("karakterSecenegi", 0);

        // Karakter açýlýr listesinin seçeneði saklananKarakterSecenegi deðerine eþitlenir.
        karakter.value = saklananKarakterSecenegi;

        // YENÝ EKLENECEK: ZorlukSecenegi isimli PlayerPrefs deðeri alýnýr.
        int saklananZorlukSecenegi = PlayerPrefs.GetInt("zorlukSecenegi", 0);

        // Zorluk açýlýr listesinin seçeneði saklananZorlukSecenegi deðerine eþitlenir.
        zorluk.value = saklananZorlukSecenegi;
    }

    public void SahneDegistir(string sahneAdi)
    {
        // OyunSahnesi aktif olduðunda Karakter açýlýr listesinin
        // seçilen deðeri (0 veya 1) karakterSecenegi isimli
        // PlayerPrefs olarak belirlenir. OyunSahnesi'nde
        // karakterSecenegi deðeri okutulur ve bu deðere göre oyun
        // karakteri olarak silindir veya kapsül aktif edilir.
        PlayerPrefs.SetInt("karakterSecenegi", karakter.value);

        // YENÝ EKLENEN KISIM: ZORLUK AYARINI KAYDETME
        // Zorluk açýlýr listesinin seçilen deðeri, zorlukSecenegi
        // isimli PlayerPrefs olarak belirlenir.
        PlayerPrefs.SetInt("zorlukSecenegi", zorluk.value);

        // PlayerPrefs deðerleri cihaza kaydedilir.
        PlayerPrefs.Save();

        // Belirtilen sahneye geçiþ yapýlýr.
        SceneManager.LoadScene(sahneAdi);
    }

    public void OyunuKapat()
    {
        // Oyun bir cihazda oynanýyorsa oyundan çýkýþ yapýlýr.
        Application.Quit();
    }
}