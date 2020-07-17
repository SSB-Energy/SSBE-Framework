using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Serializables
    [SerializeField] float initYSpeed = 0f;
    [SerializeField] float initXSpeed = 0f;

    //States
    private Rigidbody2D physics = null;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        if (physics != null)
        {
            physics.velocity = new Vector2(initXSpeed, initYSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
