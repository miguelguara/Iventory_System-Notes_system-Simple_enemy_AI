using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private PlacaMenager PCM;
    public string texto;
    public float raio;
    [SerializeField]
    LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        PCM = FindObjectOfType<PlacaMenager>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D c = Physics2D.OverlapCircle(transform.position, raio,mask);
        if (c != null && Input.GetKeyDown(KeyCode.P))
        {
            PCM.PLC(texto);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, raio);
    }

}
