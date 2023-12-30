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

    public ElfTalkScript etc;
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
            lerpValue += 0.003f;
        }
        if(lerpValue >= 1) {
            canPhoenixMove = false;
            lerpValue = 0;
            isSourceTaken = false;
            etc.startSecondTalk();
        }
    }

    public void moveItTo(Vector3 source) {
        transform.position = Vector3.Lerp(source, target.position, lerpValue);
    }
}
