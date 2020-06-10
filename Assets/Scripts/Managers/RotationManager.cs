using UnityEngine;
using UnityEngine.UI;

public class RotationManager : MonoBehaviour
{
    public static RotationManager Instance { get; private set; }

    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;
    private GameObject currentModel;

    private float rotationSpeed = 7;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void SetCurrentModel(GameObject model)
    {
        currentModel = model;
    }

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
