using UnityEngine;
using UnityEngine.UI;

public class ScaleManager : MonoBehaviour
{
    public static ScaleManager Instance { get; private set; }

    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;
    public InputField inputFieldX;
    public InputField inputFieldY;
    public InputField inputFieldZ;
    public Toggle toggle;
    public bool isParametrSet;
    private GameObject currentModel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void SetCurrentModel(GameObject model)
    {
        currentModel = model;
        SetParametrs();

    }

    void Update()
    {
        if (currentModel != null && !currentModel.GetComponent<ModelObject>().isAnimating && toggle.isOn)
        {
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
        sliderX.value = 1;
        sliderY.value = 1;
        sliderZ.value = 1;
        inputFieldX.text = 1 + "";
        inputFieldY.text = 1 + "";
        inputFieldZ.text = 1 + "";
    }
}
