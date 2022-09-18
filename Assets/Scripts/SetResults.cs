using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SetResults : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI ClearText;
    [SerializeField] TMPro.TextMeshProUGUI CollectText;
    [SerializeField] TMPro.TextMeshProUGUI MissText;
    [SerializeField] TMPro.TextMeshProUGUI RateText;
    // Start is called before the first frame update

    GameObject TypeManager = null;

    bool setValue = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( TypeManager == null)
        {
            TypeManager = GameObject.Find("TypingManager");
        }
        if ( TypeManager != null && setValue == false)
        {
            TypingManager mgr = TypeManager.GetComponent<TypingManager>();
            ClearText.text = "�N���A " + mgr.score.ToString();
            CollectText.text = "�����@" + mgr.correctCount.ToString();
            MissText.text = "�~�X�@" + mgr.missCount.ToString();
            float rate = (float)mgr.correctCount / ( (float)mgr.correctCount + (float)mgr.missCount );
            rate *= 100.0f;
            RateText.text = "���� " + rate.ToString("N2") + "%";

            setValue = true;
        }
    }
}
