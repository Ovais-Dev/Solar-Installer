using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource[] sounds;
    public AudioSource homeMusic;
    float sndLevel = 0.3f; // 0.3f to 0.7f;
    float timeToAppear = 10f; // 8f to 15f;

    public AudioClip clip;
    public AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {

        sndLevel = RandomSet(0.15f, 0.7f);
        timeToAppear = RandomSet(8f, 15f);
        StartCoroutine(PlayMusicAgain());
        curve.AddKey(clip.length / 5f, RandomSet(0.2f, 0.7f));
        curve.AddKey(clip.length / 2f, RandomSet(0.2f, 0.7f));
        
        curve.AddKey(clip.length / 1.2f, RandomSet(0.2f, 0.7f));
        curve.AddKey(clip.length, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (homeMusic.isPlaying)
        {
            homeMusic.volume = curve.Evaluate(homeMusic.time);
        }
    }
    void CurveModify()
    {
        //Keyframe key = new Keyframe(clip.length / 1.2f, RandomSet(0.2f, 0.7f));
        curve.MoveKey(1,VolumeRandomiserKeys(clip.length / 5f, RandomSet(0.2f, 0.7f)));
        curve.MoveKey(2, VolumeRandomiserKeys(clip.length / 2f, RandomSet(0.2f, 0.7f)));
        curve.MoveKey(3, VolumeRandomiserKeys(clip.length / 1.2f, RandomSet(0.2f, 0.7f)));
    }
    Keyframe VolumeRandomiserKeys(float time, float randomValue)
    {
        return new Keyframe(time, randomValue);
    }
    IEnumerator PlayMusicAgain()
    {
        yield return new WaitUntil(() => !homeMusic.isPlaying);
        yield return new WaitForSeconds(timeToAppear);
        CurveModify();
        if (!homeMusic.isPlaying)
        {
            homeMusic.volume = sndLevel;
            homeMusic.Play();
        }
       
        timeToAppear = RandomSet(14f, 20f);
        sndLevel = RandomSet(0.1f, 1f);
        StartCoroutine(PlayMusicAgain());
    }
    public void PlayMusic(int number)
    {

        sounds[number].Play();
    }
    float RandomSet(float minValule,float maxValue)
    {
        return Random.Range(minValule, maxValue);
    }
}
