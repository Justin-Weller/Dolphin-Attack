using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject player;
    public Sprite openTexture, closedTexture;
    private SpriteRenderer ren;
    private bool isChestOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        ren = this.GetComponent<SpriteRenderer>();
        ren.enabled = false;
    }

    void Update()
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>(), isChestOpen);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            openChest();
            this.player.GetComponent<PlayerHealth>().heal();
        }
    }

    public void showChest() {
        ren.enabled = true;
    }

    public void openChest() {
        ren.sprite = openTexture;
        this.isChestOpen = true;
    }
    public void closeChest() {
        ren.sprite = closedTexture;
        this.isChestOpen = false;
    }

    public bool isOpen() {
        return isChestOpen;
    }
}
