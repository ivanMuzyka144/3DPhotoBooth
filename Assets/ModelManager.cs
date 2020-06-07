using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public GameObject parentOfmodels;
    public Material defaultMaterial;

    public Transform leftPoint;
    public Transform centerPoint;
    public Transform rightPoint;

    private int currentIndex;
    private List<GameObject> models = new List<GameObject>();
    private string directoryPath = "Assets/Input/";
    void Start()
    {
        models = ModelUploader.UploadModels(directoryPath, parentOfmodels, defaultMaterial);
        currentIndex = 0;
    }

    void Update()
    {
        
    }
}
