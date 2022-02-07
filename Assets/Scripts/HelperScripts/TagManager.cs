using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTags
{
    public const string MOVEMENT = "Movement";
    
    public const string PUNCH_1_TRIGGER = "Punch1";
    public const string PUNCH_2_TRIGGER = "Punch2";
    public const string PUNCH_3_TRIGGER = "Punch3";

    public const string KICK_1_TRIGGER = "Kick1";
    public const string KICK_2_TRIGGER = "Kick2";

    public const string IDLE_ANIMATION = "Idle";

    public const string KNOCK_DOWN_TRIGGER = "KnockDown";
    public const string GET_UP_TRIGGER = "GetUp";
    public const string HIT_TRIGGER = "Hit";
    public const string DEATH_TRIGGER = "Death";
}

public class AnimationNames
{
    public const string PUNCH_1 = "Punch 1";
    public const string PUNCH_2 = "Punch 2";
    public const string PUNCH_3 = "Punch 3";

    public const string KICK_1 = "Kick 1";
    public const string KICK_2 = "Kick 2";
}

public class ObjectNames
{
    public const string UI_MANAGER = "UIManager";
    public const string PLAYER_1 = "Player1";
    public const string PLAYER_2 = "Player2";
    public const string PLAYER_1_HEALTH_UI = "Player1Image/HealthForeground";
    public const string PLAYER_2_HEALTH_UI = "Player2Image/HealthForeground";
    public const string SOUND_MANAGER = "SoundManager";
}

public class Axis
{
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
}

public class Tags
{
    public const string GROUND_TAG = "Ground";
    public const string PLAYER_TAG = "Player";

    public const string RIGHT_HAND_TAG = "RightHand";
    public const string RIGHT_TOE_TAG = "RightToe";
    public const string UNTAGGED_TAG = "Untagged";
    public const string MAIN_CAMERA_TAG = "MainCamera";
    public const string HEALTH_UI = "HealthUI";
}

public class Layers
{
    public const int DEFAULT_LAYER = 0;
    public const int PLAYER1_LAYER = 6;
    public const int PLAYER2_LAYER = 7;
}

public class Direction
{
    public int horizontal { get; set; } // { -1, 0, 1 }
    public int vertical { get; set; }   // { -1, 0, 1 }

    public override int GetHashCode() 
    {  
        return horizontal + 3 * vertical; 
    }

    public override bool Equals(object obj) 
    { 
        return Equals(obj as Direction); 
    }
    public bool Equals(Direction obj)
    {
        return obj != null && obj.horizontal == this.horizontal && obj.vertical == this.vertical; 
    }
    public Direction(int h, int v)
    {
        horizontal = h;
        vertical = v;
    }
    
}

public class Directions
{
    public static Direction UP = new Direction(0, 1);
    public static Direction UP_RIGHT = new Direction(1, 1);
    public static Direction RIGHT = new Direction(1, 0);
    public static Direction DOWN_RIGHT = new Direction(1, -1);
    public static Direction DOWN = new Direction(0, -1);
    public static Direction DOWN_LEFT = new Direction(-1, -1);
    public static Direction LEFT = new Direction(-1, 0);
    public static Direction UP_LEFT = new Direction(-1, 1);
}


public class Movement
{
    private static float ROTATION_FACTOR = 45f;
    
    public static Dictionary<Direction, float> ROTATION_Y = new Dictionary<Direction, float>
    {
        {Directions.UP,         -4 * ROTATION_FACTOR },  
        {Directions.UP_RIGHT,   -3 * ROTATION_FACTOR },  
        {Directions.RIGHT,      -2 * ROTATION_FACTOR },  
        {Directions.DOWN_RIGHT, -1 * ROTATION_FACTOR },  
        {Directions.DOWN,        0 * ROTATION_FACTOR },  
        {Directions.DOWN_LEFT,   1 * ROTATION_FACTOR },  
        {Directions.LEFT,        2 * ROTATION_FACTOR },  
        {Directions.UP_LEFT,     3 * ROTATION_FACTOR },  
    };
}           
