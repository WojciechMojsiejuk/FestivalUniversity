using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningDiscoBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Vector3 rotation = new Vector3(1, 0, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation);
    }
}
