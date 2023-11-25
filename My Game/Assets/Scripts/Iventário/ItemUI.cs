using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{

    Transform PP;
    public Image imagem;
    GameObject ITM;
    Itens IT;

    private void Awake()
    {
        PP = GameObject.Find("Player").GetComponent<Transform>();
    }

    public void AddItemUI(Itens NI)
    {
        IT = NI;
        imagem.sprite = IT.Icone;
        ITM = IT.Obj;
    }

    public void LP()
    {
        imagem.sprite = null;
        ITM = null;
    }

    public void RemoveItemUI()
    {
        imagem.sprite = null;
        Instantiate(ITM,new Vector2(PP.position.x+2f,PP.position.y),Quaternion.identity);
        ITM = null;
        Inventário.IV.Remover(IT);
    }
}
