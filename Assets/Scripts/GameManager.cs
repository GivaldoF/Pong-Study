using UnityEngine;

public class GameManager : MonoBehaviour
{
    // the game has 5 phases in any order
    // phase 1 - ball increase speed
    // phase 2 - paddle size down
    // phase 3 - more balls
    // phase 4 - paddles move a little bit horizontally for second or hit
    // phase 5 - trigger 2 or more phases in same time
    
    // score goal - 999
    // score goal/5 = 199,999
    // phase 1 - 0
    // phase 2 - 100 + random(50, 100)
    // phase 3 - 200 + random (-50, 50)
    // phase 4 - 300 + random (-50, 50)
    // phase 4 - 500 + random (-50, 50)
    
    
}
