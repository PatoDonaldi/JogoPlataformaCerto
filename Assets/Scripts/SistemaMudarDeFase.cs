using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



public class SistemaMudarDeFase : MonoBehaviour
{

    [SerializeField] private string nomeDaProximaFase = "";
    [SerializeField] private float tempoDeTransicao = 1.0f;
    [SerializeField] private GameObject efeitoFade;
    private Animator animator;
    void Start()
    {
        animator = efeitoFade.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!string.IsNullOrEmpty(nomeDaProximaFase))
        {
            StartCoroutine(TransicaoParaProximaFase());
        }
    }


    IEnumerator TransicaoParaProximaFase()
    {
        animator.SetTrigger("MudaFase");
            yield return new WaitForSeconds(tempoDeTransicao);
        SceneManager.LoadScene(nomeDaProximaFase);
    }
}
