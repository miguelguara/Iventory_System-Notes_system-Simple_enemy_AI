using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    public ItemUI[] Slots;

    public GameObject Inventário_OBJ;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventário_OBJ.SetActive(!Inventário_OBJ.activeSelf);
        }
    }

    public void ATUI()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if(i < Inventário.IV.itens.Count)
            {
                Slots[i].AddItemUI(Inventário.IV.itens[i]);
            }
            else
            {
                Slots[i].LP();
            }
        }
    }
}
