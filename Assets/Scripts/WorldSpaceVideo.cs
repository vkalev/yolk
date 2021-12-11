using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class WorldSpaceVideo : MonoBehaviour {

    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    private int videoClipIndex;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer> ();
    }

    // Use this for initialization
    void Start () 
    {
        videoPlayer.clip = videoClips [0];    
    }

    // Update is called once per frame
    void Update () 
    {
        if (videoPlayer.isPlaying) 
        {
            SetCurrentTimeUI ();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            SetNextClip ();
        }
    }

    public void SetNextClip()
    {
        videoClipIndex++;

        if (videoClipIndex >= videoClips.Length) 
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }

        videoPlayer.clip = videoClips [videoClipIndex];
        SetTotalTimeUI ();
        videoPlayer.Play ();

    }

    public void PlayPause()
    {
        if (videoPlayer.isPlaying) 
        {
            videoPlayer.Pause ();
        } else 
        {
            videoPlayer.Play ();
            SetTotalTimeUI ();
        }
    }

    void SetCurrentTimeUI()
    {
        string minutes = Mathf.Floor ((int)videoPlayer.time / 60).ToString ("00");
        string seconds = ((int)videoPlayer.time % 60).ToString ("00");
    }

    void SetTotalTimeUI()
    {
        string minutes = Mathf.Floor ((int)videoPlayer.clip.length / 60).ToString ("00");
        string seconds = ((int)videoPlayer.clip.length % 60).ToString ("00");
    }

    double CalculatePlayedFraction()
    {
        double fraction = (double)videoPlayer.frame / (double)videoPlayer.clip.frameCount;
        return fraction;
    }
}