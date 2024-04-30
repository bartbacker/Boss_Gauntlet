using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_Assistant : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    private TMP_Text messageText;
    public GameObject textObject;
    public GameObject ScrimplyCode;

    // Start is called before the first frame update
    private void Awake()
    {
        messageText = transform.Find("messageTalk").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if(ScrimplyCode.GetComponent<Scrimply>().startText == true)
        {
            textObject.SetActive(true);
            textWriter.AddWriter(messageText, "Welcome to The Caves... use 'A' and 'D' to move, 'W' to jump, and your mouse to shoot..good luck friend", .1f, true);
            ScrimplyCode.GetComponent<Scrimply>().startText = false;
        }
    }

}
