using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RocketsFire : MonoBehaviour
{
    public GameObject succ;
    public GameObject Err;

    Alphabet alpha;
    GridSelector selector;
    LetterSelector selectorLetter;

    [SerializeField] ParticleSystem[] bombs;

    bool isRight;

    private void Start()
    {
        alpha = FindObjectOfType<Alphabet>();
        selector = FindObjectOfType<GridSelector>();

        selectorLetter = FindObjectOfType<LetterSelector>();

        for (int i = 0; i < bombs.Length; i++)
        {
            bombs[i].Stop();
        }
    }



    public void CanFire()
    {
        for (int i = 0; i < bombs.Length; i++)
        {
            for (int k = 0; k < selector.canFire.Length; k++)
            {
                if(selector.canFire[k]==true)
                {
                    bombs[k].Play();
                }
            }
        }

        if (selectorLetter.bools.SequenceEqual(alpha.letterObj[selectorLetter.PosOfLetter].br))
        {
            isRight = true;
        }
        else
         {
            isRight = false;
        }

        StartCoroutine(SetMessage());
    }

    IEnumerator SetMessage()
    {
        yield return new WaitForSeconds(3f);

        switch(isRight)
        {
            case(true):
                succ.SetActive(true);
                Err.SetActive(false);
            break;

            case (false):
                succ.SetActive(false);
                Err.SetActive(true);
            break;

        }
    }
}
