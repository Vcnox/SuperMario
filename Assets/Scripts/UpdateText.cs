using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public InterfaceVariable _varaibleToUpdate;
    private TMP_Text _textComponent;

    void Start()
    {

        _textComponent = GetComponent<TMP_Text>();

    }


    // Update is called once per frame
    void Update()
    {
        switch (_varaibleToUpdate)
        {
            case InterfaceVariable.COINS:
                _textComponent.text = "Monedas:" + GameManager._isntance.GetCoins();
                break;
            case InterfaceVariable.TIME:
                _textComponent.text = "Tiempo:" + GameManager._isntance.GetTime();
                break;
           case InterfaceVariable.GOOMBAS:
                _textComponent.text = "Goomba" + GameManager._isntance.GetGoombaValue();
                break;


        }

    }
}
