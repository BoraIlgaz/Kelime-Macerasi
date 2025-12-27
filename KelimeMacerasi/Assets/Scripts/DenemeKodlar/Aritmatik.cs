using UnityEngine;

public class Aritmatik : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ARÝTMETÝKSEL OPERATÖRLER.
        int sayil1 = 60, sayil2 = 77, sayil3 = 77;
        int toplam = 0, fark = 0, carpim = 0, mod = 0;
        float bolum = 0;

        toplam = sayil1 + sayil2;
        fark = sayil1 - 10;
        carpim = sayil1 * sayil2;
        bolum = sayil2 / sayil1;
        mod = 10 % 3;

        // KARÞILAÞTIRMA OPERATÖRLERÝ.
        sayil1 = 50;
        sayil2 = 33;

        Debug.Log(sayil1 == sayil2);
        Debug.Log(sayil1 < sayil2);
        Debug.Log(sayil1 > sayil2);
        Debug.Log(sayil1 <= sayil2);
        Debug.Log(sayil1 >= sayil2);
        Debug.Log("Mod:"+mod);
        Debug.Log(sayil1 != sayil2);


        sayil1 = 2;
        sayil2 = 3;

        Debug.Log((sayil1 < sayil2) && (sayil1 > 0));
        Debug.Log((sayil1 < sayil2) && (sayil1 > 3));
        Debug.Log((sayil1 > sayil2) || (sayil1 > 0));
        Debug.Log(!(sayil1 > sayil2));
        Debug.Log(!(sayil1 > 0));


        sayil1 = sayil3;

        sayil1 += 1;
        Debug.Log(sayil1);

        sayil2 -= 1;
        Debug.Log(sayil2);

        sayil2 *= 2;
        Debug.Log(sayil2);

        sayil2 /= 2;
        Debug.Log(sayil2);


        sayil1 = 3;
        sayil3 = 0;

        Debug.Log(sayil1);

        Debug.Log(sayil1++);

        Debug.Log(sayil1);

        sayil3 = sayil1++;

        Debug.Log(sayil3);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
