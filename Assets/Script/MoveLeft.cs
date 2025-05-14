using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Hancurkan objek jika keluar layar (opsional)
        if (transform.position.x < -10f)    
        {
            Destroy(gameObject);
        }
    }
}
