using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ModelDownloader
{ 
    private static string[] possibleExtensions = { ".obj"};

    public static List<ModelObject> DownloadModels(string directoryPath,Transform positionOfModel, Transform parentOfmodels, Material defaultMaterial)
    {
        //DownloadToResouces();
        List<ModelObject> listOfModels = new List<ModelObject>();
        DirectoryInfo info = new DirectoryInfo(directoryPath);
        FileInfo[] fileInfo = info.GetFiles();

        ObjImporter objImporter = new ObjImporter();
        foreach (FileInfo file in fileInfo) 
        {
            if (possibleExtensions.Contains(file.Extension))
            {
                Mesh myMesh = objImporter.ImportFile(directoryPath+ file.Name);
                GameObject newObj = new GameObject(file.Name.Replace(file.Extension,""));
                newObj.AddComponent<MeshFilter>();
                newObj.AddComponent<MeshRenderer>();
                newObj.GetComponent<MeshFilter>().mesh = myMesh;
                newObj.GetComponent<MeshRenderer>().material = defaultMaterial;
                newObj.GetComponent<MeshRenderer>().material.color = new Color(defaultMaterial.color.r, defaultMaterial.color.g, defaultMaterial.color.b, 0);
                newObj.transform.position = positionOfModel.position;
                newObj.transform.parent = parentOfmodels;
                newObj.AddComponent<ModelObject>();

                listOfModels.Add(newObj.GetComponent<ModelObject>());
            }
        }
        return listOfModels;
    }
}
