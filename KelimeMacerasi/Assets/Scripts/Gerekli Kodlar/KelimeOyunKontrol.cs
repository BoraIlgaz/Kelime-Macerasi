using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class KelimeOyunKontrolu : MonoBehaviour
{
    // =========================================================
    // INSPECTOR ATAMALARI
    // =========================================================
    public TextMeshPro soruEkraniYazisi;
    public GameObject karakterGovdesi1, karakterGovdesi2;
    public TextMeshProUGUI puanYazisi, sureYazisi;
    public GameObject bitisEkrani;
    public TextMeshProUGUI bitisMesaji;
    public KarakterHareketi karakterHareketi;

    // !!! YENÝ VE BASÝTLEÞTÝRÝLMÝÞ KÜRE REFERANSLARI !!!
    // Sahnede sabit duran DOÐRU ve YANLIÞ küre objeleri buraya atanacak.
    public GameObject trueCevapKuresi;
    public GameObject falseCevapKuresi;
    // Eski prefab ve spawnpoint deðiþkenleri silindi/kullanýlmadý.

    // =========================================================
    // PRIVATE DEÐÝÞKENLER
    // =========================================================
    public int toplamSureGenel = 150;
    private int toplamSureAzalan;
    private int puanDegiskeni = 0;
    private int soruSayisi = 0;
    private int saklananZorlukSecenegi = 0;
    private int saklananKarakterSecenegi = 0;
    private int sorulacakSoruSayisi;

    private List<Soru> sorularListesi;
    private bool oyuncuCevabi;
    private bool aktifSoruCevabi;
    private bool soruCevaplandiMi = true;
    private bool oyunDevamEdiyor = true;

    [System.Serializable]
    public class Soru
    {
        public string Kelime;
        public bool DogruMu;
    }

    void Start()
    {
        // Zorluk ve Karakter Seçimi (Mevcut Kod)
        saklananZorlukSecenegi = PlayerPrefs.GetInt("zorlukSecenegi", 0);
        sorulacakSoruSayisi = (saklananZorlukSecenegi == 0) ? 5 : 10;
        saklananKarakterSecenegi = PlayerPrefs.GetInt("karakterSecenegi", 0);
        karakterGovdesi1.SetActive(saklananKarakterSecenegi == 0);
        karakterGovdesi2.SetActive(saklananKarakterSecenegi == 1);

        SorulariJSONdanOku();

        if (soruCevaplandiMi)
        {
            SoruUret();
        }

        // Bitiþ ekranýný gizle
        if (bitisEkrani != null)
        {
            bitisEkrani.SetActive(false);
        }

        // KarakterHareketi script'ini bul
        if (karakterGovdesi1.activeSelf)
        {
            karakterHareketi = karakterGovdesi1.GetComponent<KarakterHareketi>();
        }
        else if (karakterGovdesi2.activeSelf)
        {
            karakterHareketi = karakterGovdesi2.GetComponent<KarakterHareketi>();
        }

        // Baþlangýçta küreleri görünür yap
        if (trueCevapKuresi != null) trueCevapKuresi.SetActive(true);
        if (falseCevapKuresi != null) falseCevapKuresi.SetActive(true);


        // ZAMANLAYICI BAÞLATMA
        toplamSureAzalan = toplamSureGenel;
        InvokeRepeating("SureKontrol", 1f, 1f);
    }

    // =========================================================
    // OYUN BÝTÝRME MANTIÐI VE TEMEL OYUN METOTLARI (Ayný Kaldý)
    // =========================================================

    public void OyunuBitir(string sebep)
    {
        if (!oyunDevamEdiyor) return;
        oyunDevamEdiyor = false;

        CancelInvoke("SureKontrol");

        if (karakterHareketi != null)
        {
            karakterHareketi.enabled = false;
        }

        if (bitisEkrani != null)
        {
            bitisEkrani.SetActive(true);
        }

        if (bitisMesaji != null)
        {
            bitisMesaji.text = sebep + "\n\nTOPLAM PUANINIZ: " + puanDegiskeni;
        }
    }


    public void SureKontrol()
    {
        if (!oyunDevamEdiyor) return;

        toplamSureAzalan--;
        sureYazisi.text = "Süre: " + toplamSureAzalan;

        if (toplamSureAzalan <= 0)
        {
            OyunuBitir("Süreniz Bitti!");
        }
    }

    public void OyuncuCevapla(bool oyuncuCevabi)
    {
        if (!oyunDevamEdiyor) return;

        // Puanlama Mantýðý (Ayný Kaldý)
        if (oyuncuCevabi == aktifSoruCevabi)
        {
            puanDegiskeni += 10;
        }
        else
        {
            puanDegiskeni -= 5;
            if (puanDegiskeni < 0) puanDegiskeni = 0;
        }
        puanYazisi.text = "Puan: " + puanDegiskeni;

        // Yeni Soruya Geçiþ VEYA Oyun Sonu
        soruSayisi++;

        if (soruSayisi < sorulacakSoruSayisi)
        {
            SoruUret();
        }
        else
        {
            OyunuBitir("Tebrikler! Tüm Sorularý Tamamladýnýz.");
        }
    }

    // =========================================================
    // JSON VE SORU ÜRETÝM METOTLARI
    // =========================================================

    public void SorulariJSONdanOku()
    {
        string jsonText = Resources.Load<TextAsset>("kelimeler").text;
        if (!string.IsNullOrEmpty(jsonText))
        {
            sorularListesi = JsonConvert.DeserializeObject<List<Soru>>(jsonText);
        }
    }

    public Soru RastgeleSoruOlustur()
    {
        int index = Random.Range(0, sorularListesi.Count);
        Soru secilenSoru = sorularListesi[index];
        sorularListesi.RemoveAt(index);
        return secilenSoru;
    }

    // YENÝ SORU ÜRETME VE KÜRELERÝ GÖRÜNÜR YAPMA METODU
    public void SoruUret()
    {
        if (!oyunDevamEdiyor) return;

        Soru aktifSoru = RastgeleSoruOlustur();
        string aktifSoruMetni = aktifSoru.Kelime;
        aktifSoruCevabi = aktifSoru.DogruMu;

        // Soru metnini güncelle
        soruEkraniYazisi.text = soruSayisi + 1 + " - " + aktifSoruMetni;
        soruCevaplandiMi = false;

        // KÜRELERÝ GÖRÜNÜR YAPMA (Yeni mantýk!)
        if (trueCevapKuresi != null) trueCevapKuresi.SetActive(true);
        if (falseCevapKuresi != null) falseCevapKuresi.SetActive(true);
    }
}