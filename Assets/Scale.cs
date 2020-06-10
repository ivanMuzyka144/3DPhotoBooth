using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scale : MonoBehaviour
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
            currentModel.transform.localScale = new Vector3(valueX,currentModel.transform.localScale.y, currentModel.transform.localScale.z);
            float valueY = sliderY.value;
            inputFieldY.text = valueY + "";
            currentModel.transform.localScale = new Vector3(currentModel.transform.localScale.x, valueY, currentModel.transform.localScale.z);
            float valueZ = sliderZ.value;
            inputFieldZ.text = valueZ + "";
            currentModel.transform.localScale = new Vector3(currentModel.transform.localScale.x, currentModel.transform.localScale.y, valueZ);
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
