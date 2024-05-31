using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;







public class stop_working : MonoBehaviour
{
    public bool stop_warning=false;
    public string jsonURL;
    public Jsonclass jsnData;
    public TMP_Text window;
    public TMP_Text window_copy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator getData()
    {
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "Stop.json");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("ERROR");
        }
        else
        {
            Debug.Log("Downolad saved to: " + resultFile);
            string jsonToRead = File.ReadAllText(Application.persistentDataPath + "/Stop.json");
            jsnData = JsonUtility.FromJson<Jsonclass>(jsonToRead);
            stop_warning = jsnData.Stop;
            if (stop_warning == true)
            {
                
                window.SetText("Скорее снимите с себя VR - оборудование");
            }
            else
            {
                Debug.Log("Зашел");
                window.SetText(window_copy.text);
            }
            yield return StartCoroutine(getData());
        }

    }
    [System.Serializable]

    public class Jsonclass
    {
        public bool Stop;
    }
}

