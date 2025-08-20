using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;

    public GameManager manager;

    private void Update()
    {
        if (manager.IsGameOver)
            return;

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
