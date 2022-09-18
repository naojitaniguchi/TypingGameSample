using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateByButtonPushed : MonoBehaviour
{
    [SerializeField] GameObject ActivateTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPushed()
    {
        ActivateTarget.SetActive(true);
    }
}
