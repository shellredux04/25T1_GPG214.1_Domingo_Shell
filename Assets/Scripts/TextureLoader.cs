using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextureLoader : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;   
    public string dayTexture = "Sky.png";   
    public string nightTexture = "SkyNight.png";   
    
    private string combinedDayTextureFilePath;  
    private string combinedNightTextureFilePath; 

    private bool isNight = false;  
    private void Start()
    {
        combinedDayTextureFilePath = Path.Combine(Application.streamingAssetsPath, dayTexture);
        combinedNightTextureFilePath = Path.Combine(Application.streamingAssetsPath, nightTexture);

        LoadTexture(combinedDayTextureFilePath);
    }

    
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            isNight = !isNight;  

            
            if (isNight)
            {
                LoadTexture(combinedNightTextureFilePath);  
            }
            else
            {
                LoadTexture(combinedDayTextureFilePath);  
            }
        }
    }

        void LoadTexture(string texturePath)
    {
        Debug.Log("Loading texture from: " + texturePath); 

        if (File.Exists(texturePath))
        {
            
            byte[] textureBytes = File.ReadAllBytes(texturePath);

            
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(textureBytes);  
            
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            
            spriteRenderer.sprite = sprite;
        }
        else
        {
            Debug.LogError("Texture file not found at path: " + texturePath);  
        }
    }
}
