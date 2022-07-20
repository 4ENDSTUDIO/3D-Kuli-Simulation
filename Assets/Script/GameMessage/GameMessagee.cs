using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMessagee : MonoBehaviour
{
    public GameObject message;

    #region Singleton
    public static GameMessagee instance;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    #endregion

  

    public void Send(string text)
    {
        Instantiate(message, gameObject.transform).GetComponent<GameMessage>().GetComponent<Text>().text = text;
    }


}
