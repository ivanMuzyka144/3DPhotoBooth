using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public static ModelManager Instance { get; private set; }

    public Transform leftPoint;
    public Transform centerPoint;
    public Transform rightPoint;

    private int currentIndex;
    private List<ModelObject> models = new List<ModelObject>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    

    public void SetModels(List<ModelObject> newModels)
    {
        models = newModels;
        currentIndex = 0;
        models[currentIndex].ShowModelTo(centerPoint);
    }

    public ModelObject GetCurrentModelObject()
    {
        return models[currentIndex];
    }
    public bool ShowNext()
    {
        if(currentIndex< models.Count - 1 )
        {
            models[currentIndex].HideModelTo(leftPoint);
            currentIndex++;
            models[currentIndex].ShowModelTo(centerPoint);
            return true;
        }
        return false;
    }

    public bool ShowPrevious()
    {
        if (currentIndex > 0)
        {
            models[currentIndex].HideModelTo(rightPoint);
            currentIndex--;
            models[currentIndex].ShowModelTo(centerPoint);
            return true;
        }
        return false;
    }

    
}
