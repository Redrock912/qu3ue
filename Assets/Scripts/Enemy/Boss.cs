using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    int resetTimer;

    public override void SetupData()
    {
        base.SetupData();
        resetTimer = skillTimer;
    }


    public override void Attack(Characters character)
    {
        skillTimer--;
        print(skillTimer);
        if(skillTimer <= 0)
        {
            Skill(skillType , character);
           
        }
        else
        {
            base.Attack(character);
        }
        
    }


    public void Skill(int type, Characters character)
    {
        print("We are in! " + type);
        switch (type)
        {
            case 1:
                attack += 3;
                base.Attack(character);
                print("case 1 ");
                break;
            default:
                break;
        }

        skillTimer = resetTimer;
    }
}
