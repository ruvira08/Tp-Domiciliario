using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] Spawn; // Array de prefabs (esfera, cubo, triángulo)
    public GameObject[] Spawned;
    public GameObject PanCampoVacio;
    public GameObject PanRespuesta;
    public InputField InfNum;
    public Text TXTRespuesta;
    public Text repetir;
    public int minObjects = 5;
    public int maxObjects = 10;
    int objectCant;

    void Start()
    {

        Spawned = new GameObject[maxObjects];

        SpawnObjects();
    }
    void Update()
    {

    }

    public void OnRepetirClick()
    {
        DeleteSpawns();
        PanRespuesta.SetActive(false);
        SpawnObjects();
    }

    public void OnSalirClick()
    {
        SceneManager.LoadScene("SeleccionarJuegos");
    }

    public void OnResponderClick()
    {
        if (InfNum.text == "")
        {
            PanCampoVacio.SetActive(true);
            InfNum.text = "";
        }
        else
        {
            if (InfNum.text == objectCant.ToString())
            {
                TXTRespuesta.text = "Resultado correcto";
                repetir.text = "Reiniciar el desafío";
                PanRespuesta.SetActive(true);
                InfNum.text = "";
            }
            else
            {
                TXTRespuesta.text = "Resultado incorrecto";
                repetir.text = "Volver a intentarlo";
                PanRespuesta.SetActive(true);

            }
        }
    }
    public void OnAceptarClick()
    {
        PanCampoVacio.SetActive(false);
    }

    void SpawnObjects()
    {
        objectCant = Random.Range(minObjects, maxObjects + 1);
        for (int i = 0; i < objectCant; i++)
        {
            int randomObject = Random.Range(0, Spawn.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-6, 3), 16, Random.Range(-3, 5));
            GameObject objeto = Instantiate(Spawn[randomObject], spawnPosition, Quaternion.identity);
            Spawned[i] = objeto;
        }
    }

    void DeleteSpawns()
    {
        foreach (GameObject objeto1 in Spawned)
        {
            Destroy(objeto1);
        }
    }
}