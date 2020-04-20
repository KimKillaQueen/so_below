using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody player;
    [SerializeField] public float moveSpeed = 3.0f;
    [SerializeField] public float rotateSpeed = 30.0f;
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") != 0) {
            if(Input.GetAxisRaw("Vertical") < 0.0f) {
                player.MovePosition(transform.position + transform.forward * moveSpeed * Input.GetAxisRaw("Vertical") * 0.3f * Time.deltaTime);
            } else {
                player.MovePosition(transform.position + transform.forward * moveSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime);
            }
            // player.MovePosition(player.position - new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime);
        } else if (Input.GetAxisRaw("Horizontal") != 0) {
            transform.Rotate(0.0f, rotateSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0.0f);
        }

        // if
        // transform.LookAt()
        // Transform targetTransform = ;
        // targetTransform.position = player.velocity.normalized * 1.0f;
        // transform.LookAt()
            // Quaternion targetRotation = Quaternion.LookRotation(player.velocity.normalized, Vector3.up);
            // player.rotation = Quaternion.RotateTowards(player.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            // transform.Rotate(Vector3.up, rotateSpeed * (player.velocity.normalized - transform.rotation.eulerAngles).y, Space.Self);
        
        // Vector3 targetRotation = Quaternion.LookRotation(player.velocity).eulerAngles;
        // Vector3 diff = targetRotation - player.rotation.eulerAngles;

        // diff.Normalize();
        // transform.Rotate(diff, Space.World);
        // player.AddTorque(diff * rotateSpeed);

        // Vector3 dir = player.velocity;
        // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotateSpeed * Time.deltaTime); 
    }
}
