using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class DataHandler : MonoBehaviour
{
    // UI Input Fields for meals
    public InputField breakfastInput;
    public InputField lunchInput;
    public InputField dinnerInput;

    // UI Dropdowns for quantity
    public Dropdown breakfastQuantityDropdown;
    public Dropdown lunchQuantityDropdown;
    public Dropdown dinnerQuantityDropdown;

    // UI Dropdowns for exercises
    public Dropdown firstExerciseDropdown;
    public Dropdown secondExerciseDropdown;
    public Dropdown thirdExerciseDropdown;

    // Text fields for the summary menu
    public Text summaryCaloriesText;
    public Text summaryExerciseText;

    public GameObject menuCanvas;

    public MonoBehaviour playerMovement;

    // Store the entries in a list
    private List<DietExerciseEntry> entries = new List<DietExerciseEntry>();

    // Function to handle "Submit"
    public void SaveEntryAndShowSummary()
    {
        // Get food inputs
        string breakfast = breakfastInput.text;
        string lunch = lunchInput.text;
        string dinner = dinnerInput.text;

        // Get selected quantities from dropdowns
        int breakfastQuantity = int.Parse(breakfastQuantityDropdown.options[breakfastQuantityDropdown.value].text);
        int lunchQuantity = int.Parse(lunchQuantityDropdown.options[lunchQuantityDropdown.value].text);
        int dinnerQuantity = int.Parse(dinnerQuantityDropdown.options[dinnerQuantityDropdown.value].text);

        // Get selected exercises from dropdowns
        string firstExercise = firstExerciseDropdown.options[firstExerciseDropdown.value].text;
        string secondExercise = secondExerciseDropdown.options[secondExerciseDropdown.value].text;
        string thirdExercise = thirdExerciseDropdown.options[thirdExerciseDropdown.value].text;

        // Calculate calories (example calculation based on quantity)
        int breakfastCalories = CalculateCalories(breakfast, breakfastQuantity);
        int lunchCalories = CalculateCalories(lunch, lunchQuantity);
        int dinnerCalories = CalculateCalories(dinner, dinnerQuantity);

        // Total calories
        int totalCalories = breakfastCalories + lunchCalories + dinnerCalories;

        // Create a new entry
        DietExerciseEntry newEntry = new DietExerciseEntry(breakfast, lunch, dinner, breakfastQuantity, lunchQuantity, dinnerQuantity, firstExercise, secondExercise, thirdExercise);

        // Add the entry to the list
        entries.Add(newEntry);

        // Save data to JSON
        SaveDataToJson();

        // Display the summary in another menu
        ShowSummary(totalCalories, firstExercise, secondExercise, thirdExercise);

        menuCanvas.SetActive(false);
        playerMovement.enabled = true;
    }

    // Function to calculate calories (You can modify this logic as needed)
    private int CalculateCalories(string foodType, int quantity)
    {
        // Example logic: 1 gram = 2 calories (adjust based on your needs)
        return quantity * 2;
    }

    // Show summary in the other menu (calories and exercises)
    private void ShowSummary(int totalCalories, string breakfastExercise, string lunchExercise, string dinnerExercise)
    {
        summaryCaloriesText.text = "Total Calories: " + totalCalories;
        summaryExerciseText.text = "Exercises: \nBreakfast: " + breakfastExercise + "\nLunch: " + lunchExercise + "\nDinner: " + dinnerExercise;
    }

    // Save the data to JSON (this saves the entire list of entries)
    private void SaveDataToJson()
    {
        string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
        File.WriteAllText(Application.persistentDataPath + "/dietExerciseData.json", json);
        Debug.Log("Data saved to JSON: " + json);
    }
}
