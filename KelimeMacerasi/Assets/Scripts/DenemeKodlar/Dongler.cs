using UnityEngine;

public class Dongler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int toplam1 = 0;
        // 1'den 10'a kadar olan sayýlarý toplar.
        for (int i = 1; i <= 10; i++)
        {
            toplam1 += i;
        }
        Debug.Log("Toplam (for): " + toplam1);

        int toplam2 = 0;
        int sayac = 1;
        // 1'den 10'a kadar olan sayýlarý toplar.
        while (sayac <= 10)
        {
            toplam2 += sayac;
            sayac++;
        }
        Debug.Log("Toplam (while): " + toplam2);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
