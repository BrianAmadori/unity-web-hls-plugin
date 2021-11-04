using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DCL.Components.Video.Plugin;
using UnityEngine;
using UnityEngine.UI;
using Video.Plugin;

public class VideoComponent : MonoBehaviour
{
    public Material originalMaterial;
    public Button play;
    public Button pause;
    public Button stop;
    public Button shuffle;
    public Text text;

    private static int id = 0;

    private WebVideoPlayer videoPlayer;
    private int currentId;

    private static readonly string[] urlList = new []
    {
        "https://multiplatform-f.akamaihd.net/i/multi/will/bunny/big_buck_bunny_,640x360_400,.f4v.csmil/master.m3u8",
        "https://dweb.link/ipfs/bafybeia7pyfmyjcnjrodau2yxm3h3bs6suv3xfzwvhohktnw6v2cevayaq/mp4/0/0_Action-01-Look_R-L.mp4",
        "https://cph-p2p-msl.akamaized.net/hls/live/2000341/test/master.m3u8",
        "https://player.vimeo.com/external/552481870.m3u8?s=c312c8533f97e808fccc92b0510b085c8122a875",
    };

    public void Start()
    {
        currentId = id;
        id++;
        PlayVideo();
    }


    public void PlayVideo()
    {
        string url = urlList[ Random.Range(0, urlList.Length) ];
        bool isStream = !new[] { ".mp4", ".ogg", ".mov", ".webm" }.Any(x => url.EndsWith(x));
        videoPlayer = new WebVideoPlayer(currentId.ToString(), url, isStream, new VideoPluginWrapper_WebGL());

        Material videoMaterial = new Material(originalMaterial);
        videoMaterial.SetTexture("_MainTex", videoPlayer.texture);
        GetComponent<RawImage>().material = videoMaterial;
        GetComponent<RawImage>().texture = videoPlayer.texture;

        play.onClick.RemoveAllListeners();
        pause.onClick.RemoveAllListeners();
        stop.onClick.RemoveAllListeners();
        shuffle.onClick.RemoveAllListeners();

        play.onClick.AddListener(
            () =>
            {
                Debug.Log("Playing!");
                videoPlayer.Play();
            }
        );
        pause.onClick.AddListener(
            () =>
            {
                Debug.Log("Pausing!");
                videoPlayer.Pause();
            }
        );
        stop.onClick.AddListener( () =>
            {
                Debug.Log("Stopping!");
                videoPlayer.Pause();
                videoPlayer.SetTime(0);
            }
        );

        shuffle.onClick.AddListener( () =>
            {
                Debug.Log("Shuffling!");
                PlayVideo();
                videoPlayer.SetTime(0);
                videoPlayer.Play();
            }
        );
    }

    public void Update()
    {
        if ( videoPlayer != null )
        {
            text.text = $"URL: {videoPlayer.url}\nTIME: {videoPlayer.GetTime()} ... STATE: {videoPlayer.GetState()}";
            videoPlayer.Update();

            if ( Input.GetKeyDown(KeyCode.X))
            {
                videoPlayer.Pause();
                videoPlayer.Dispose();
                videoPlayer = null;
                text.text = $"Video Disposed.";
            }
        }

        if ( Input.GetKeyDown(KeyCode.Z))
        {
            PlayVideo();
        }
    }
}