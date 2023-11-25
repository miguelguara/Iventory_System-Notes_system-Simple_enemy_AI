using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    public Itens IT;


    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Player")
        {
            Inventário.IV.Adicionar_Item(IT);
            Destroy(this.gameObject);
        }
    }
}
