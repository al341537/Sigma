using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTriggerTurret : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInParent<ParentTriggerTurret>().PullTrigger(other);
    }
}
