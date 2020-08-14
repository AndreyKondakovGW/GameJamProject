using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog : MonoBehaviour
{
    public string name;
    private int _startphrase = 0;
    private int _curentphrase;

    public DialogPhrase[] DialogMass;

    public void StartDialog()
    {
        _curentphrase = _startphrase; 
    }

    public DialogPhrase GetPhrace()
    {
        return DialogMass[_curentphrase];
    }


    public bool EndofDialog()
    {
        return _curentphrase == -1;
    }

    public void ChangePhracse(int newphrase)
    {
        _curentphrase = newphrase;
    }
}

[System.Serializable]
public class DialogPhrase
{
    [TextArea(3, 10)]
    public string text;
    public Answer[] answers;
    public int nextPhrase;
}

[System.Serializable]
public class Answer
{
    public string text;
    public int toPhrase;    
}

    


    
