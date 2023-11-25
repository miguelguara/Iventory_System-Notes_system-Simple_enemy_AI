using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventário : MonoBehaviour
{

    public static Inventário IV;

   public int espacos;

    private UIControler UIC;
   
   public List<Itens> itens = new List<Itens>();



    private void Awake()
    {
        IV = this;
        UIC = FindObjectOfType<UIControler>();
    }

    public void Adicionar_Item(Itens NI)
    {
        if(itens.Count < espacos)
        {
            itens.Add(NI);
            UIC.ATUI();
        }
    }

    public void Remover(Itens NI)
    {
        itens.Remove(NI);
        UIC.ATUI();
    }
}
