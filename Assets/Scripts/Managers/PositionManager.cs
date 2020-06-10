using UnityEngine;
using UnityEngine.UI;

public class PositionManager : MonoBehaviour
{
    public static PositionManager Instance { get; private set; }

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
        sliderX.value = 0;
        sliderY.value = 0;
        sliderZ.value = 0;
        inputFieldX.text = 0 + "";
        inputFieldY.text = 0 + "";
        inputFieldZ.text = 0 + "";
    }

}
