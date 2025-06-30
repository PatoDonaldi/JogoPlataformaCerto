using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioClip som;
    private AudioSource player;

    void Start()
    {
        player = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void Jogar()
    {


    }
    public void Cenario1()
    {
        SceneManager.LoadScene("Cenario1");
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Reiniciar(string fase)
    {
        SceneManager.LoadScene(fase);
    }
}