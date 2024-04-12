using EmotivUnityPlugin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using SimpleJSON;

[Serializable]
public class ConcordiaDataMaster : MonoBehaviour
{
    // Definir el diccionario
    private Dictionary<string, List<float>> miDiccionario = new();
    string currentUserString;

    public Button profileButton;

    public Text userText;

    private List<float> cleanList = new();

    private CortexClient _ctxClient = CortexClient.Instance;

    [SerializeField]
    string bigDatalList;

    void Start()
    {
        _ctxClient.StreamDataReceived += OnStreamDataReceived;

        profileButton.onClick.AddListener(AgregarAlD);
    }



    void AgregarAlD()
    {
        AgregarAlDiccionario(userText.text, cleanList);
    }

    void AgregarAlDiccionario(string clave, List<float> valores)
    {
        if (!miDiccionario.ContainsKey(clave))
        {
            miDiccionario.Add(clave, valores);

            currentUserString = clave;
        }
        else
        {
            currentUserString = clave;
        }
    }

    private void OnStreamDataReceived(object sender, StreamDataEventArgs e)
    {
        if (e.StreamName == DataStreamName.PerformanceMetrics)
        {
            int takeStress = 0;
            foreach (System.Object met in e.Data)
            {
                takeStress++;

                if (takeStress == 10)
                {
                    //met
                    float valorFloat;

                    if (float.TryParse(met.ToString(), out valorFloat))
                    {
                        cleanList.Add(valorFloat);
                    }
                    
                    List<float> existingList = miDiccionario[currentUserString];
                    existingList.AddRange(cleanList);

                    miDiccionario[currentUserString] = existingList;

                }
            }
        }
        //else if (e.StreamName == DataStreamName.MentalCommands)
        //{

        //}
    }


    public void OnSafeData()
    {
        MostrarDiccionario(miDiccionario);


        List<float> existingList = miDiccionario[currentUserString];
        

        bigDatalList = string.Join(" ", existingList);
        Debug.Log(bigDatalList);

        JSONString stressDataJson = (JSONString)bigDatalList;
        Debug.Log(stressDataJson);

        string rutaArchivo = /*Application.dataPath + */"C:/Users/Jaime Ciriaco/Desktop/JsonConcordiaData";
        string rutaArchivoPlusName = rutaArchivo + $"/{currentUserString}ConcoridaData.txt";

        File.WriteAllText(rutaArchivoPlusName, stressDataJson.ToString());
        //else 

        

    }

    public static void MostrarDiccionario(Dictionary<string, List<float>> diccionario)
    {
        foreach (var item in diccionario)
        {
            Debug.Log($"{item.Key,-20} :");
            foreach (var valor in item.Value)
            {
                Debug.Log($" - {valor,10:F2}");
            }
        }
    }
}
