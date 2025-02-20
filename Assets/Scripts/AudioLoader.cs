using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class AudioLoader : MonoBehaviour
{
    public string musicGameplay = "MusicGameplay.wav";
    public string musicGunnerFight = "MusicGunnerFight.wav";

    private AudioSource audioSource;
    private string streamingPath;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError(" Error: No AudioSource Found on GameObject!");
            return;
        }

        streamingPath = Application.streamingAssetsPath;

        // Log the path to ensure it's correct
        Debug.Log("📂 StreamingAssets Path: " + streamingPath);

        // Start with default music
        StartCoroutine(LoadAndPlayMusic(musicGameplay));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(" Switching to Gameplay Music...");
            StartCoroutine(LoadAndPlayMusic(musicGameplay));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(" Switching to Gunner Fight Music...");
            StartCoroutine(LoadAndPlayMusic(musicGunnerFight));
        }
    }

    IEnumerator LoadAndPlayMusic(string fileName)
    {
        string filePath = Path.Combine(streamingPath, fileName);
        string url = "file://" + filePath;

        // Log the full file path being used
        Debug.Log("📂 File Path: " + filePath);

        if (!File.Exists(filePath))
        {
            Debug.LogError(" Audio File Not Found: " + filePath);
            yield break;
        }

        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(" Error Loading Audio: " + www.error);
            }
            else
            {
                AudioClip newClip = DownloadHandlerAudioClip.GetContent(www);

                if (newClip != null)
                {
                    audioSource.Stop();
                    audioSource.clip = newClip;
                    audioSource.loop = true;
                    audioSource.Play();
                    Debug.Log(" Now Playing: " + fileName);
                }
                else
                {
                    Debug.LogError("mFailed to Load Audio Clip! Clip is NULL.");
                }
            }
        }
    }
}
