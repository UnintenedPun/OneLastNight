using System.Collections;
using UnityEngine;

public class HoveringTextTimeout : MonoBehaviour
{
    [SerializeField] private float timeOutTime;

    public void Awake()
    {
        StartCoroutine(TimeOut());
    }
    private IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(timeOutTime);
        Destroy(gameObject);
    }
}
