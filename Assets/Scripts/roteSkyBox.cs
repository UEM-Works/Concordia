using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class roteSkyBox : MonoBehaviour
{
    //public Skybox cielo;
    //float rotate;
    //private void Start()
    //{
    //    rotate = Skybox
    //}
    //private void Update()
    //{
    //    rotate = rotate + 0.001f;
    //}

    public float RotateSpeed = 0.001f;

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotateSpeed);
    }
}
