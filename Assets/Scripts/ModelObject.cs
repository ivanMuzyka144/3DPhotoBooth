using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelObject : MonoBehaviour
{
    private float moveSpeed=3f;
    private float alphaSpeed = 2f;
    private float currentAlpha = 0;

    private bool canAnimate;
    private bool isHiding;
    private Transform targerPoint;
    private float targetAlpha;
    private ModelManager modelManager;
    private void Start()
    {
        modelManager = ModelManager.Instance;
    }
   
    public void HideModelTo(Transform point)
    {
        isHiding = true;
        targerPoint = point;
        targetAlpha = 0;
        canAnimate = true;
    }

    public void ShowModelTo(Transform point)
    {
        isHiding = false;
        targerPoint = point;
        targetAlpha = 1;
        canAnimate = true;
    }
    
    private void Update()
    {
        if (canAnimate)
        {
            if (Vector3.Distance(transform.position, targerPoint.position) > 0.1f || Mathf.Abs(currentAlpha - targetAlpha) > 0.01f)
            {
                if (currentAlpha > targetAlpha)
                {
                    currentAlpha -= alphaSpeed * Time.deltaTime;
                }
                else
                {
                    currentAlpha += alphaSpeed * Time.deltaTime;
                }
                SetAlphaToChildren(currentAlpha);
                transform.position = Vector3.Lerp(transform.position, targerPoint.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                if (isHiding)
                {
                    ModelManager.Instance.buttons.SetActive(true);
                }
                canAnimate = false;
            }
        }
    }

    private void SetAlphaToChildren(float alphaValue)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            Color childColor = child.GetComponent<MeshRenderer>().material.color;
            child.GetComponent<MeshRenderer>().material.color = new Color(childColor.r, childColor.g, childColor.b, alphaValue);
        }
    }

}
