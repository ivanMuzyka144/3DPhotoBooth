using UnityEngine;
using UnityEngine.UI;

public class Toggles : MonoBehaviour
{
    public Toggle togggle1;
    public Toggle togggle2;
    public Toggle togggle3;
    public Toggle togggle4;
    public GameObject buttons;
    void Start()
    {
        togggle1.onValueChanged.AddListener((value) => { ChangeOtherToggles1(value); });
        togggle2.onValueChanged.AddListener((value) => { ChangeOtherToggles2(value); });
        togggle3.onValueChanged.AddListener((value) => { ChangeOtherToggles3(value); });
        togggle4.onValueChanged.AddListener((value) => { ChangeOtherToggles4(value); });
    }

    void ChangeOtherToggles1(bool value)
    {
        if (value == true)
        {
            togggle2.isOn = false;
            togggle3.isOn = false;
            togggle4.isOn = false;
            buttons.SetActive(true);
        }
    }
    void ChangeOtherToggles2(bool value)
    {
        if (value == true)
        {
            togggle1.isOn = false;
            togggle3.isOn = false;
            togggle4.isOn = false;
            buttons.SetActive(false);
        }
    }
    void ChangeOtherToggles3(bool value)
    {
        if (value == true)
        {
            togggle1.isOn = false;
            togggle2.isOn = false;
            togggle4.isOn = false;
            buttons.SetActive(false);
        }
    }
    void ChangeOtherToggles4(bool value)
    {
        if (value == true)
        {
            togggle1.isOn = false;
            togggle2.isOn = false;
            togggle3.isOn = false;
            buttons.SetActive(false);
        }
    }
}
