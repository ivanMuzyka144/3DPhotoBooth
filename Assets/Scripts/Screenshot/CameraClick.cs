using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraClick : MonoBehaviour
{
    public Image whiteImage;

    private bool canAnimate;
    private float animationSpeed=1;
   
    public void MakeClick()
    {
        whiteImage.color = new Color(1, 1, 1, 1);
        GetComponent<AudioSource>().Play();
        canAnimate = true;
    }
    void Update()
    {
        if (canAnimate)
        {
            if (whiteImage.color.a > 0.1f)
            {
                whiteImage.color = new Color(1, 1, 1, whiteImage.color.a- animationSpeed* Time.deltaTime);
            }
            else
            {
                canAnimate = false;
                gameObject.SetActive(false);
            }
        }
    }
}
