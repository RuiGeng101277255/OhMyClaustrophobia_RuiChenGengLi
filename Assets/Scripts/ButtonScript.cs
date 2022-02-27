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

    public Light ButtonLight;

    private bool isOpen = false;
    private bool isOverlapping = false;
    private bool cageOpen = false;

    private MeshRenderer buttonMeshR;

    // Start is called before the first frame update
    void Start()
    {
        buttonMeshR = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInstructionText();
        UpdateCageRotation();
        UpdateColor();
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

    void UpdateColor()
    {
        if (isOpen)
        {
            if (ButtonLight.color == Color.red)
            {
                ButtonLight.color = Color.green;
            }

            if (buttonMeshR.material == redButtonMaterial)
            {
                buttonMeshR.material = greenButtonMaterial;
            }
        }
        else
        {
            if (ButtonLight.color == Color.green)
            {
                ButtonLight.color = Color.red;
            }

            if (buttonMeshR.material == greenButtonMaterial)
            {
                buttonMeshR.material = redButtonMaterial;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) isOverlapping = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) isOverlapping = false;
    }
}
