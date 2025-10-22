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

    private void Init()
    {
        TextMesh.text = messageToSend;
    }
}
