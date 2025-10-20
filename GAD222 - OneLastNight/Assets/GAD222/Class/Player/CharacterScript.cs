using TMPro;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] private GameObject HoveringTextPrefab;
    [SerializeField] private GameObject spawnLoc;

    private GhostController Gcontroller;
    private Collider2D playerCollider;

    private void Start()
    {
        Gcontroller = GetComponent<GhostController>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerCollider != null)
        {
            if(collision.tag == "Brother")
            {
                SpawnHoveringText(" This is the Brother ");
                // highlight the character
            }

            if (collision.tag == "Sister")
            {
                SpawnHoveringText(" This is the Sister ");
            }

            if (collision.tag == "Mother")
            {
                SpawnHoveringText(" This is the Mother ");
            }

            if (collision.tag == "Father")
            {
                SpawnHoveringText(" This is the Father ");
            }

            if (collision.tag == "Uncle")
            {
                SpawnHoveringText(" This is the Uncle ");
            }
        }
    }

    // Enable the text above the character prefab
    public void SpawnHoveringText(string messageToPass)
    {
        GameObject Text = Instantiate(HoveringTextPrefab, spawnLoc.transform.position, spawnLoc.transform.rotation);
        TMP_Text TextMesh = Text.GetComponentInChildren<TMP_Text>();
        TextMesh.text = messageToPass;
        Gcontroller.isTalking = true;
    }
}
