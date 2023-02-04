using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public Transform followTransform;

    void LateUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, (followTransform.transform.position.z - 4.1f));

    }
}
