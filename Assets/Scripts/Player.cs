using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    private Rigidbody thisRigidbody = null;
    public float Force = 300;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        thisRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            thisRigidbody.AddForce(Vector3.up * Force);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Over" || collision.collider.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }

        if (collision.collider.tag == "Score")
        {
            Destroy(collision.gameObject);
            GameManager.thisManager.UpdateScore(1);
        }
    }
}
