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
        // Load asset bundle from path
        LoadAssetBundle();

        // Load Prefab
        LoadObstacle();

        // Load Sprite
        LoadSprite();
    }

    void LoadAssetBundle()
{      
    // Add platform-specific folder (StandaloneOSXUniversal)
    assetBundlePath = Path.Combine(Application.streamingAssetsPath, "AssetBundles", fileName);

    Debug.Log("🔍 Checking path: " + assetBundlePath);

    if (File.Exists(assetBundlePath))
    {
        assetBundle = AssetBundle.LoadFromFile(assetBundlePath);
        Debug.Log(" Asset Bundle Loaded Successfully!");
    }
    else
    {
        Debug.LogError(" File does not exist: " + assetBundlePath);
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
            Debug.Log("Asset in bundle: " + assetName);
        }

        GameObject spikesPrefab = assetBundle.LoadAsset<GameObject>("Spikes");

        if (spikesPrefab != null)
        {
            Instantiate(spikesPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Debug.Log("Spikes Spawned");
        }
        else
        {
            Debug.LogError("Failed to load Spikes Prefab");
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
        if (spikeSprite != null) // Ensure it's assigned
        {
            spikeSprite.sprite = Sprite.Create(spikesTexture, new Rect(0, 0, spikesTexture.width, spikesTexture.height), Vector2.zero);
            Debug.Log(" Sprite loaded successfully.");
        }
        else
        {
            Debug.LogError("spikeSprite is not assigned in the Inspector!");
        }
    }
    else
    {
        Debug.LogError("Failed to load the sprite from the AssetBundle.");
    }
}

}
