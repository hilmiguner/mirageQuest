using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixMovement : MonoBehaviour
{
    private Vector3 sourcePos;
    public Transform target;
    public float lerpValue = 0f;

    public bool canPhoenixMove = false;
    private bool isSourceTaken = false;
    public bool isLerpMax = false;

    public bool isAstraAttached = false;
    public bool isAstraHasHold = false;
    public bool isPhoenixHigh = false;
    public bool hasEnteredHigh = false;

    public Vector3 instantPosition;

    public OutOfMapCheck oomc;
    public GameObject astra;
    public CharacterMovement cm;
    public DropZone dz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canPhoenixMove) {
            if(!isSourceTaken) {
                isSourceTaken = true;
                sourcePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            moveItTo(sourcePos);
            if(isAstraHasHold && transform.position.y > 145 && !hasEnteredHigh) {
                hasEnteredHigh = true;
                lerpValue = 1;
                isPhoenixHigh = true;
                transform.position = new Vector3(transform.position.x, 150f, transform.position.z);
            }
            if(!isLerpMax) {
                lerpValue += 0.004f;
            }
        }
        if(lerpValue >= 1) {
            isLerpMax = true;
            lerpValue = 0;
            isSourceTaken = false;
            if(isAstraHasHold && dz.hasEnteredDropZone) {
                lerpValue = 1f;
                isAstraHasHold = false;
                cm.isFrozen = false;
                isLerpMax = false;
                oomc.isAstraEnteredFog = false;
                dz.hasEnteredDropZone = false;
                hasEnteredHigh = false;
            }
            if(isAstraHasHold && isPhoenixHigh) {
                isPhoenixHigh = false;
                lerpValue = 0f;
                target.position = new Vector3(-2.71f, 120f, 30.0f);
                isLerpMax = false;
                hasEnteredHigh = true;
            }
            if(isAstraAttached) {
                lerpValue = 0f;
                isAstraHasHold = true;
                isLerpMax = false;
                isAstraAttached = false;
                target.position = new Vector3(transform.position.x, 150, transform.position.z);
            }
        }
    }

    public void moveItTo(Vector3 source) {
        instantPosition = Vector3.Lerp(source, target.position, lerpValue);
        transform.position = instantPosition;
        if(isAstraHasHold) {
            astra.transform.position = new Vector3(instantPosition.x, instantPosition.y - 2f, instantPosition.z);
        }
    }
}
