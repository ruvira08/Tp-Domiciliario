using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject PanelSinRespuesta;
    public GameObject PanelRespuesta;
    public InputField InputCantidad;
    public Text TxtResultado;
    public Text repetir;
    public int minObjects = 20;
    public int maxObjects = 20;
    public GameObject[] Spawn;
    public GameObject[] Spawned;
  
    int objectCant;

    void Start()
    {

        Spawned = new GameObject[maxObjects];

        SpawnObjects();
    }
    void Update()
    {

    }

        public void OnBotonSalirClick()
    {
        SceneManager.LoadScene("SeleccionarJUego");
    }

     public void OnAceptarClick()
    {
        PanelSinRespuesta.SetActive(false);
    }
    public void OnBotonRepetirClick()
    {
        DeleteSpawns();
        PanelRespuesta.SetActive(false);
        SpawnObjects();
    }


    public void OnBotonResponderClick()
    {
        if (InputCantidad.text == "")
        {
            PanelSinRespuesta.SetActive(true);
            InputCantidad.text = "";
        }
        else
        {
            if (InputCantidad.text == objectCant.ToString())
            {
                TxtResultado.text = "Respuesta correcta";
                repetir.text = "Reiniciar el desafío";
                PanelRespuesta.SetActive(true);
                InputCantidad.text = "";
            }
            else
            {
                TxtResultado.text = "Respuesta incorrecta";
                repetir.text = "Volver a intentarlo";
                PanelRespuesta.SetActive(true);

            }
        }
    }
   
     void DeleteSpawns()
    {
        foreach (GameObject objeto1 in Spawned)
        {
            Destroy(objeto1);
        }
    }

    void SpawnObjects()
    {
        objectCant = Random.Range(minObjects, maxObjects + 1);
        for (int i = 0; i < objectCant; i++)
        {
            int randomObject = Random.Range(0, Spawn.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-5, 5), 10, Random.Range(5, -5));
            GameObject objeto = Instantiate(Spawn[randomObject], spawnPosition, Quaternion.identity);
            Spawned[i] = objeto;
        }
    }


   
}