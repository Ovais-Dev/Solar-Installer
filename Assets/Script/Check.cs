using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Check : MonoBehaviour
{
    public Slider slide;
    public Slider slide2;
    public Image rendere1,rendere2;
    public ParticleSystem party1, party2;

    public Color finalColor = Color.white;

    private Color initialColor1;
    private Color initialColor2;

    public float maxValue;
    public float lerpSpeed = 2f;
    public float finalValue;
    float tempValue;

    bool lerping = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DelayCalling", 0.08f);
        tempValue = finalValue;
        ChangeValue();
        
        initialColor1 = rendere1.color;
        initialColor2 = rendere2.color;
        party1.Stop();
        party2.Stop();
    }
    void DelayCalling()
    {
        
        slide.maxValue = maxValue;
        slide2.maxValue = maxValue;
    }
    // Update is called once per frame
    void Update()
    {
        if (tempValue!=finalValue)
        {
            party1.Play();
            party2.Play();
            tempValue = finalValue;
            ChangeValue();
            lerping = true;
        }
        if (lerping)
        {
            if (slide.value != finalValue)
            {
                slide.value = Mathf.Lerp(slide.value, finalValue, lerpSpeed);
                rendere1.color = finalColor;
                rendere2.color = finalColor;
            }
            if (Mathf.Abs(slide.value - finalValue) < 0.1f)
            {
                party1.Stop();
                party2.Stop();
                rendere1.color = initialColor1;
                rendere2.color = initialColor2;
                slide.value = finalValue;
                lerping = false;
            }
        }
    }
    void ChangeValue()
    {
        
        slide2.value = finalValue;
    }
}
