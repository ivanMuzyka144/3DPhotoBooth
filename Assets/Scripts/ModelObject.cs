using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelObject : MonoBehaviour
{
    private float moveSpeed=1.5f;
    private float alphaSpeed = 1.5f;
    private float currentAlpha = 0;
    public void SetCurrentColor(Color color)
    {
       // currentColor = currentColor;
    }
    public void HideModelTo(Transform point)
    {
        StartCoroutine(MoveCoroutine(point,0));
    }

    public void ShowModelTo(Transform point)
    {
        StartCoroutine(MoveCoroutine(point, 1));
    }
    IEnumerator MoveCoroutine(Transform targerPoint, float targetAlpha)
    {
        while (Vector3.Distance(transform.position, targerPoint.position)>0.1f
               || Mathf.Abs(currentAlpha - targetAlpha) > 0.01f)
        {
            if(currentAlpha> targetAlpha)
            {
                currentAlpha -= alphaSpeed * Time.deltaTime;
            }
            else
            {
                currentAlpha += alphaSpeed * Time.deltaTime;
            }
            SetAlphaToChildren(currentAlpha);
            transform.position = Vector3.Lerp(transform.position, targerPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        //yield return new WaitForSeconds(1f);
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
