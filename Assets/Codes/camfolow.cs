    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfolow : MonoBehaviour
{
     [SerializeField] Transform mario;
     
    void Update()
    {
          transform.position = new Vector3(mario.transform.position.x, mario.transform.position.y, -10);
    }
    
}
