using UnityEngine;

public class Rastgale : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // [0,100] arasýnda random (rastgele) bir sayý üretir.
        int sayi = Random.Range(0, 101);
        Debug.Log("Sayý: " + sayi);

        // Sadece if kullanýmý.
        if (sayi > 50)
        {
            Debug.Log("Sayý 50 ile 100 arasýnda!");
        }

        // if / else kullanýmý.
        if (sayi >= 50)
        {
            Debug.Log("Sayý 50 ile 100 arasýnda!");
        }
        else
        {
            Debug.Log("Sayý 0 ile 50 arasýnda!");
        }

        // if / else if kullanýmý.
        if (sayi >= 75)
        {
            Debug.Log("Sayý 75 ile 100 arasýnda!");
        }
        else if (sayi >= 50)
        {
            Debug.Log("Sayý 50 ile 75 arasýnda!");
        }
        else
        {
            Debug.Log("Sayý 0 ile 50 arasýnda!");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
