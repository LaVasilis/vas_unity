using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;  // Χρησιμοποίησε το Newtonsoft.Json για εύκολη διαχείριση JSON

public class DataHandler : MonoBehaviour
{
    public InputField foodTypeInput;
    public InputField quantityInput;
    //public InputField exerciseTypeInput;
    //public InputField durationInput;
    public Dropdown quantityDropdown;


    // Δημιουργούμε μια λίστα για να αποθηκεύσουμε τα δεδομένα
    private List<DietExerciseEntry> entries = new List<DietExerciseEntry>();

    // Αυτό το function θα καλείται όταν ο χρήστης πατήσει το κουμπί "Καταχώρηση"
    public void SaveEntry()
    {
        string foodType = foodTypeInput.text;

        //string exerciseType = exerciseTypeInput.text;
        //float duration = float.Parse(durationInput.text);


        int quantity = int.Parse(quantityDropdown.options[quantityDropdown.value].text);

        // Create a new entry
        DietExerciseEntry newEntry = new DietExerciseEntry(foodType, quantity);

        // Add entry to the list
        entries.Add(newEntry);

        Debug.Log("Entry saved: " + foodType + ", " + quantity);
    }


    public void SaveDataToJson()
    {
        string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
        File.WriteAllText(Application.persistentDataPath + "/dietExerciseData.json", json);

        Debug.Log("Data saved to JSON: " + json);
    }

    // Optional method to load data from JSON
    public void LoadDataFromJson()
    {
        string filePath = Application.persistentDataPath + "/dietExerciseData.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            entries = JsonConvert.DeserializeObject<List<DietExerciseEntry>>(json);
            Debug.Log("Data loaded from JSON.");
        }
        else
        {
            Debug.LogWarning("No saved data found.");
        }
    }
}






