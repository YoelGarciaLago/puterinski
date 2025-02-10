using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float movementY;
    int count = 0;
    private float movementX;
    public TextMeshProUGUI countText;
    public float speed = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementY = movementVector.y;
        movementX = movementVector.x;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            rb.gameObject.SetActive(false);
            Destroy(rb);
            countText.text = "You Lose";
        }
        if(other.gameObject.CompareTag("Suelo")){
            rb.gameObject.SetActive(false);
            Destroy(rb);
            countText.text = "You're dead :/";
        }
       /* if (other.gameObject.CompareTag("Accelerator"))
        {
            Vector3 boostDirection = transform.forward; // Direcci�n del empuje (aj�stalo seg�n el suelo)
            rb.AddForce(boostDirection * speed, ForceMode.Impulse);
        }*/
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 5)
        {
            countText.text = "You Win";
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
}
