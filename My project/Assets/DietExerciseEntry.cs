using System;

[Serializable]
public class DietExerciseEntry
{
    public string foodType;
    public float quantity;
    
    
  

    public DietExerciseEntry(string foodType, float quantity)
    {
        this.foodType = foodType;
        this.quantity = quantity;
        
    }
}