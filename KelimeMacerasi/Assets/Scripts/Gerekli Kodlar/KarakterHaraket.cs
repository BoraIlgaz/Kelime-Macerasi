using UnityEngine;
using UnityEngine.SceneManagement;

public class KarakterHareketi : MonoBehaviour
{
    // OYUN KONTROL SCRIPTİNE ERİŞİM DEĞİŞKENİ
    // Unity Inspector'da atama yaptığınız değişken.
    public KelimeOyunKontrolu kelimeKontrol;

    // --- Hareket ve Dönme Değişkenleri ---
    public float hareketHizi = 5f;
    public float donmeHizi = 250f;
    private bool ziplamayapabilir = true;

    // --- Zıplama Değişkenleri ---
    public float ziplamaGucu = 7f;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void AnaSahneyeDon()
    {
        SceneManager.LoadScene("AnaSahne");
    }

    void Update()
    {
        // --- 1. Hareket ve Dönme Kodları ---
        float sagaSolaDegeri = Input.GetAxis("Horizontal");
        float ileriGeriDegeri = Input.GetAxis("Vertical");
        float xHareket = sagaSolaDegeri * hareketHizi * Time.deltaTime;
        float zHareket = ileriGeriDegeri * hareketHizi * Time.deltaTime;
        transform.Translate(new Vector3(xHareket, 0, zHareket));

        if (Input.GetMouseButton(1))
        {
            float yataydaFareHareketi = Input.GetAxis("Mouse X");
            float donmeMiktari = yataydaFareHareketi * donmeHizi * Time.deltaTime;
            transform.Rotate(Vector3.up, donmeMiktari);
        }

        // --- 2. Zıplama Girdi Kontrolü ---
        if (ziplamayapabilir && Input.GetButtonDown("Jump"))
        {
            Ziplama(ziplamaGucu);
        }
    }

    void Ziplama(float ziplamaGucu)
    {
        if (ziplamayapabilir)
        {
            rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
            ziplamayapabilir = false;
        }
    }

    // ÇARPIŞMA İLE CEVAPLAMA MANTIĞI
    private void OnCollisionEnter(Collision collision)
    {
        // ZEMİN KONTROLÜ
        if (collision.gameObject.CompareTag("Zemin"))
        {
            ziplamayapabilir = true;
        }

        // Oyun Kontrolü Çalışıyorsa
        // Not: Oyun bittiğinde kelimeKontrol.enabled = false olacak ve bu kısım çalışmayacaktır.
        if (kelimeKontrol != null && kelimeKontrol.enabled == true)
        {
            // TRUE küreye çarpma
            if (collision.gameObject.CompareTag("true"))
            {
                // Cevapla metodunu çağır (Bu yeni soruyu üretecek)
                kelimeKontrol.OyuncuCevapla(true);
                // !!! Küreyi gizleme/yok etme kodu artık yok. !!!
            }
            // FALSE küreye çarpma
            else if (collision.gameObject.CompareTag("false"))
            {
                // Cevapla metodunu çağır (Bu yeni soruyu üretecek)
                kelimeKontrol.OyuncuCevapla(false);
                // !!! Küreyi gizleme/yok etme kodu artık yok. !!!
            }
        }
    }
}