using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LetterSelector : MonoBehaviour
{
    Alphabet alpha;

    Image curImage;

    Sprite spriteToUpload;

    public bool[] bools;

    public int PosOfLetter;

    // Start is called before the first frame update
    void Start()
    {

        alpha = FindObjectOfType<Alphabet>();

        PosOfLetter = GetRandomNumber();

        spriteToUpload = alpha.letters[PosOfLetter];

        curImage = gameObject.GetComponent<Image>();

        curImage.sprite = spriteToUpload;
    }


    int GetRandomNumber()
    {
        int randomNum;

        randomNum = Random.RandomRange(0, 34);

        return randomNum;
    }


}
