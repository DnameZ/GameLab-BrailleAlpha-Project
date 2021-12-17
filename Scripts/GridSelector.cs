using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GridSelector : MonoBehaviour
{
    Ray ray;
    RaycastHit Hit;

    public ParticleSystem particle;

    GameObject[] Grids;

    const string zero = "0";
    const string one = "1";
    const string two = "2";
    const string three = "3";
    const string four = "4";
    const string five = "5";

    GameObject gridSelected;
    GameObject PickedChild;

    const string Grid = "Grid";
    const string Picked = "Picked";

    [SerializeField] Material SelectedGrid;
    [SerializeField] Material DefaultGrid;

    LetterSelector selector;

    bool onGrid;
    bool canSwitchGrid = false;
    public bool[] canFire = new bool[6] { false, false, false, false, false, false };

    private void Start()
    {
        Grids = GameObject.FindGameObjectsWithTag(Grid);

        selector = FindObjectOfType<LetterSelector>();
    }


    private void Update()
    { 
        if(gridSelected!=null)
        {
            ChangeMaterial(gridSelected, DefaultGrid);

            gridSelected = null;
        }

        SetRayCast();
    }

    void SetLetter()
    {
        if(gridSelected !=null)
        {
           switch(gridSelected.name)
            {
                case zero:
                    selector.bools[0] = true;
                    gridSelected.transform.GetChild(0).gameObject.SetActive(true);
                    canFire[0] = true;
                break;

                case one:
                    selector.bools[1] = true;
                    gridSelected.transform.GetChild(0).gameObject.SetActive(true);
                    canFire[1] = true;
                    break;

                case two:
                    selector.bools[2] = true;
                    gridSelected.transform.GetChild(0).gameObject.SetActive(true);
                    canFire[2] = true;
                    break;

                case three:
                    selector.bools[3] = true;
                    gridSelected.transform.GetChild(0).gameObject.SetActive(true);
                    canFire[3] = true;
                    break;

                case four:
                    selector.bools[4] = true;
                    gridSelected.transform.GetChild(0).gameObject.SetActive(true);
                    canFire[4] = true;
                    break;


                case five:
                    selector.bools[5] = true;
                    gridSelected.transform.GetChild(0).gameObject.SetActive(true);
                    canFire[5] = true;
                    break;

            }
        }

        
    }

    void SetRayCast()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out Hit,Mathf.Infinity))
        {          
            if(Hit.collider.gameObject.CompareTag(Grid))
            {
                onGrid = true;

                gridSelected = Hit.collider.gameObject;
                if(gridSelected!=null)
                {
                    ChangeMaterial(gridSelected, SelectedGrid);
                }

                gridSelected = gridSelected;
            }
            else
            {
                onGrid = false;
            }

            while (onGrid)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SetLetter();
                }

                return;
            }
        }
    }

    Material ChangeMaterial (GameObject Object, Material mat) =>  Object.GetComponent<Renderer>().material = mat;
}
