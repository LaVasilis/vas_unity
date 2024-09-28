using System;

[Serializable]
public class DietExerciseEntry
{
    public string breakfast;
    public string lunch;
    public string dinner;
    public int breakfastQuantity;
    public int lunchQuantity;
    public int dinnerQuantity;
    public string firstExercise;
    public string secondExercise;
    public string thirdExercise;
    public DateTime entryDate;

    public DietExerciseEntry(string breakfast, string lunch, string dinner, int breakfastQuantity, int lunchQuantity, int dinnerQuantity, string firstExercise, string secondExercise, string thirdExercise)
    {
        this.breakfast = breakfast;
        this.lunch = lunch;
        this.dinner = dinner;
        this.breakfastQuantity = breakfastQuantity;
        this.lunchQuantity = lunchQuantity;
        this.dinnerQuantity = dinnerQuantity;
        this.firstExercise = firstExercise;
        this.secondExercise = secondExercise;
        this.thirdExercise = thirdExercise;
        this.entryDate = DateTime.Now;
    }
}
