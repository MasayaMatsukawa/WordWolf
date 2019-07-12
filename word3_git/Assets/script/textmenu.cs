using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // <---- 追加1

public class textmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        hoge();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Text targetText; // <---- 追加2
    string[] words = { "犬", "猫", "猫", "猫" };
    void hoge()
    {

        this.targetText = this.GetComponent<Text>(); // <---- 追加3
        this.targetText.text = "words[1]"; // <---- 追加4
    }
}
