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

        // Ensure the SpriteRenderer is correctly positioned and set
        spriteRenderer.transform.position = new Vector3(0, 0, 0);
        LoadTexture(combinedDayTextureFilePath); // Load the initial day texture
    }

    private void Update()
    {
        // Toggle between day and night textures when pressing the "T" key
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
        if (File.Exists(texturePath))
        {
            // Load the texture as bytes
            byte[] textureBytes = File.ReadAllBytes(texturePath);

            // Create a new Texture2D object and load the image into it
            Texture2D texture = new Texture2D(0, 0);
            texture.LoadImage(textureBytes);  

            // Create a sprite with a centered pivot and set the texture size
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            // Apply the sprite to the sprite renderer
            spriteRenderer.sprite = sprite;

            // Ensure the sprite renderer's position is correctly set to show the sky
            spriteRenderer.transform.position = new Vector3(0, 0, -1); // Behind other objects

            // Scale the sprite to fit the screen size
            spriteRenderer.drawMode = SpriteDrawMode.Sliced;
            spriteRenderer.size = new Vector2(Screen.width / 100f, Screen.height / 100f);
        }
        else
        {
            Debug.LogError("Texture file not found at path: " + texturePath);  
        }
    }
}
