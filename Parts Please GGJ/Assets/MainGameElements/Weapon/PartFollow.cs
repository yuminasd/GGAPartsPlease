using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartFollow : MonoBehaviour
{
    public Vector3 defaultPosition;
    public Transform parentPosition;
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        this.defaultPosition = new Vector3(-1500, 0, -5);
        this.parentPosition = null;
        this.transform = this.GetComponent<Transform>();
        this.transform.position = defaultPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.parentPosition != null)
        {
            this.transform.position = parentPosition.position;
        }
        else if (this.parentPosition == null)
        {
            if(this.transform.position != this.defaultPosition)
            {
                this.transform.position = this.defaultPosition;
            }
        }
    }

    public void setParentPosition(RectTransform other)
    {
        Debug.Log(other);
        //Debug.Log(other.GetType());
        this.parentPosition = other;
    }

    public void setParentPosition(Transform other)
    {
        Debug.Log(other);
        //Debug.Log(other.GetType());
        this.parentPosition = other;
        this.transform.rotation = other.rotation;
    }
}
