using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelObject : MonoBehaviour
{
    private float moveSpeed=1.5f;
    public void HideModelTo(Transform point)
    {
        StartCoroutine(MoveCoroutine(point));
    }

    public void ShowModelTo(Transform point)
    {
        StartCoroutine(MoveCoroutine(point));
    }
    IEnumerator MoveCoroutine(Transform targerPoint)
    {
        while (Vector3.Distance(transform.position, targerPoint.position)>0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, targerPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        //yield return new WaitForSeconds(1f);
    }
}
