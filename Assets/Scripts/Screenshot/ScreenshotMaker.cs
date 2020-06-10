using UnityEngine;

public class ScreenshotMaker : MonoBehaviour
{
    public Camera myCamera;
    public GameObject canvas;
    public CameraClick cameraClick;

    private MainManager mainManager;
    private bool takeScreenShotOnNextFrame;
    private int width;
    private int height;

    private string directoryPath;
    private void Start()
    {
        mainManager = MainManager.Instance;
        directoryPath = mainManager.GetOutputPath();
    }
    private void OnPostRender()
    {
        if (takeScreenShotOnNextFrame)
        {
            Texture2D myCamRenderResult = new Texture2D(width, height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, width, height);
            myCamRenderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = myCamRenderResult.EncodeToPNG();

            ScreenshotUploader.UploadScreenshot(directoryPath, byteArray);
            canvas.SetActive(true);
            takeScreenShotOnNextFrame = false;
        }
    }

    public void TakeScreenShot()
    {
        canvas.SetActive(false);
        width = Screen.width;
        height = Screen.height;
        cameraClick.gameObject.SetActive(true);
        cameraClick.MakeClick();
        takeScreenShotOnNextFrame = true;
    }
}
