using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public List<GameObject> Virtues;
    public void SaveGame()
    {
        var state = new GameState();
        foreach (GameObject item in Virtues)
        {
            state.Virtues.Add(item.activeSelf);
        }

        var filename = Path.Combine(Application.persistentDataPath, "game.sav");

        using (var stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
        {
            var serializer = new BinaryFormatter();
            serializer.Serialize(stream, state);
        }
    }
    public void LoadGame()
    {
        var filename = Path.Combine(Application.persistentDataPath, "game.sav");
        if (!File.Exists(filename))
        {
            Debug.LogWarning("No Saved Game");
            return;
        }
        using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            var serializer = new BinaryFormatter();
            GameState state = (GameState)serializer.Deserialize(stream);
            for (int i=0; i<state.Virtues.Count;i+=1)
            {
                var wasActiveOnSave = state.Virtues[i];
                Virtues[i].SetActive(wasActiveOnSave); 
            }
        }
    }

    [System.Serializable]
    public class GameState
    {
        public List<bool> Virtues;
        public GameState()
        {
            Virtues = new List<bool>();
        }
    }
}
