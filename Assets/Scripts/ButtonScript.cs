using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public Material redButtonMaterial;
    public Material greenButtonMaterial;

    public TMP_Text TextInstruction;

    public GameObject CageObject;

    private bool isOpen = false;
    private bool isOverlapping = false;
    private bool cageOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInstructionText();
        UpdateCageRotation();
    }

    void UpdateInstructionText()
    {
        if (!isOpen)
        {
            if (isOverlapping)
            {
                TextInstruction.gameObject.SetActive(true);
            }
            else
            {
                TextInstruction.gameObject.SetActive(false);
            }
        }
        else
        {
            TextInstruction.gameObject.SetActive(false);
        }
    }

    void UpdateCageRotation()
    {
        if(!cageOpen)
        {

        }
    }
}
