using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0;
    public float jumpSpeed = 10;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    bool onGround;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 30)
        {
          winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX, movementY);

        rb.AddForce(movement * moveSpeed);

        if(Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed);
            onGround = false;
        }
        if(!Input.anyKey && onGround)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    void OnCollisionEnter()
    {
          onGround = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count +1;

            SetCountText();
        }
    }

}
