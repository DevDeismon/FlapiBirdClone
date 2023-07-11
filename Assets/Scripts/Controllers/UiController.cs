using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public void ChangeStateItems(string[] itemsName, bool state)
    {
        for (int i = 0; i < itemsName.Length; i++)
        {
            var n = GameObject.Find(itemsName[i]);
            n.SetActive(state);
        }
    }
}
