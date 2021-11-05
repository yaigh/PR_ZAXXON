using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothVelocity;
    [SerializeField] Vector3 camaraVelocity;

    // Start is called before the first frame update
    void Start()
    {
        smoothVelocity = 0.3f;
        camaraVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.position.z - 10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);

       //transform.LookAt(player);
    }
}
