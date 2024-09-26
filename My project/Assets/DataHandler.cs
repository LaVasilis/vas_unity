using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;  // ������������� �� Newtonsoft.Json ��� ������ ���������� JSON

public class DataHandler : MonoBehaviour
{
    public InputField foodTypeInput;
    public InputField quantityInput;
  

    // ������������ ��� ����� ��� �� ������������� �� ��������
    private List<DietExerciseEntry> entries = new List<DietExerciseEntry>();

    // ���� �� function �� �������� ���� � ������� ������� �� ������ "����������"
    public void SaveEntry()
    {
        string foodType = foodTypeInput.text;
        float quantity = float.Parse(quantityInput.text);
        

        // ������������ ��� ��� ����������
        DietExerciseEntry newEntry = new DietExerciseEntry(foodType, quantity);

        // ����������� ��� ���������� ��� �����
        entries.Add(newEntry);

        Debug.Log("���������� ������������: " + foodType + ", " + quantity + ", "  + ", ");
    }


    public void SaveDataToJson()
    {
        string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
        File.WriteAllText(Application.persistentDataPath + "/dietExerciseData.json", json);

        Debug.Log("�������� ������������� �� JSON: " + json);
    }
}






