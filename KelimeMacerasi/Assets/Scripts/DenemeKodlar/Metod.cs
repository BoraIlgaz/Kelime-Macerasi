using UnityEngine;

public class DenemeScript : MonoBehaviour
{
    // Start metodu oyun baþladýðýnda bir kez çaðrýlýr.
    void Start()
    {
        // 1. Parametresiz Topla() metodunu çaðýrýr. (30 + 3)
        Debug.Log("Parametresiz Metot = " + Topla());

        // 2. Bir parametreli Topla(int) metodunu çaðýrýr. (96 + 3)
        Debug.Log("Bir parametreli Metot = " + Topla(96));

        // 3. Ýki parametreli Topla(int, int) metodunu çaðýrýr. (1000 + 1)
        Debug.Log("Ýki parametreli Metot = " + Topla(1000, 1));
    }

    // --- Metot Aþýrý Yüklemesi (Method Overloading) Örnekleri ---

    // 1. Parametresiz Topla metodu. Sýnýf içindeki sabit deðerleri toplar.
    public int Topla()
    {
        int sayi1 = 30;
        int sayi2 = 3;
        return (sayi1 + sayi2);
    }

    // 2. Bir parametreli Topla metodu. Gelen parametreyi ve sabit sayi2 deðerini toplar.
    public int Topla(int sayi1)
    {
        int sayi2 = 3;
        return (sayi1 + sayi2);
    }

    // 3. Ýki parametreli Topla metodu. Gelen iki parametreyi toplar.
    public int Topla(int sayi1, int sayi2)
    {
        return (sayi1 + sayi2);
    }
}