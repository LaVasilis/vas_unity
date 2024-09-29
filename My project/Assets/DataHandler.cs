using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System;
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


    public Text entryDateText;

    public void DisplayEntryDate(DateTime entryDate)
    {
        
        string formattedDate = entryDate.ToString("MMMM dd, yyyy hh:mm tt"); // Example: September 29, 2024 08:30 PM
        
        entryDateText.text = "" + formattedDate;
    }

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
        DisplayEntryDate(newEntry.entryDate);


        // Display the summary in another menu
        ShowSummary(totalCalories, firstExercise, secondExercise, thirdExercise);

        menuCanvas.SetActive(false);
        playerMovement.enabled = true;
    }

    // Function to calculate calories
    private int CalculateCalories(string foodType, int quantity)
    {
        
        return quantity * 3;
    }

    // Show summary in the other menu 
    private void ShowSummary(int totalCalories, string cardioExercise, string freeweightsExercise, string machinesExercise)
    {
        summaryCaloriesText.text = "" + totalCalories;
        summaryExerciseText.text = "Cardio: " + cardioExercise + "\nFree weights: " + freeweightsExercise + "\nMachines: " + machinesExercise;

    }

    public void CloseUI()
    {

        menuCanvas.SetActive(false);

    }



}
