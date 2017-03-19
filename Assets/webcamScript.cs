// Starts the default camera and assigns the texture to the current renderer
using UnityEngine;
using System.Collections;

public class webcamScript : MonoBehaviour
{
    WebCamTexture webcamTexture;
    
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        webcamTexture = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        if (devices.Length > 0)
        {
            webcamTexture.deviceName = devices[0].name;
            webcamTexture.Play();
        }
        else
           webcamTexture.Play();
    }

    void OnMouseDown()  {
        TakeSnapshot();
    }

    private void Update()
    {

    }

    private string _SavePath = "";
    int _CaptureCounter = 0;
    void TakeSnapshot()
    {
        Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height);
        snap.SetPixels(webcamTexture.GetPixels());
        snap.Apply();

        System.IO.File.WriteAllBytes(_SavePath + "textureImage" + ".png", snap.EncodeToPNG());
//        System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
        ++_CaptureCounter;
    }

}
