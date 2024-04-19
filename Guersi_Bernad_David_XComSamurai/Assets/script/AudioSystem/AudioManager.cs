using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }


    [Header("AudioSources")]
    [Space]

    [SerializeField] AudioSource audioSourceMusic;
    [SerializeField] AudioSource audioSourceFX;
    [SerializeField] AudioSource audioSourceAmbience;
    
    [Space]

    [Header("Music Options")]
    [Space]
    [SerializeField] AudioClip [] musicClips;

    [SerializeField] double goalTime;
    [SerializeField] double musicDuration;
    AudioClip clipToPlay;



    [Header("FX Options")]
    [Space]

    [SerializeField] AudioClip kabukiShout;
    [SerializeField] AudioClip walking;
    [SerializeField] AudioClip shootingClip;
    [SerializeField] AudioClip[] hitSounds;

    [Header("Ambience Options")]
    [Space]

    [SerializeField] AudioClip ambienceSound;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        
        
        
    }

    public void PlaySound(AudioSource audioSource ,AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    private void Start()
    {
        
        goalTime = (double)audioSourceMusic.clip.samples / audioSourceMusic.clip.frequency;
        musicDuration = AudioSettings.dspTime + 0.2f;
        audioSourceMusic.PlayScheduled(musicDuration);
        audioSourceMusic.PlayScheduled(musicDuration + goalTime);

        PlaySound(audioSourceAmbience, ambienceSound);
        PlaySound(audioSourceFX, kabukiShout);

        ShootAction.OnShooting += ShootAction_OnShoot;
        SwordAction.OnAnySwordHit += SwordAction_OnAnySwordAction;

        StartCoroutine(MusicWaitCoroutine());
       

    }


    private void Update()
    {
        if (AudioSettings.dspTime > goalTime)
        {
            PlayScheduleClip();
        }
    }

    private void PlayScheduleClip()
    {
        clipToPlay = musicClips[UnityEngine.Random.Range(0,musicClips.Length)]; 

        audioSourceMusic.clip = clipToPlay;
        audioSourceMusic.PlayScheduled(goalTime);

        musicDuration = (double)clipToPlay.samples / clipToPlay.frequency;
        goalTime = goalTime + musicDuration;

        
    }

    private void ShootAction_OnShoot(object sender, EventArgs e)
    {
        ShootAction shootAction = sender as ShootAction;

        PlaySound(audioSourceFX, shootingClip);
        
    }

    private void SwordAction_OnAnySwordAction(object sender, EventArgs e) { 
        SwordAction swordAction = sender as SwordAction;
        int random = UnityEngine.Random.Range(0,hitSounds.Length);

        PlaySound(audioSourceFX, hitSounds[random]);
        
    }

    private IEnumerator MusicWaitCoroutine()
    {

        yield return new WaitForSeconds (3f);
        audioSourceMusic.volume = 1;
    }

}
