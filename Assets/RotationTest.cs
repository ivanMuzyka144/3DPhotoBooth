using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationTest : MonoBehaviour
{
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;
    private GameObject currentModel;

    private float rotationSpeed = 7;
    public void Start()
    {
    }
    public void SetCurrentModel(GameObject model)
    {
        currentModel = model;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentModel != null)
        {
            if (sliderX.value == 1)
            {
                Quaternion QT = currentModel.transform.rotation * Quaternion.Inverse(Quaternion.AngleAxis(5, Vector3.right));
                currentModel.transform.rotation = Quaternion.Lerp(currentModel.transform.rotation, QT, rotationSpeed * Time.deltaTime);
            }
            else if (sliderX.value == -1)
            {
                Quaternion QT = currentModel.transform.rotation * Quaternion.AngleAxis(5, Vector3.right);
                currentModel.transform.rotation = Quaternion.Lerp(currentModel.transform.rotation, QT, rotationSpeed * Time.deltaTime);
            }
            if (sliderY.value==1)
            {
                Quaternion QT = currentModel.transform.rotation * Quaternion.Inverse(Quaternion.AngleAxis(5, Vector3.up));
                currentModel.transform.rotation = Quaternion.Lerp(currentModel.transform.rotation, QT, rotationSpeed * Time.deltaTime);
            }
            else if (sliderY.value == -1) 
            {
                Quaternion QT = currentModel.transform.rotation * Quaternion.AngleAxis(5, Vector3.up);
                currentModel.transform.rotation = Quaternion.Lerp(currentModel.transform.rotation, QT, rotationSpeed * Time.deltaTime);
            }
            if (sliderZ.value == 1)
            {
                Quaternion QT = currentModel.transform.rotation * Quaternion.Inverse(Quaternion.AngleAxis(5, Vector3.forward));
                currentModel.transform.rotation = Quaternion.Lerp(currentModel.transform.rotation, QT, rotationSpeed * Time.deltaTime);
            }
            else if (sliderZ.value == -1)
            {
                Quaternion QT = currentModel.transform.rotation * Quaternion.AngleAxis(5, Vector3.forward);
                currentModel.transform.rotation = Quaternion.Lerp(currentModel.transform.rotation, QT, rotationSpeed * Time.deltaTime);
            }
        }
        

    }
}
