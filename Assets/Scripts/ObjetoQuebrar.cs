using UnityEngine;

public class ObjetoQuebrar : MonoBehaviour
{

    [SerializeField] private int vidaObj;
    [SerializeField] private GameObject efeitoQuberar;

    public void Quebrar(int dano)
    {
        vidaObj -= dano;
        if (vidaObj < 0)
        {
            Instantiate(efeitoQuberar, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
  
}
