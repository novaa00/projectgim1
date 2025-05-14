using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;  // Kekuatan lompat
    public Rigidbody2D rb;         // Publickan rb untuk diassign di Inspector
    private bool isGrounded = true; // Menandakan apakah pemain di tanah
    public bool gameOver=false;

    void Start()
    {
        // Pastikan rb sudah di-assign lewat Inspector
        //if (rb == null)
        //{
        //    Debug.LogError("Rigidbody2D belum diassign pada objek Player!");
        //}
    }

    void Update()
    {
        // Jika tombol Spasi ditekan dan pemain ada di tanah, lompat
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpForce; // Memberikan gaya lompat
            isGrounded = false; // Pemain tidak berada di tanah lagi
        }
    }

    // Menandai apakah Player sudah menyentuh tanah lagi
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            isGrounded = true;
        }

        if (collision.collider.CompareTag("trap"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            // Tambahkan logika game over, respawn, dll
        }
    }

}
