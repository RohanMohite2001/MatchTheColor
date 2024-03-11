using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public float moveSpeed = 7f;
    private MeshRenderer meshRenderer;
    private Color[] colors = {Color.red, Color.yellow, Color.black, Color.blue, Color.magenta, Color.green};

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(ChangeColor());
    }

    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W)) inputVector.y = +1;
        if (Input.GetKey(KeyCode.S)) inputVector.y = -1;
        if (Input.GetKey(KeyCode.A)) inputVector.x = -1;
        if (Input.GetKey(KeyCode.D)) inputVector.x = +1;

        inputVector = inputVector.normalized;
        Vector3 movDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += movDir * moveSpeed * Time.deltaTime;
    }

    IEnumerator ChangeColor()
    {
        bool isRunning = true;
        while (isRunning)
        {
            meshRenderer.material.color = Color.red;
            yield return new WaitForSeconds(5f);
            meshRenderer.material.color = Color.yellow;
            yield return new WaitForSeconds(5f);
            meshRenderer.material.color = Color.green;
            yield return new WaitForSeconds(5f);
            meshRenderer.material.color = Color.magenta;
            yield return new WaitForSeconds(5f);
            meshRenderer.material.color = Color.black;
            yield return new WaitForSeconds(5f);
            meshRenderer.material.color = Color.blue;
            isRunning = false;
            Debug.Log("GameStop");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Block") && meshRenderer.material.color == other.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            Debug.Log("Score++");
            GameManager.Instance.AddScore();
            meshRenderer.material.color = colors[Random.Range(0, colors.Length)];
        }
        else if(other.gameObject.CompareTag("Block") && meshRenderer.material.color != other.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            Debug.Log("Score--");
            GameManager.Instance.SubstractScore();
        }
    }
}
