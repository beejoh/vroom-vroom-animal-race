using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour
{
    public Text countDownText;
    movement movement;
    void Start()
    {
        movement = GameObject.FindObjectOfType<movement>();
        movement.enabled = false;
        StartCoroutine(Counter());
    }

    IEnumerator Counter()
    {
        for(int i = 3; i > 0; i--)
        {
            countDownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        movement.enabled = true;
        countDownText.enabled = false;
    }
}
