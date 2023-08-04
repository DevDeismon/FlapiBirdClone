using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public void ChangeStateActiveItems(string[] itemsName)
    {
        for (int i = 0; i < itemsName.Length; i++)
        {
            GameObject n = GameObject.Find(itemsName[i]);
            n.SetActive(false);
        }
    }
    public void ChangeStateInactiveItems(string[] itemsName)
    {
        for (int i = 0; i < itemsName.Length; i++)
        {
            GameObject n = transform.Find(itemsName[i]).gameObject;
            n.SetActive(true);
        }
    }
}
