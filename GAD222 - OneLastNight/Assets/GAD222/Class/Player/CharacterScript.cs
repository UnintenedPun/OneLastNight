using System.Collections;
using TMPro;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] private GameObject HoveringTextPrefab;
    [SerializeField] private GameObject spawnLoc;

    private GhostController Gcontroller;
    private Collider2D playerCollider;

    private bool talkedToBrother, talkedToSister, talkedToUncle, talkedToMother, talkedToFather, isTalking;

    private int talkCounter;

    private void Start()
    {
        Gcontroller = GetComponent<GhostController>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (talkCounter > 0)
        {
            isTalking = true;
        }
        else
        {
            isTalking = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerCollider != null && isTalking == false)
        {
            int timeToSpawn = 3;
            if (collision.tag == "Brother")
            {
                SpawnHoveringText(" This is my little Brother ");
                if(!talkedToBrother && talkCounter < 2) StartCoroutine(QueueText("He always kept to himself, quiet.", timeToSpawn));
                Gcontroller.canInteract = true;
                Debug.Log("Next to brother");
                return;
            }

            if (collision.tag == "Sister")
            {
                SpawnHoveringText(" Cheecky Little Sister ");
                if (!talkedToSister && talkCounter < 2) StartCoroutine(QueueText("She was always a rascal, but I do love her.", timeToSpawn));
                Gcontroller.canInteract = true;
                Debug.Log("Next to Sister");
                return;
            }

            if (collision.tag == "Mother")
            {
                SpawnHoveringText(" Oh my dearest Mother.. ");
                if (!talkedToMother && talkCounter < 2) StartCoroutine(QueueText("The caretaker, The one I wanted to be", timeToSpawn));
                Gcontroller.canInteract = true;
                Debug.Log("Next to Mother");
                return;
            }

            if (collision.tag == "Father")
            {
                SpawnHoveringText("My Father, The man of the House ");
                if (!talkedToFather && talkCounter < 2) StartCoroutine(QueueText("I always loved him. He is was so kind.", timeToSpawn));
                Gcontroller.canInteract = true;
                Debug.Log("Next to Father");
                return;
            }

            if (collision.tag == "Uncle")
            {
                SpawnHoveringText(" This is the Uncle ");
                if (!talkedToUncle && talkCounter < 2) StartCoroutine(QueueText("I never knew him when I was younger, And here he is now... Trouble.", timeToSpawn));
                Gcontroller.canInteract = true;
                Debug.Log("Next to Uncle");
                return;
            }

            if(collision.tag == "Item")
            {
                int ranNum = Random.Range(0, 4);

                switch(ranNum)
                {
                    case 0:
                        SpawnHoveringText(" Wonder what this is? ");
                        break;
                    case 1:
                        SpawnHoveringText(" Oohh, Shiny! ");
                        break;
                    case 2:
                        SpawnHoveringText(" This could help ");
                        break;
                    case 3:
                        SpawnHoveringText(" This might be useful for someone ");
                        break;
                    case 4:
                        SpawnHoveringText(" Lets see if this suits anyone ");
                        break;
                }

                Gcontroller.canInteract = true;
                Debug.Log("Collecting Item" + " " + collision.name);
                return;
            }
        }
    }

    // Enable the text above the character prefab
    public void SpawnHoveringText(string messageToPass)
    {
        GameObject Text = Instantiate(HoveringTextPrefab, spawnLoc.transform.position, spawnLoc.transform.rotation);
        TMP_Text TextMesh = Text.GetComponentInChildren<TMP_Text>();
        TextMesh.text = messageToPass;
        //Gcontroller.isTalking = true;
    }

    private IEnumerator QueueText(string textToSend, int timeToWait)
    {
        talkCounter++;
        yield return new WaitForSeconds(timeToWait);
        SpawnHoveringText(textToSend);
        talkCounter--;
    }
}
