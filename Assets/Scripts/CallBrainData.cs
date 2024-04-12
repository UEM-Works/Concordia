using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmotivUnityPlugin;

public class CallBrainData : MonoBehaviour
{
    EmotivUnityItf _CDeItf;

    public string CDMentalComand;
    public bool push, pull, right, left, happyface, ungryface, uglyface, neutralface;



    public GameObject objectToChangeColor;

    private Renderer objectRenderer;
    private Color targetColor = Color.red;

    void Start()
    {
        _CDeItf = FindObjectOfType<SimpleExample>()._eItf;

        objectRenderer = objectToChangeColor.GetComponent<Renderer>();
    }
    // Update is called once per frame
    private void Update()
    {
        CDMentalComand = _CDeItf.MentalComandName;

        Debug.Log($"JAIME MIRA EL COMANDO MENTAL ACTUAL ES {CDMentalComand}");

        if (CDMentalComand == "push")
        {
                // Cambia el color del objeto a rojo
                objectRenderer.material.color = targetColor;
        }
    }

    public void CallBrianData()
    {
        //ConcordiaDataMaster.SafeDataEvent.Invoke();
    }
}
