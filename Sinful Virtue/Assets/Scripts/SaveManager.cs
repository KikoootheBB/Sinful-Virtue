using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public GameObject Player;
    public Transform Sin1;
    public Transform Sin2;
    public Transform Sin3;
    public Transform Sin4;
    public Transform Sin5;
    public Transform Sin6;
    public Transform Sin7;
    public List<GameObject> Virtues;

    public void SaveGame()
    {
        var state = new GameState();
        state.PlayerPositionX = Player.transform.position.x;
        state.PlayerPositionY = Player.transform.position.y;
        


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
            Player.transform.position = new Vector3(state.PlayerPositionX, state.PlayerPositionY, Player.transform.position.z);
            Sin1.position = new Vector3(state.Sin1PositionX, state.Sin1PositionY, Sin1.position.z);
            Sin2.position = new Vector3(state.Sin2PositionX, state.Sin2PositionY, Sin2.position.z);
            Sin3.position = new Vector3(state.Sin3PositionX, state.Sin3PositionY, Sin3.position.z);
            Sin4.position = new Vector3(state.Sin4PositionX, state.Sin4PositionY, Sin4.position.z);
            Sin5.position = new Vector3(state.Sin5PositionX, state.Sin5PositionY, Sin5.position.z);
            Sin6.position = new Vector3(state.Sin6PositionX, state.Sin6PositionY, Sin6.position.z);
            Sin7.position = new Vector3(state.Sin7PositionX, state.Sin7PositionY, Sin7.position.z);
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
        public float PlayerPositionX;
        public float PlayerPositionY;
        public float Sin1PositionX;
        public float Sin1PositionY;
        public float Sin2PositionX;
        public float Sin2PositionY;
        public float Sin3PositionX;
        public float Sin3PositionY;
        public float Sin4PositionX;
        public float Sin4PositionY;
        public float Sin5PositionX;
        public float Sin5PositionY;
        public float Sin6PositionX;
        public float Sin6PositionY;
        public float Sin7PositionX;
        public float Sin7PositionY;
        public List<bool> Virtues;
        public GameState()
        {
            Virtues = new List<bool>();
        }
    }
}
