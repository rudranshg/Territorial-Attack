using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleeffects : MonoBehaviour
{
    public ParticleSystem health ;
    public ParticleSystem thunder;
    

    public void healtheffect()
    {
        health.Play();
    }
    public void thundereffect()
    {
        thunder.Play();
    }

}
