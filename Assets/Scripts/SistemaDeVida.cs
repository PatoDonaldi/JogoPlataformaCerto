using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : MonoBehaviour
{
    [SerializeField] private int vida = 100;
    [SerializeField] private int mana = 100;
    [SerializeField] private Slider manaIndicador;
    [SerializeField] private Slider vidaIndicador;
    [SerializeField] private GameObject telaDeMorte;
    private bool estaVivo = true;
    private bool levarDano = true;
    private PlayerMovement pMove;
    private bool podeRecarregarMana = true;
    private bool podeRecarregarVida = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ProcuraReferencia();

        pMove = GetComponent<PlayerMovement>();
        if (telaDeMorte.activeSelf == true )
        {
            telaDeMorte.SetActive( false );
        }
    }

    public void ProcuraReferencia()
    {
        if (manaIndicador == null)
        {
            manaIndicador = GameObject.Find("Mana").GetComponent<Slider>();
            manaIndicador.maxValue = mana;
            manaIndicador.value = mana;
        }

        if (vidaIndicador == null)
        {
            vidaIndicador = GameObject.Find("Vida").GetComponent<Slider>();
            vidaIndicador.maxValue = 100;
            vidaIndicador.value = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcuraReferencia();
    }

    public bool EstaVivo()
    {
        return estaVivo;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("fatal") && estaVivo && levarDano)
        {
            StartCoroutine(LevarDano(10));
        }
    }

    IEnumerator LevarDano(int dano)
    {
        levarDano = false;

        if (vida > 0)
        {
            pMove.Hit(); // Chama o m�todo Hit do PlayerMovement para executar a anima��o de dano
            vida -= dano;
            vidaIndicador.value = vida;
            VerificarVida();
            yield return new WaitForSeconds(0.5f);
            levarDano = true;
        }
    }

    private void VerificarVida()
    {
        if (vida <= 0)
        {
            vida = 0;
            estaVivo = false;
            TelaDeMorte();
        }
    }

    private void TelaDeMorte()
    {
        telaDeMorte.SetActive(true);
        
    }

    public void UsarMana()
    {
        mana -= 10;
        manaIndicador.value = mana;
    }

    public int GetMana()
    {
        return mana;
    }

    public void CargaMana(int carga)
    {
        mana += carga;
        manaIndicador.value = mana;
        if (mana > 100)
        {
            mana = 100;
            manaIndicador.value = mana;
        }
    }

    public void CargaVida(int carga)
    {
        vida += carga;
        vidaIndicador.value = vida;
        if (vida > 100)
        {
            vida = 100;
            vidaIndicador.value = vida;
        }
    }

    IEnumerable RecarregaMana()
    {
        podeRecarregarMana = false;
        while (mana < 100)
        {
            mana += 5;
            manaIndicador.value = mana;
            yield return new WaitForSeconds(0.1f);
        }
        mana = 100;
        podeRecarregarMana = true;
    }

    public int GetVida()
    {
        return mana;
    }

    IEnumerable RecarregaVida()
    {
        podeRecarregarMana = false;
        while (mana < 100)
        {
            mana += 5;
            manaIndicador.value = vida;
            yield return new WaitForSeconds(0.1f);
        }
        mana = 100;
        podeRecarregarVida = true;
    }
}
