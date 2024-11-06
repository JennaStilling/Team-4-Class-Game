using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour, ICollectible
{
    public void Collect()
    {
        Debug.Log("You collected a capsule");

    }
    
}
