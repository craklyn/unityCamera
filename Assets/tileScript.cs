using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class tileScript : MonoBehaviour {
    Texture2D tex = null;

    // Use this for initialization
    void Start () {
    }
	
    int updateCount = 0;
    // Update is called once per frame
	void Update () {
        updateCount += 1;

        Renderer renderer = GetComponent<Renderer>();
        if (renderer.material.mainTexture == null || updateCount % 50 == 0) {
            if (File.Exists("textureImage.png"))
            {
                byte[] fileData;
                fileData = File.ReadAllBytes("textureImage.png");
                tex = new Texture2D(2, 2);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
                renderer.material.mainTexture = tex;
            }
        }
    }
}
