﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Position : MonoBehaviour
{
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;
    public InputField inputFieldX;
    public InputField inputFieldY;
    public InputField inputFieldZ;
    public Toggle toggle;
    public bool isParametrSet;
    private GameObject currentModel;

    public void SetCurrentModel(GameObject model)
    {
        currentModel = model;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (currentModel != null && !currentModel.GetComponent<ModelObject>().isAnimating && toggle.isOn)
        {
            if (!isParametrSet)
            {
                SetParametrs();
            }
            float valueX = sliderX.value;
            inputFieldX.text = valueX + "";
            currentModel.transform.localPosition = new Vector3(valueX,currentModel.transform.localPosition.y, currentModel.transform.localPosition.z);
            float valueY = sliderY.value;
            inputFieldY.text = valueY + "";
            currentModel.transform.localPosition = new Vector3(currentModel.transform.localPosition.x, valueY, currentModel.transform.localPosition.z);
            float valueZ = sliderZ.value;
            inputFieldZ.text = valueZ + "";
            currentModel.transform.localPosition = new Vector3(currentModel.transform.localPosition.x, currentModel.transform.localPosition.y, valueZ);
        }

    }
    public void SetParametrs()
    {
        sliderX.value = currentModel.transform.position.x;
        sliderY.value = currentModel.transform.position.y;
        sliderZ.value = currentModel.transform.position.z;
        inputFieldX.text = currentModel.transform.position.x + "";
        inputFieldY.text = currentModel.transform.position.y + "";
        inputFieldZ.text = currentModel.transform.position.z + "";
        isParametrSet = true;
    }

    public void Disable(bool value)
    {
        if (value == false)
            isParametrSet = false;
    }
}
