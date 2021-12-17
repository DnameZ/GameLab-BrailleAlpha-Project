using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alphabet : MonoBehaviour
{
    [System.Serializable]
    
    public class Letter
    {
        public bool[] br = new bool[6] { false, false, false, false, false, false };
    };

    public Sprite[] letters;
    public Letter[] letterObj;
}
