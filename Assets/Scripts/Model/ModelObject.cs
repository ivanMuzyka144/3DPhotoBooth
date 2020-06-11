using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelObject : MonoBehaviour
{
    private float moveSpeed=3f;
    private float alphaSpeed = 2f;
    private float currentAlpha = 0;

    public bool isAnimating;
    private bool isHiding;
    private Transform targerPoint;
    private float targetAlpha;
    private MainManager mainManager;
    private void Start()
    {
        mainManager = MainManager.Instance;
    }
   
    public void HideModelTo(Transform point)
    {
        isHiding = true;
        targerPoint = point;
        targetAlpha = 0;
        isAnimating = true;
    }

    public void ShowModelTo(Transform point)
    {
        isHiding = false;
        targerPoint = point;
        targetAlpha = 1;
        isAnimating = true;
    }
    
    private void Update()
    {
        if (isAnimating)
        {
            if (Vector3.Distance(transform.position, targerPoint.position) > 0.05f || Mathf.Abs(currentAlpha - targetAlpha) > 0.1f)
            {
                ChangeAlpha();
                Color modelColor = GetComponent<MeshRenderer>().material.color;
                GetComponent<MeshRenderer>().material.color = new Color(modelColor.r, modelColor.g, modelColor.b, currentAlpha);
                transform.position = Vector3.Lerp(transform.position, targerPoint.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                Color modelColor = GetComponent<MeshRenderer>().material.color;
                GetComponent<MeshRenderer>().material.color = new Color(modelColor.r, modelColor.g, modelColor.b, targetAlpha);
                if (!isHiding)
                {
                    mainManager.EnableButtons();
                }
                else
                {
                    ClearObject();
                }
                isAnimating = false;
            }
        }
    }

    private void ChangeAlpha()
    {
        if (currentAlpha > targetAlpha)
        {
            currentAlpha -= alphaSpeed * Time.deltaTime;
        }
        else
        {
            currentAlpha += alphaSpeed * Time.deltaTime;
        }
    }
    private void ClearObject()
    {
        transform.localRotation =  Quaternion.Euler(0, 0, 0);
        transform.localScale = new Vector3(1,1,1);
    }
}
