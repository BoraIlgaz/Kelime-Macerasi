using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int sayi1 = 77;
        int sayi2;
        sayi2 = 60;

        string[] iller = new string[] { "Yalova", "Tokat", "Tekirdað" };
        int[] sayilar = new int[3];
        sayilar[0] = 9;
        sayilar[1] = 8;
        sayilar[2] = 3;

        List<int> sayilar2 = new() {1,2,3 } ;

        List<string> iller2 = new();
        iller2.Add("Ýstanbul");
        iller2.Add("Bursa");
        iller2.Add("Konya");

        Debug.Log("sayi2 = " + sayi2);
        Debug.Log("Ýller dizisinin 2.elemaný"+iller[1]);
        Debug.Log("Ýller dizisinin 3.elemaný" + iller[2]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
