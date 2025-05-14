using UnityEngine;
using System.Collections;

public class TrapSpawner : MonoBehaviour
{
    public GameObject[] traps;  // Array untuk menyimpan berbagai prefab trap yang dapat dipilih secara acak
    public float minTime = 1f;  // Waktu minimal antar spawn
    public float maxTime = 3f;  // Waktu maksimal antar spawn

    void Start()
    {
        // Memulai coroutine untuk spawn trap secara berulang dengan interval waktu acak
        StartCoroutine(SpawnTrap());
    }

    // Coroutine untuk spawn trap secara berulang dengan interval waktu acak
    IEnumerator SpawnTrap()
    {
        while (true)  // Loop untuk spawn trap secara terus-menerus
        {
            // Memilih trap secara acak dari array traps
            int randomIndex = Random.Range(0, traps.Length);  // Mendapatkan index acak untuk memilih prefab trap
            GameObject selectedTrap = traps[randomIndex];     // Memilih prefab trap berdasarkan index

            // Menentukan posisi spawn trap pada sumbu X dan Y
            Vector2 spawnPosition = new Vector2(20f,-3.5f);   // Menetapkan posisi spawn dengan ketinggian Y = 3.5

            // Men-generate trap pada posisi spawn yang telah ditentukan
            GameObject spawnedTrap = Instantiate(selectedTrap, spawnPosition, Quaternion.identity);

            // Pastikan Rigidbody2D trap menggunakan Kinematic untuk menghindari efek gravitasi
            Rigidbody2D rb = spawnedTrap.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Kinematic;  // Mengatur body type ke Kinematic
            }

            // Menunggu selama waktu acak sebelum spawn trap berikutnya
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);  // Tunggu selama waktu acak
        }
    }
}
