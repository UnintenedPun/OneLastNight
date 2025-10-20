using TMPro;
using UnityEngine;

public class HoverTextScript : MonoBehaviour
{
    public string messageToSend;

    public float timeAlive;
    public float speedOfText;

    private TMP_Text TextMesh;


    private void Awake()
    {
        TextMesh = GetComponent<TMP_Text>();
        Init();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextMesh = GetComponent<TMP_Text>();
    }

    private void Init()
    {
        TextMesh.text = messageToSend;
    }
}
