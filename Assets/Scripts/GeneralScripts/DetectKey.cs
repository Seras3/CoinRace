using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectKey : MonoBehaviour
{
    private TMP_InputField _inputField;
    public bool HasKey { get; private set; }
    public KeyCode Key { get; private set; }  //this stores your custom key
    
    private KeyCode _currentKey;

    private KeyCode CancelKey = KeyCode.Escape;
    
    void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onDeselect.AddListener(delegate {HandleCancelFocus(); });
            
        _currentKey = Converter.StringToKeyCode(_inputField.text);
    }

    void UnfocusInput()
    {
        _inputField.interactable = false;
        _inputField.interactable = true;
    }

    void HandleCancelFocus()
    {
        _inputField.text = _currentKey.ToString();
    }

    void Update()
    {
        if(_inputField.isFocused)
        {
            _inputField.text = "";
            Key = _currentKey;

            DetectInput();
        }
        
    }
 
    private void DetectInput()
    {
        foreach(KeyCode vkey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if(Input.GetKeyDown(vkey))
            {
                Key = vkey; //this saves the key being pressed 
                
                if (Key == CancelKey)
                {
                    UnfocusInput();
                    HandleCancelFocus();
                }
                else
                {
                    UnfocusInput();
                    _inputField.text = Key.ToString();
                    _currentKey = Key;
                    HasKey = true;
                }
            }
        }
    }

    public void FinishUpdate()
    {
        HasKey = false;
    }
}
