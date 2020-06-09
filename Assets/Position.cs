using System.Collections;
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
    private GameObject currentModel;

    public void SetCurrentModel(GameObject model)
    {
        currentModel = model;
        sliderX.value = model.transform.position.x;
        sliderY.value = model.transform.position.y;
        sliderZ.value = model.transform.position.z;
        inputFieldX.text = model.transform.position.x + "";
        inputFieldY.text = model.transform.position.y + "";
        inputFieldZ.text = model.transform.position.z + "";
    }
    // Update is called once per frame
    void Update()
    {
        
        if (currentModel != null && !currentModel.GetComponent<ModelObject>().isAnimating)
        {
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

    }
}
