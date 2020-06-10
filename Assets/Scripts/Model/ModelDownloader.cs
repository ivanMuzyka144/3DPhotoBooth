using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ModelDownloader
{ 
    private static string[] possibleExtensions = { ".obj", ".FBX", ".3ds" };

    public static List<ModelObject> DownloadModels(string directoryPath,Transform positionOfModel, Transform parentOfmodels, Material defaultMaterial)
    {
        //DownloadToResouces();
        List<ModelObject> listOfModels = new List<ModelObject>();
        DirectoryInfo info = new DirectoryInfo(directoryPath);
        FileInfo[] fileInfo = info.GetFiles();
        foreach (FileInfo file in fileInfo) 
        {
            if (possibleExtensions.Contains(file.Extension))
            {
                var go = Resources.Load(file.Name.Replace(file.Extension,"")) as GameObject;
                GameObject newObj = GameObject.Instantiate(go as GameObject, parentOfmodels);
                newObj.transform.position = positionOfModel.position;
                newObj.AddComponent<ModelObject>();
                listOfModels.Add(newObj.GetComponent<ModelObject>());
                for (int i = 0; i < newObj.transform.childCount; i++)
                {
                    GameObject child = newObj.transform.GetChild(i).gameObject;
                    child.GetComponent<MeshRenderer>().material = defaultMaterial;
                    child.GetComponent<MeshRenderer>().material.color = new Color(defaultMaterial.color.r, defaultMaterial.color.g, defaultMaterial.color.b, 0);
                }
            }
        }
        return listOfModels;
    }

    private static void DownloadToResouces()
    {
        DirectoryInfo info = new DirectoryInfo(Application.streamingAssetsPath + "/Input");
        FileInfo[] fileInfo = info.GetFiles();
        foreach (FileInfo file in fileInfo)
        {
            File.Copy(Application.streamingAssetsPath + "/Input/" + file.Name, "Assets/Resources/new" + file.Name);
        }
    }
}
