using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 touch;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2)
        {
            Touch fingerOne = Input.GetTouch(0);
            Touch fingerTwo = Input.GetTouch(1);

            Vector2 oldPositionFingerOne = fingerOne.position - fingerOne.deltaPosition;
            Vector2 oldPositionFingerTwo = fingerTwo.position - fingerTwo.deltaPosition;

            //magnatude (length between the who fingers)
            float oldMagnatude = (oldPositionFingerOne - oldPositionFingerTwo).magnitude;
            float Magnatude = (fingerOne.position - fingerTwo.position).magnitude;

            float spaceBetween = oldMagnatude - Magnatude;
            float camZoom = Mathf.Clamp((Camera.main.orthographicSize += (spaceBetween * 0.01f)), 1, 15);
            Camera.main.orthographicSize = camZoom;
        } else if (Input.GetMouseButton(0))
        {
            Camera.main.transform.position = touch;
            Vector3 direction = touch - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
    }
}
