using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;  
    public string daySpriteElement = "Sky.png"; 
    public string nightSpriteElement = "SkyNight.png"; 
    private string combinedSpriteFilePathLocation;

    private void Start()
    {
        combinedSpriteFilePathLocation = Path.Combine(Application.streamingAssetsPath, daySpriteElement);
        LoadSprite(daySpriteElement);  
    }

    private void Update()
    {
        // Changes the sky's colour
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleSky();
        }
    }

    private void ToggleSky()
    {
        if (spriteRenderer.sprite.name == daySpriteElement)
        {
            // Load the night sky
            LoadSprite(nightSpriteElement);
        }
        else
        {
            // Load the day sky
            LoadSprite(daySpriteElement);
        }
    }
    public void LoadSprite(string spriteElement)
    {
        string combinedSpriteFilePathLocation = Path.Combine(Application.streamingAssetsPath, spriteElement);

        if (File.Exists(combinedSpriteFilePathLocation))
        {
            // Read sprite file bytes
            byte[] spriteBytes = File.ReadAllBytes(combinedSpriteFilePathLocation);

            // Load image byte into 2D texture
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(spriteBytes);

            // Create sprite
            Sprite sprite = Sprite.Create(texture, new Rect(-20, 0, texture.width, texture.height), Vector2.zero);

            // Assign sprite to sprite renderer component
            spriteRenderer.sprite = sprite;
        }
        else
        {
            
        }
    }
}
