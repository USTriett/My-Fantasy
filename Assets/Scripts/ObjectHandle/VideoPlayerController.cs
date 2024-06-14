using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    [SerializeField]
    private Camera _videoCamera;

    // Start is called before the first frame update
    private VideoPlayer _videoPlayer;

    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.loopPointReached += EndReached;
    }

    private void EndReached(VideoPlayer sourcm)
    {
        StopVideo();
        // Camera.current.gameObject.SetActive(true);
        _videoCamera.gameObject.SetActive(false);
    }

    public void PlayVideo()
    {
        // _videoCamera.

        _videoPlayer.Play();
        _videoCamera.gameObject.SetActive(true);
    }

    private void StopVideo()
    {
        _videoPlayer.Stop();
    }

    public bool IsPlaying()
    {
        return _videoPlayer.frameCount > 0 || _videoPlayer.isPlaying;
    }
}
