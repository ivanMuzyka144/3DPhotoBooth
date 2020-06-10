using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public bool clearOutputFolder;
    public GameObject buttons;
    public Toggle mainToggle;

    public Transform startPoint;

    public Transform parentOfmodels;
    public Material defaultMaterial;

    private ModelManager modelManager;
    private RotationManager rotationManager;
    private PositionManager positionManager;
    private ScaleManager scaleManager;

    private string inputDirectoryPath = "Assets/Resources/";
    private string outputDirectoryPath = "Assets/Output/";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        //Directory.CreateDirectory(Application.streamingAssetsPath + "/Test");
        modelManager = ModelManager.Instance;
        rotationManager = RotationManager.Instance;
        positionManager = PositionManager.Instance;
        scaleManager = ScaleManager.Instance;

        modelManager.SetModels( ModelDownloader.DownloadModels(inputDirectoryPath, startPoint, parentOfmodels, defaultMaterial));
        if (clearOutputFolder)
            ScreenshotUploader.ClearFolder(outputDirectoryPath);
        ModelObject modelObj = modelManager.GetCurrentModelObject();
        rotationManager.SetCurrentModel(modelObj.gameObject);
        positionManager.SetCurrentModel(modelObj.gameObject);
        scaleManager.SetCurrentModel(modelObj.gameObject);
    }

    public void ShowNext()
    {
        bool canShow = modelManager.ShowNext();
        if (canShow)
        {
            buttons.SetActive(false);
            ModelObject modelObj = modelManager.GetCurrentModelObject();
            rotationManager.SetCurrentModel(modelObj.gameObject);
            positionManager.SetCurrentModel(modelObj.gameObject);
            scaleManager.SetCurrentModel(modelObj.gameObject);
        }
    }

    public void ShowPrevious()
    {
        bool canShow = modelManager.ShowPrevious();
        if (canShow)
        {
            buttons.SetActive(false);
            ModelObject modelObj = modelManager.GetCurrentModelObject();
            rotationManager.SetCurrentModel(modelObj.gameObject);
            positionManager.SetCurrentModel(modelObj.gameObject);
            scaleManager.SetCurrentModel(modelObj.gameObject);
        }
    }

    public string GetOutputPath()
    {
        return outputDirectoryPath;
    }

    public void EnableButtons()
    {
        if(mainToggle.isOn)
            buttons.SetActive(true);
    }
}
