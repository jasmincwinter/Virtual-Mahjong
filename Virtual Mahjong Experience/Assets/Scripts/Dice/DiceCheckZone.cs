using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZone : MonoBehaviour
{
    Vector3 diceVelocity;

    void FixedUpdate ()
    {
        diceVelocity = Dice.diceVelocity;
    }

    private void OnTriggerStay(Collider col)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            switch (col.gameObject.name)
            {
                case "Side 1":
                    break;
                case "Side 2":
                    break;
                case "Side 3":
                    break;
                case "Side 4":
                    break;
                case "Side 5":
                    break;
                case "Side 6":
                    break;
            }
        }
    }
}
