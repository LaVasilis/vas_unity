using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;  // Χρησιμοποίησε το Newtonsoft.Json για εύκολη διαχείριση JSON

public class DataHandler : MonoBehaviour
{
    public InputField foodTypeInput;
    public InputField quantityInput;
  

    // Δημιουργούμε μια λίστα για να αποθηκεύσουμε τα δεδομένα
    private List<DietExerciseEntry> entries = new List<DietExerciseEntry>();

    // Αυτό το function θα καλείται όταν ο χρήστης πατήσει το κουμπί "Καταχώρηση"
    public void SaveEntry()
    {
        string foodType = foodTypeInput.text;
        float quantity = float.Parse(quantityInput.text);
        

        // Δημιουργούμε μια νέα καταχώρηση
        DietExerciseEntry newEntry = new DietExerciseEntry(foodType, quantity);

        // Προσθέτουμε την καταχώρηση στη λίστα
        entries.Add(newEntry);

        Debug.Log("Καταχώρηση αποθηκεύτηκε: " + foodType + ", " + quantity + ", "  + ", ");
    }


    public void SaveDataToJson()
    {
        string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
        File.WriteAllText(Application.persistentDataPath + "/dietExerciseData.json", json);

        Debug.Log("Δεδομένα αποθηκεύτηκαν σε JSON: " + json);
    }
}






