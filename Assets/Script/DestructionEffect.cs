using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionEffect : MonoBehaviour
{
    public GameObject effect;
    public Transform spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void EffectSpawn()
    {
       /*GameObject spawn = */Instantiate(effect, spawnPos.position, transform.rotation);
       //spawn.transform.position += new Vector3(0, transform.localPosition.y + 1.5f,0f);
    }
}
