using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [Header("Inscribed")]

    // Prefab for instantiating blocks
    public GameObject blockPrefab;

    // Speed at which the Machine moves
    public float speed = 1f;

    // Distance where Machine turns around
    public float leftAndRightEdge = 10f;

    // Chance that the Machine will change direction
    public float chanceToChangeDirection = 0.1f;

    // Rate at which blocks will be instantiated
    public float secondsBetweenBlockdrop = 1f;

    private float centerLine;

    // Start is called before the first frame update
    void Start()
    {
      centerLine = this.transform.position.x;
      // Dropping blocks every second
      Invoke("DropBlock", 2f);

    }

    void DropBlock() {

      GameObject block = Instantiate<GameObject>(blockPrefab);
      block.transform.position = transform.position;
      Invoke("DropBlock", secondsBetweenBlockdrop);
    }

    // Update is called once per frame
    void Update()
    {

        // Basic Movement
        Vector3 pos = transform.position;

        pos.x += speed * Time.deltaTime;

        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge + centerLine) {

          speed = Mathf.Abs(speed); // Move right

        } else if (pos.x > leftAndRightEdge + centerLine) {

          speed = -Mathf.Abs(speed); // Move left

        } else if (Random.value < chanceToChangeDirection) {

          speed *= -1; // Change direction

        }

    }

    void FixedUpdate() {

      // Random direction changes are now time-based due to FixedUpdate()
      if (Random.value < chanceToChangeDirection) {

        speed *= -1; // Change direction

      }
    }
}
