using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{

    public ParticleSystem particles;

    private void Awake()
    {

        particles = GetComponent<ParticleSystem>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void emitParticlesInKey(int key)
    {

        particles.maxParticles = key;
        particles.Play(); 

    }

}
