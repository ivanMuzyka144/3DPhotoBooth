using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;

public class ModelUploader
{ 
    private static string[] possibleExtensions = { ".obj", ".FBX" };

    public static List<GameObject> UploadModels(string directoryPath, GameObject parentOfmodels, Material defaultMaterial)
    {
        
        List<GameObject> listOfModels = new List<GameObject>();
        DirectoryInfo info = new DirectoryInfo(directoryPath);
        FileInfo[] fileInfo = info.GetFiles();
        foreach (FileInfo file in fileInfo) 
        {
            if (possibleExtensions.Contains(file.Extension))
            {
                var go = AssetDatabase.LoadAssetAtPath(directoryPath + file.Name, typeof(GameObject));
                GameObject newObj = GameObject.Instantiate(go as GameObject, parentOfmodels.transform);
                listOfModels.Add(newObj);
                for (int i = 0; i < newObj.transform.childCount; i++)
                {
                    GameObject child = newObj.transform.GetChild(i).gameObject;
                    child.GetComponent<Renderer>().material = defaultMaterial;
                }
            }
        }
        return listOfModels;
    }
}
