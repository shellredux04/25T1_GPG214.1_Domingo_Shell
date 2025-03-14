using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetBundleLoader : MonoBehaviour
{
    public string folderPath = "AssetBundles";
    public string fileName = "assetBundle";
    public string assetBundlePath;
    private AssetBundle assetBundle;
    public SpriteRenderer spikeSprite;

    private void Start()
    {
        
        LoadAssetBundle();

        
        LoadObstacle();

         
        LoadSprite();
    }

    void LoadAssetBundle()
{      
    
    assetBundlePath = Path.Combine(Application.streamingAssetsPath, "AssetBundles", fileName);

  

    if (File.Exists(assetBundlePath))
    {
        assetBundle = AssetBundle.LoadFromFile(assetBundlePath);
        
    }
    else
    {
        
    }
}


    void LoadObstacle()
    {
        if (assetBundle == null)
        {
            return;
        }

        // List all assets in the bundle for debugging
        foreach (string assetName in assetBundle.GetAllAssetNames())
        {
        }

        GameObject spikesPrefab = assetBundle.LoadAsset<GameObject>("Spikes");

        if (spikesPrefab != null)
        {
            Instantiate(spikesPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Debug.Log("Spikes Spawned");
        }
        else
        {
        }
    }

void LoadSprite()
{
    if (assetBundle == null)
    {
        Debug.LogError(" AssetBundle is null. Cannot load sprite.");
        return;
    }

    Texture2D spikesTexture = assetBundle.LoadAsset<Texture2D>("SpikesNew");

    if (spikesTexture != null)
    {
        if (spikeSprite != null) 
        {
            spikeSprite.sprite = Sprite.Create(spikesTexture, new Rect(0, 0, spikesTexture.width, spikesTexture.height), Vector2.zero);
            Debug.Log(" Sprite loaded successfully.");
        }
        else
        {
        }
    }
    else
    {
    }
}

}
