using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //jeito manualmente
        //SceneManager.LoadScene("Fase 2");
        //jeito automatico
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(NextFase(3));
    }

    private IEnumerator NextFase(int time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
