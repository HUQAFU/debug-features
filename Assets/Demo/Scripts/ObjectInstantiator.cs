using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiator : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    void Start()
    {
        var myTransform = transform;
        Instantiate(prefab, myTransform.position, myTransform.rotation);
    }
}
