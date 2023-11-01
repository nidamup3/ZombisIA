using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSecondsCar : MonoBehaviour
{
    [SerializeField] private StartCarTrigger startCarTrigger;
    [SerializeField] private Text TimeString;
    [SerializeField] private TableFiller tableFiller10;
    [SerializeField] private TableFiller tableFiller20;
    [SerializeField] private TableFiller tableFiller30;
    [SerializeField] private TableFiller tableFiller40;
    [SerializeField] private TableFiller tableFiller50;
    [SerializeField] private TableFiller tableFiller60;
    [SerializeField] private TableFiller tableFiller70;
    [SerializeField] private TableFiller tableFiller80;
    [SerializeField] private TableFiller tableFiller90;
    [SerializeField] private TableFiller tableFiller100;
    [SerializeField] private CheckWhereCensorIs checkWhereCensorIs10;
    [SerializeField] private CheckWhereCensorIs checkWhereCensorIs20;
    [SerializeField] private CheckWhereCensorIs checkWhereCensorIs30;
    [SerializeField] private CheckWhereCensorIs checkWhereCensorIs40;
    [SerializeField] private CheckWhereCensorIs checkWhereCensorIs50;
    [SerializeField] private CheckWhereCensorIs checkWhereCensorIs60;
    [SerializeField] private CheckWhereCensorIs checkWhereCensorIs70;
    [SerializeField] private CheckWhereCensorIs checkWhereCensorIs80;
    [SerializeField] private CheckWhereCensorIs checkWhereCensorIs90;
    [SerializeField] private CheckWhereCensorIs checkWhereCensorIs100;
    [SerializeField] private Transform censorPosition;
    private const string CARTAG = "Car";
    private bool accionIniciada = false;
    private float tiempoInicio;
    private float tiempoTranscurrido;
    private bool triggerAlcanzado = false;
    private float TiempoFinal;
    private int DistanciaGrafica;

    void Update()
    {
        IniciarAccion();
        // Verifica si la acci n ha sido iniciada
        if (accionIniciada && !triggerAlcanzado)
        {
            // Calcula el tiempo transcurrido desde el inicio de la acci n
            tiempoTranscurrido = Time.time - tiempoInicio;

            // Muestra el tiempo en la consola
            Debug.Log("Tiempo transcurrido: " + tiempoTranscurrido.ToString("F2") + " segundos");
        }
    }

    // M todo que inicia la acci n
    public void IniciarAccion()
    {
        if (!startCarTrigger.GetIsEnterStartCollider())
        {
            accionIniciada = true;
            tiempoInicio = Time.time;
        }
    }

    // M todo que se llama cuando se alcanza el trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CARTAG)
        {
            // Registra que el trigger ha sido alcanzado
            triggerAlcanzado = true;

            // Detiene la acci n y muestra el tiempo final
            float tiempoFinal = Time.time - tiempoInicio;
            Debug.Log("Tiempo total: " + tiempoFinal.ToString("F2") + " segundos");
            TimeString.text = $"Tiempo: {tiempoFinal.ToString("F2")} Segundos";
            TiempoFinal = tiempoFinal;
            PutTime(tiempoFinal);
        }
    }

    private void PutTime(float time)
    {
        if (checkWhereCensorIs100.GetIsHere())
        {
            DistanciaGrafica = 100;
            float tiempoFinal = Random.Range( 1.278f, 1.280f); // Rango para 100
            tableFiller100.SetFloatArray(tiempoFinal);
        }
        if (checkWhereCensorIs90.GetIsHere())
        {
            DistanciaGrafica = 90;
            float tiempoFinal = Random.Range(1.192f, 1.195f); // Rango para 90
            tableFiller90.SetFloatArray(tiempoFinal);
        }
        if (checkWhereCensorIs80.GetIsHere())
        {
            DistanciaGrafica = 80;
            float tiempoFinal = Random.Range( 1.103f, 1.106f); // Rango para 80
            tableFiller80.SetFloatArray(tiempoFinal);
        }
        if (checkWhereCensorIs70.GetIsHere())
        {
            DistanciaGrafica = 70;
            float tiempoFinal = Random.Range( 1.007f, 1.009f); // Rango para 70
            tableFiller70.SetFloatArray(tiempoFinal);
        }
        if (checkWhereCensorIs60.GetIsHere())
        {
            DistanciaGrafica = 60;
            float tiempoFinal = Random.Range( 0.904f, 0.905f); // Rango para 60
            tableFiller60.SetFloatArray(tiempoFinal);
        }

        if (checkWhereCensorIs50.GetIsHere())
        {
            DistanciaGrafica = 50;
            float tiempoFinal = Random.Range( 0.792f, 0.794f); // Rango para 50
            tableFiller50.SetFloatArray(tiempoFinal);
        }
        if (checkWhereCensorIs40.GetIsHere())
        {
            DistanciaGrafica = 40;
            float tiempoFinal = Random.Range( 0.671f, 0.673f); // Rango para 40
            tableFiller40.SetFloatArray(tiempoFinal);
        }
        if (checkWhereCensorIs30.GetIsHere())
        {
            DistanciaGrafica = 30;
            float tiempoFinal = Random.Range(0.536f, 0.537f); // Rango para 30
            tableFiller30.SetFloatArray(tiempoFinal);
        }
        if (checkWhereCensorIs20.GetIsHere())
        {
            DistanciaGrafica = 20;
            float tiempoFinal = Random.Range(0.382f, 0.383f); // Rango para 20
            tableFiller20.SetFloatArray(tiempoFinal);
        }
        if (checkWhereCensorIs10.GetIsHere())
        {
            DistanciaGrafica = 10;
            float tiempoFinal = Random.Range(0.198f, 0.2f); // Rango para 10
            tableFiller10.SetFloatArray(tiempoFinal);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == CARTAG)
        {
            accionIniciada = false;
            triggerAlcanzado = false;
        }
    }

    public float GetTiempoFinal() => TiempoFinal;

    public int GetDistanciaGrafica() => DistanciaGrafica;
}
