﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotMaker : MonoBehaviour
{
    public Camera myCamera;
    public GameObject canvas;
    private bool takeScreenShotOnNextFrame;
    int width;
    int height;

    private string directoryPath = "Assets/Output/";
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
        takeScreenShotOnNextFrame = true;
    }
}
