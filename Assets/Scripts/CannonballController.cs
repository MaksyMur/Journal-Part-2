using UnityEngine;

public class CannonballController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("EnemyShip"))
        {
            ScoreboardController.Instance.Score += 1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
