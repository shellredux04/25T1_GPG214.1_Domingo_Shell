using UnityEditor;
using UnityEngine;
using System.IO;

public class AssetBundleBuilder
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        // Define the correct path for AssetBundles
        string assetBundleDirectory = Path.Combine(Application.streamingAssetsPath, "AssetBundles");

        // Ensure directory exists before building AssetBundles
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }

        // Build the AssetBundles for the current platform (change BuildTarget if needed)
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneOSX);

        Debug.Log("Asset Bundles Built Successfully!");
    }
}
