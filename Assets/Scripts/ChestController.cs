using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject player;
    public GameObject indicator;
    public Sprite openTexture, closedTexture;
    private SpriteRenderer ren;
    private bool isChestOpen = false;
    private bool isChestShown = false;
    // Start is called before the first frame update
    void Start()
    {
        ren = this.GetComponent<SpriteRenderer>();
        ren.enabled = false;
    }

    void Update()
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>(), isChestOpen || !isChestShown);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            openChest();
            StartCoroutine(showIndicator());
            this.player.GetComponent<PlayerHealth>().heal();
        }
    }

    public void showChest() {
        isChestShown = true;
        ren.enabled = true;
    }

    private IEnumerator showIndicator() {
        indicator.SetActive(true);
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);
        indicator.SetActive(false);
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
