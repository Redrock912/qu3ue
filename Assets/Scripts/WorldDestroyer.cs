using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldDestroyer 
{
    

    //private void DifficultyMultiplier(float factor)
    //{
    //    destroyerMultiplier *= factor;
    //}


    public static int CalculateResult(int characters, float multiplierFactor , float characterMultiplier)
    {
        int destination = 10;
        
       // DifficultyMultiplier(multiplierFactor);
        if(characters == 0 || characters == 3)
        {
            destination = 10;
        }
        else
        {
            destination = (int)( destination - (characters * characterMultiplier));

            if(destination <= 0)
            {
                destination = 0;
            }
        }

        return (int)(destination * multiplierFactor);
    }
}
