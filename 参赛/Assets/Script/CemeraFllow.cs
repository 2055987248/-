using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemeraFllow : MonoBehaviour
{

    public Transform target;
    public float smoothing;

    public Vector2 minPos;
    public Vector2 maxPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            if (target.position != transform.position)
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x); //��targetPos��xֵ��������С�����֮��
                targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y); //��targetPos��yֵ��������С�����֮��
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }

    public void SetCamPosLimit(Vector2 minPos,Vector2 maxPos)
    {
        this.minPos = minPos;
        this.maxPos = maxPos;
    }
}