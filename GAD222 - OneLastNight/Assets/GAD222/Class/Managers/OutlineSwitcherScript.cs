using UnityEngine;

public class OutlineSwitcherScript : MonoBehaviour
{
    [SerializeField] private GameObject OutlineObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            OutlineObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OutlineObject.SetActive(false);
    }
}
