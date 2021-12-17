using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        DestroyObject(other);
    }
}
