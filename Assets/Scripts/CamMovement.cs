using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public GameObject playerObj;

    public float sensivity = 2.0f;

    private float horizontalRot = 0.0f;
    private float verticalRot = 0.0f;

    public float verticalLimit = 40;
    
    void Start()
    {

    }

    void Update()
    {
        float axisHorizontal = Input.GetAxis("Mouse Y");
        float axisVertical = Input.GetAxis("Mouse X");

        verticalRot += (-axisHorizontal*sensivity);
        horizontalRot += axisVertical*sensivity;

        verticalRot = Mathf.Clamp(verticalRot, -verticalLimit, verticalLimit);

        playerObj.transform.eulerAngles = new Vector3(playerObj.transform.eulerAngles.x, horizontalRot, 0);

        transform.eulerAngles = new Vector3(verticalRot, transform.eulerAngles.y, 0);
    }
}
