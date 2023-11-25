using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacaMenager : MonoBehaviour
{
    public GameObject Placa;
    public Text mensagem;
    string nn;
    
    public void PLC(string txt)
    {
        Placa.SetActive(true);
        nn = txt;
        StartCoroutine(nigga());
    }
    public void fechar()
    {
        Placa.SetActive(false);
        mensagem.text = "";
    }

    IEnumerator nigga()
    {
        foreach(char letter in nn.ToCharArray())
        {
            mensagem.text += letter;
            yield return new WaitForSeconds(0.08f);
        }
    }
}
