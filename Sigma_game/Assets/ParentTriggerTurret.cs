using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentTriggerTurret : MonoBehaviour {
    
    public void PullTrigger(Collider c)
    {
        Destroy(c.gameObject);
        if(c.gameObject.name.Contains("BulletPlayer"))
            Destroy(gameObject);
    }
}
