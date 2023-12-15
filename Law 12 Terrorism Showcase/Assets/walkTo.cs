using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkTo : MonoBehaviour
{
    public bool walking = false;
    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float turnSpeed = 180f;
    [SerializeField] Animator anim;
    public Transform newPos;
    public List<GameObject> props;

    public int currentProp;
    bool began = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Walking", walking);
        if(walking)
        {
            Quaternion rotation = Quaternion.LookRotation(newPos.position - transform.position, Vector3.up);
            
            // because this must be true to progress, we cannot have this be true
            if(transform.rotation != rotation && !began)
            {
                // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnSpeed * Time.deltaTime);
            }else if(transform.position != newPos.position)
            {
                began = true;
                transform.position = Vector3.MoveTowards(transform.position, newPos.position, walkSpeed * Time.deltaTime);
            }else if(transform.rotation != newPos.rotation)
            {
                // transform.rotation = Quaternion.Slerp(transform.rotation, newPos.rotation, turnSpeed * Time.deltaTime);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newPos.rotation, turnSpeed * Time.deltaTime);
            }else{
                walking = false;
                began = false;
            }
        }

        for(int i=0; i<props.Count; i++)
        {
            props[i].SetActive(false);
        }
        props[currentProp].SetActive(true);
    }
}
