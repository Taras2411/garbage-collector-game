using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hudController : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    private Text m_text;
    public Text m_text2;
    void Start()
    {
        // PlayerPrefs.DeleteAll();
        m_text = GetComponent<Text>();
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        m_text.text = ""+ score;
        if(m_text2 != null){
            m_text2.text = ""+ score;
        }
    }
}
