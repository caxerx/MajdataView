using UnityEngine;
using MajdataEdit;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

class BrowserCommunicationHandler : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(1);
    }

    void OnDestroy()
    {
        
    }

    public void LoadJsonFromWebsite(string request)
    {
        var loader = GameObject.Find("DataLoader").GetComponent<JsonDataLoader>();
        var timeProvider = GameObject.Find("AudioTimeProvider").GetComponent<AudioTimeProvider>();

        var level = "";

        SimaiProcess.ReadData(request);
        for (int i = 0; i < SimaiProcess.fumens.Length; i++)
        {
            if (!string.IsNullOrEmpty(SimaiProcess.fumens[i]))
            {
                level = SimaiProcess.levels[i];
                SimaiProcess.Serialize(SimaiProcess.fumens[i]);
                print(i);
                print(level);
                print(JsonConvert.SerializeObject(SimaiProcess.fumens));
                print(SimaiProcess.fumens[i]);
                print(JsonConvert.SerializeObject(SimaiProcess.notelist));
                print(JsonConvert.SerializeObject(SimaiProcess.timinglist));
                break;
            }
        }

        if (string.IsNullOrEmpty(level))
        {
            print("Failed to load majdata");
            return;
        }


        var jsonStruct = new Majson();

        foreach (var note in SimaiProcess.notelist)
        {
            note.noteList = note.getNotes();
            jsonStruct.timingList.Add(JsonConvert.DeserializeObject<SimaiTimingPoint>(JsonConvert.SerializeObject(note)));
        }
        jsonStruct.level = level;

        var data =
        new
        {
            startAt = System.DateTime.Now.Ticks,
            startTime = 0,
            audioSpeed = 1,
            noteSpeed = 8.5f,
            touchSpeed = 8.5f,
            json = JsonConvert.SerializeObject(jsonStruct)
        };


        timeProvider.SetStartTime(data.startAt, data.startTime, data.audioSpeed);
        loader.noteSpeed = (float)(107.25 / (71.4184491 * Mathf.Pow(data.noteSpeed + 0.9975f, -0.985558604f)));
        loader.touchSpeed = data.touchSpeed;
        loader.LoadJson(data.json, data.startTime);
        GameObject.Find("Notes").GetComponent<PlayAllPerfect>().enabled = false;
        GameObject.Find("MultTouchHandler").GetComponent<MultTouchHandler>().clearSlots();
    }

}
