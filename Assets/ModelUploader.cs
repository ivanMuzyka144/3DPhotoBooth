using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ModelUploader : MonoBehaviour
{
    public Material material;
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
        var go = AssetDatabase.LoadAssetAtPath("Assets/Input/box.fbx", typeof(GameObject));
        Debug.Log(go);
        GameObject newGo = go as GameObject;
        GameObject.Instantiate(newGo);
        //new GameObject("Empty");
        //object.GetComponent(MeshFilter).mesh = myMesh;
        //GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
