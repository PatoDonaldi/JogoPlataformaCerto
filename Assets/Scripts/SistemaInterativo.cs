using System.Collections;
using TMPro;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SistemaInterativo : MonoBehaviour
{
    [Header("Objeto do Canvas que o Icone")]
    [SerializeField] private Image spriteInterface;
    [Header("Objeto do Canvas que o texto ")]
    [SerializeField] private float tempoExibir;
    [SerializeField] private TextMeshProUGUI textoAviso;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteInterface.enabled = false;
        textoAviso.enabled = false;
    }
    private void OnTriggerEnter(Collider other)//Serve para mostrar trancado,destrancado etc.
    {
        if (other.gameObject.TryGetComponent<Avisos>(out Avisos a))
        {
            StartCoroutine(ExibirAviso(a.SpriteAvisos(), a.AvisoTexto(), a.CorAviso()));
            if (a.AvisoTemporario())
            {
                StartCoroutine(TimerAvisoTemporario(other.gameObject));
            }

        }

    }
    IEnumerator TimerAvisoTemporario(GameObject g)
    {
        yield return new WaitForSeconds(tempoExibir);
        Destroy(g);
    }
    IEnumerator ExibirAviso(Sprite s, string t, Color c)
    {
        spriteInterface.enabled = true;
        textoAviso.enabled = true;
        spriteInterface.sprite = s;
        spriteInterface.color = c;
        textoAviso.text = t;
        textoAviso.color = c;
        yield return new WaitForSeconds(tempoExibir);
        spriteInterface.enabled = false;
        textoAviso.enabled = false;
    }
}