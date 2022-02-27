using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public TMP_Text TextInstruction;

    public GameObject CageObject;

    public Light ButtonLight;

    public AudioSource ClickSFX;
    public AudioSource CageHumSFX;

    private bool isOpen = false;
    private bool isOverlapping = false;
    private bool cageOpen = false;

    private MeshRenderer buttonMeshR;

    // Start is called before the first frame update
    void Start()
    {
        buttonMeshR = GetComponent<MeshRenderer>();
        buttonMeshR.material.color = Color.red;
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
        if (isOpen)
        {
            if (!cageOpen)
            {
                if (CageObject.transform.rotation.x < 0.0f)
                {
                    CageObject.transform.rotation *= Quaternion.Euler(0.25f, 0.0f, 0.0f);

                    if (!CageHumSFX.isPlaying) CageHumSFX.Play();
                }
                else
                {
                    cageOpen = true;

                    if (CageHumSFX.isPlaying) CageHumSFX.Stop();
                }
            }
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

            if (buttonMeshR.material.color == Color.red)
            {
                buttonMeshR.material.color = Color.green;
            }
        }
        else
        {
            if (ButtonLight.color == Color.green)
            {
                ButtonLight.color = Color.red;
            }

            if (buttonMeshR.material.color == Color.green)
            {
                buttonMeshR.material.color = Color.red;
            }
        }
    }

    public void OpenCage()
    {
        if (isOverlapping)
        {
            isOpen = true;
            ClickSFX.Play();
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
