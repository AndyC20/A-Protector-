using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDoor2 : MonoBehaviour
{
    public float newCameraSize = 2f;
    public Transform teleportTarget;
    public bool TopDown = false;
    public Vector3 newPlayerScale = new Vector3(5f, 5f, 1.0f); 
    public Dropper[] droppers;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}, Layer: {LayerMask.LayerToName(collision.gameObject.layer)}");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player tag detected.");
            controller player = collision.gameObject.GetComponent<controller>();

            if (player != null)
            {
                collision.gameObject.transform.position = teleportTarget.position;
                player.SetBool("IsTopDown", TopDown);
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                playerRb.gravityScale = 1f;

                foreach (Dropper dropper in droppers)
                {
                    dropper.active = true;
                }

                camZoom cameraZoom = Camera.main.GetComponent<camZoom>();

                if (cameraZoom != null)
                {
                    cameraZoom.SetCameraSize(newCameraSize);
                }

                collision.transform.localScale = newPlayerScale;

            }
        }
    }

}
