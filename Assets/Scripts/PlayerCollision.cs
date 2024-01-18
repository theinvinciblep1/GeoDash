using UnityEngine;

public class PlayerCollision : MonoBehaviour

   
{
    public PlayerMovement movement;
    public GameManager gameManager;

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Collision Detected with " + collisionInfo.collider.name);
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            gameManager.GameOver();
        }
    }
}
