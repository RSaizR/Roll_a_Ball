using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorEsfera : MonoBehaviour
{
    public float speed;
    private int count;
    public TextMeshPro text;
    public TextMeshPro textF;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        count = 0;
        text.text = "Puntuos: 0";
        textF.text = "";
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        
        _rigidbody.AddForce(direction * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pickup")
        {
            Destroy(other.gameObject);
            count++;

            updateCounter();
        }
    }

    void updateCounter()
    {
        text.text = "Puntos " + count;

        int numPickups = GameObject.FindGameObjectsWithTag("pickup").Length;
        if (numPickups <= 1)
        {
            text.text = "";
            textF.text = "¡GANASTE!";
        }
    }
}
