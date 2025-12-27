using UnityEngine;

public class InputAlma : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Klavye girdi sistemi

        // Klavyeden sað-sol yön tuþlarý veya A-D tuþlarýna basýldýðýnda 
        // deðiþen "Horizontal" eksenin deðeri (genellikle -1.0 ile 1.0 arasýnda), 
        // sagaSolaDegeri deðiþkenine atanýr.
        float sagaSolaDegeri = Input.GetAxis("Horizontal");
        Debug.Log("Yataydaki Sað Sol Deðeri = " + sagaSolaDegeri);

        // Input.GetKey(KeyCode.Space)
        // Space tuþuna BASILDIÐI SÜRECE (her frame) doðru (true) döner.
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space Tuþuna Basýlýyor");
        }

        // Input.GetKeyDown(KeyCode.Backspace)
        // Backspace tuþuna ÝLK BASILDIÐI frame (sadece bir kez) doðru (true) döner.
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("Geri Tuþuna Basýldý");
        }
    }
}
