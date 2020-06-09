using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public static ModelManager Instance { get; private set; }

    public Transform parentOfmodels;
    public Material defaultMaterial;

    public Transform leftPoint;
    public Transform centerPoint;
    public Transform rightPoint;

    public GameObject buttons;
    public bool isFirstObjEnd;
    public bool isSecondObjEnd;

    private int currentIndex;
    private List<ModelObject> models = new List<ModelObject>();
    private string directoryPath = "Assets/Input/";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        models = ModelUploader.UploadModels(directoryPath, rightPoint, parentOfmodels, defaultMaterial);
        currentIndex = 0;
        models[currentIndex].ShowModelTo(centerPoint);
    }

    public void ShowNext()
    {
        if(currentIndex< models.Count - 1 )//&& isFirstObjEnd & isSecondObjEnd)
        {
            buttons.SetActive(false);
            isFirstObjEnd = false;
            isSecondObjEnd = false;
            models[currentIndex].HideModelTo(leftPoint);
            currentIndex++;
            models[currentIndex].ShowModelTo(centerPoint);
        }
    }

    public void ShowPrevious()
    {
        if (currentIndex > 0)// && isFirstObjEnd && isSecondObjEnd)
        {
            buttons.SetActive(false);
            isFirstObjEnd = false;
            isSecondObjEnd = false;
            models[currentIndex].HideModelTo(rightPoint);
            currentIndex--;
            models[currentIndex].ShowModelTo(centerPoint);
        }
    }

    
}
