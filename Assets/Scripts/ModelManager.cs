using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public static ModelManager Instance { get; private set; }

    public RotationTest rotationTester;
    public Transform parentOfmodels;
    public Material defaultMaterial;

    public Transform leftPoint;
    public Transform centerPoint;
    public Transform rightPoint;

    public GameObject buttons;
    public bool clearOutputFolder;

    private int currentIndex;
    private List<ModelObject> models = new List<ModelObject>();
    private string inputDirectoryPath = "Assets/Input/";
    private string outputDirectoryPath = "Assets/Output/";
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        models = ModelDownloader.DownloadModels(inputDirectoryPath, rightPoint, parentOfmodels, defaultMaterial);
        if (clearOutputFolder)
            ScreenshotUploader.ClearFolder(outputDirectoryPath);
        currentIndex = 0;
        models[currentIndex].ShowModelTo(centerPoint);
        rotationTester.SetCurrentModel(models[currentIndex].gameObject);
    }

    public void ShowNext()
    {
        if(currentIndex< models.Count - 1 )
        {
            buttons.SetActive(false);
            models[currentIndex].HideModelTo(leftPoint);
            currentIndex++;
            models[currentIndex].ShowModelTo(centerPoint);
            rotationTester.SetCurrentModel(models[currentIndex].gameObject);
        }
    }

    public void ShowPrevious()
    {
        if (currentIndex > 0)
        {
            buttons.SetActive(false);
            models[currentIndex].HideModelTo(rightPoint);
            currentIndex--;
            models[currentIndex].ShowModelTo(centerPoint);
            rotationTester.SetCurrentModel(models[currentIndex].gameObject);
        }
    }

    
}
