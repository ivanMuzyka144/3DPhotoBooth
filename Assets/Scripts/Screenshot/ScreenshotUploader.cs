using System;
using System.IO;
using System.Linq;

public class ScreenshotUploader 
{
    public static void ClearFolder(string path)
    {
        DirectoryInfo info = new DirectoryInfo(path);
        foreach (FileInfo file in info.GetFiles())
        {
            file.Delete();
        }
    }

    public static void UploadScreenshot(string path, byte[] byteArray)
    {
        File.WriteAllBytes(path + GenerateName(path), byteArray);
    }

    private static string GenerateName(string path)
    {
        int returnIndex=0;
        DirectoryInfo info = new DirectoryInfo(path);
        FileInfo[] files = info.GetFiles();

        if (files.Count() != 0)
        {
            foreach (FileInfo fileInfo in files)
            {
                if (fileInfo.Name.StartsWith("ScreenShot"))
                {
                    int index =int.Parse(fileInfo.Name.Replace("ScreenShot", "").Replace(".png", ""));
                    if (index > returnIndex)
                    {
                        returnIndex = index;
                    }
                }
            }
            returnIndex++;
            return "ScreenShot"+returnIndex+".png";
        }
        else
        {
            return "ScreenShot1.png";
        }
    }
}
