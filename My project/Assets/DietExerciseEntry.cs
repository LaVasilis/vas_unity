using System;

[Serializable]
public class DietExerciseEntry
{
    public string foodType;
    public int quantity;
    //public string exerciseType;
    //public float duration;
    public DateTime entryDate;




    public DietExerciseEntry(string foodType, int quantity)
    {
        this.foodType = foodType;
        this.quantity = quantity;
        //this.exerciseType = exerciseType;
        //this.duration = duration;
        this.entryDate = DateTime.Now;
    }
}