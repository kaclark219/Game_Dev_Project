using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowerbox : MonoBehaviour
{
    [SerializeField] GameObject interact;
    Rigidbody2D player;
    // bool playerNearby = false;
    // float px;
    // float py;
    // float myx;
    // float myy;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // px = player.position.x;
        // py = player.position.y;
        // myx = transform.position.x;
        // myy = transform.position.y;
        // playerNearby = (px > myx - 3.5 && px < myx + 3.5 && py > myy -2 && py < myy + 2);
        distance = Vector2.Distance(player.transform.position, transform.position);
        interact.SetActive(distance < 1.5);
    }
}
