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
            return;
        }

        streamingPath = Application.streamingAssetsPath;

        StartCoroutine(LoadAndPlayMusic(musicGameplay));
    }

    // Press 1 for default music - Press 2 for another music
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
            StartCoroutine(LoadAndPlayMusic(musicGameplay));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(LoadAndPlayMusic(musicGunnerFight));
        }
    }

    IEnumerator LoadAndPlayMusic(string fileName)
    {
        string filePath = Path.Combine(streamingPath, fileName);
        string url = "file://" + filePath;


        if (!File.Exists(filePath))
        {
            yield break;
        }

        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
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
                }
            }
        }
    }
}
