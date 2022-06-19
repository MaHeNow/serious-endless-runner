using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGameOverLabel : MonoBehaviour
{

    private Text _textField;

    // Start is called before the first frame update
    void Start()
    {
        this._textField = GetComponent<Text>();
        this._textField.text = "Score: " + (int) Globals.score;
    }

}
