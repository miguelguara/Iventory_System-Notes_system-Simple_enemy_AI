using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    public ItemUI[] Slots;

    public GameObject Invent�rio_OBJ;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Invent�rio_OBJ.SetActive(!Invent�rio_OBJ.activeSelf);
        }
    }

    public void ATUI()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if(i < Invent�rio.IV.itens.Count)
            {
                Slots[i].AddItemUI(Invent�rio.IV.itens[i]);
            }
            else
            {
                Slots[i].LP();
            }
        }
    }
}
