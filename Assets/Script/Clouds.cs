using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public Transform cloud;
  SpriteRenderer render;
    public float fadeTime = 5f;
    public float rotSpeed;

    public Vector2 cloudDuration;
    public ParticleSystem rainEffect;

    float cloud_D;
   
    int randDir;
    float alpha = 0;

    Vector3 trackDir;
    int moveDir = 1;
    float initialPos;
    public float range = 1f;
    public float shakeSpeed = 0.3f;

    bool start = true;

    public AudioSource rain;
    public AnimationCurve rainVolumeCurve;
    float duration;
    float sndVolume;
    // Start is called before the first frame update
    void Start()
    {
       
            render = cloud.GetComponent<SpriteRenderer>();
        render.color = new Color(1, 1, 1, 0);
        float valueDecider = Random.Range(0, 2);
        if (valueDecider == 0)
            randDir = -1;
        else
            randDir = 1;
        initialPos = transform.position.magnitude;
        cloud_D = Random.Range(cloudDuration.x, cloudDuration.y);
        Invoke("TimeToDestroy", cloud_D);
        Invoke("PlayRain", cloud_D - 3.5f);
    }
    void AnimationCurveAdding()
    {
        rainVolumeCurve.AddKey(0, 0);
        rainVolumeCurve.AddKey(duration, 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(Vector2.zero, new Vector3(0, 0, randDir), rotSpeed * Time.deltaTime);

        if (start)
        {
            if (render.color.a < 1)
                FadeIn();
        }
        else
        {
            if (render.color.a > 0)
                FadeOut();
            else
            {
                Destroy(gameObject);
            }
        }
        
        LittleShake();
        if (rain.isPlaying)
        {
            rain.volume = rainVolumeCurve.Evaluate(rain.time);
        }
    }
    void PlayRain()
    {
        rainEffect.Play();
        rain.Play();
    }
    void TimeToDestroy()
    {
        start = false;
    }
    private void Update()
    {
        //LittleShake()/*;*/
    }
    void LittleShake()
    {
        trackDir = transform.position;
        
        trackDir.Normalize();
       
        
        cloud.position += trackDir * shakeSpeed * moveDir * Time.deltaTime;
        if (cloud.position.magnitude -initialPos> range && moveDir == 1)
            moveDir = -1;
        else if (cloud.position.magnitude-initialPos < -range && moveDir == -1)
            moveDir = 1;
    }
    void FadeIn()
    {
       
        if(alpha<1)
        alpha += Time.deltaTime * (1 / fadeTime);
        render.color = new Color(1, 1, 1, alpha);
    }
    void FadeOut()
    {
        if (alpha > 0)
            alpha -= Time.deltaTime * (1 / fadeTime);
        render.color = new Color(1, 1, 1, alpha);
    }
}
