using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAnimation : MonoBehaviour
{
    public Camera cameraMain;
    public GameObject objetoCanvas;

    private void Start()
    {
        StartCoroutine(ExecutarAnimacao());
    }

    private System.Collections.IEnumerator ExecutarAnimacao()
    {
        // Executar a anima��o da c�mera
        yield return StartCoroutine(AnimarCamera());

        // Mostrar o canvas
        objetoCanvas.SetActive(true);
    }

    private System.Collections.IEnumerator AnimarCamera()
    {
        // Definir a anima��o da c�mera aqui (exemplo hipot�tico)
        float duracao = 2.5f;
        float tempoInicio = Time.time;
        Vector3 posicaoInicial = cameraMain.transform.position;
        Vector3 posicaoFinal = new Vector3(100f, 0f, 0f);

        while (Time.time - tempoInicio < duracao)
        {
            float tempoDecorrido = Time.time - tempoInicio;
            float fracao = tempoDecorrido / duracao;

            // Interpola��o linear da posi��o da c�mera
            cameraMain.transform.position = Vector3.Lerp(posicaoInicial, posicaoFinal, fracao);

            yield return null;
        }
    }
}