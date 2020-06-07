using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public Transform parentOfmodels;
    public Material defaultMaterial;

    public Transform leftPoint;
    public Transform centerPoint;
    public Transform rightPoint;

    private int currentIndex;
    private List<ModelObject> models = new List<ModelObject>();
    private string directoryPath = "Assets/Input/";
    void Start()
    {
        models = ModelUploader.UploadModels(directoryPath, rightPoint, parentOfmodels, defaultMaterial);
        currentIndex = 0;
        models[currentIndex].ShowModelTo(centerPoint);
    }

    public void ShowNext()
    {
        if(currentIndex< models.Count - 1)
        {
            models[currentIndex].HideModelTo(leftPoint);
            currentIndex++;
            models[currentIndex].ShowModelTo(centerPoint);
        }
    }

    public void ShowPrevious()
    {
        if (currentIndex > 0)
        {
            models[currentIndex].HideModelTo(rightPoint);
            currentIndex--;
            models[currentIndex].ShowModelTo(centerPoint);
        }
    }

    void Update()
    {
        
    }
}
