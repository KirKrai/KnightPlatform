using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private AudioSource _adSource;

    public AudioClip[] _adClip;
    public float volume;

    public Settings set;
    // Start is called before the first frame update
    void Start()
    {
        _adSource=GetComponent<AudioSource>();
        if (!_adSource.isPlaying)
        {
            ChangeMusic(Random.Range(0, _adClip.Length));
        }

    }

    // Update is called once per frame
    void Update()
    {
        volume = set.musicCurrentVolume;

        if (!_adSource.isPlaying)
        {
            ChangeMusic(Random.Range(0, _adClip.Length));
        }

    }
    public void ChangeMusic(int Song) 
    {
        _adSource.clip = _adClip[Song];
        _adSource.Play();

    }






}
