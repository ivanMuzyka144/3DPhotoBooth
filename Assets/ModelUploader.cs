using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;

public class ModelUploader : MonoBehaviour
{
    public Material defaultMaterial;
    public GameObject parent;
    public GameObject sizeCube;
    public GameObject egg;

    private string[] possibleExtensions = { ".obj", ".FBX" };
    void Start()
    {
        //Mesh myMesh = (Mesh)Resources.Load("Assets/Input/rabbir", typeof(Mesh));

        /*
        Object object = AssetDatabase.LoadAssetAtPath("Assets/Input/rabbir.obj", typeof(Object));
        Mesh t = (Mesh)AssetDatabase.LoadAssetAtPath("Assets/Input/rabbir.obj", typeof(Mesh));
        GameObject mygameobject = new GameObject();
        mygameobject.AddComponent<MeshFilter>();
        mygameobject.AddComponent<MeshRenderer>();
        mygameobject.GetComponent<MeshFilter>().mesh = t;
        mygameobject.GetComponent<MeshRenderer>().material = material;
        */
        List<GameObject> listOfModels = new List<GameObject>();
        DirectoryInfo info = new DirectoryInfo("Assets/Input/");
        FileInfo[] fileInfo = info.GetFiles();
        foreach (FileInfo file in fileInfo) 
        {
            if (possibleExtensions.Contains(file.Extension))
            {
                var go = AssetDatabase.LoadAssetAtPath("Assets/Input/" + file.Name, typeof(GameObject));
                GameObject newObj = GameObject.Instantiate(go as GameObject, parent.transform);
                listOfModels.Add(newObj);
                for (int i = 0; i < newObj.transform.childCount; i++)
                {
                    GameObject child = newObj.transform.GetChild(i).gameObject;
                    child.GetComponent<Renderer>().material = defaultMaterial;
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
