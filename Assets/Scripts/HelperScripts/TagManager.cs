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
    public const string WINNER_MESSAGE_TEXT = "FinishScreen/WinnerText";
    public const string BLOCK_AREA = "BlockArea";
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
    public const string LADDER_TAG = "Ladder";

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

public class PlayerPrefsKeys
{
    public const string P1_UP = "P1_UP";
    public const string P1_DOWN = "P1_DOWN";
    public const string P1_LEFT = "P1_LEFT";
    public const string P1_RIGHT = "P1_RIGHT";
    
    public const string P1_PUNCH = "P1_PUNCH";
    public const string P1_KICK = "P1_KICK";
    
    public const string P2_UP = "P2_UP";
    public const string P2_DOWN = "P2_DOWN";
    public const string P2_LEFT = "P2_LEFT";
    public const string P2_RIGHT = "P2_RIGHT";
    
    public const string P2_PUNCH = "P2_PUNCH";
    public const string P2_KICK = "P2_KICK";

    public const string VFX_VOLUME = "VFX_VOLUME";
    public const string MUSIC_VOLUME = "MUSIC_VOLUME";

    public const string PAUSE = "PAUSE";
}

public class Storage
{
    public static Dictionary<string, string> Keys = new Dictionary<string, string>()
    {
        {PlayerPrefsKeys.P1_UP, KeyCode.W.ToString()},
        {PlayerPrefsKeys.P1_DOWN, KeyCode.S.ToString()},
        {PlayerPrefsKeys.P1_LEFT, KeyCode.A.ToString()},
        {PlayerPrefsKeys.P1_RIGHT, KeyCode.D.ToString()},
        
        {PlayerPrefsKeys.P1_PUNCH, KeyCode.F.ToString()},
        {PlayerPrefsKeys.P1_KICK, KeyCode.G.ToString()},
        
        {PlayerPrefsKeys.P2_UP, KeyCode.UpArrow.ToString()},
        {PlayerPrefsKeys.P2_DOWN, KeyCode.DownArrow.ToString()},
        {PlayerPrefsKeys.P2_LEFT, KeyCode.LeftArrow.ToString()},
        {PlayerPrefsKeys.P2_RIGHT, KeyCode.RightArrow.ToString()},
        
        {PlayerPrefsKeys.P2_PUNCH, KeyCode.Keypad1.ToString()},
        {PlayerPrefsKeys.P2_KICK, KeyCode.Keypad2.ToString()},
        
        {PlayerPrefsKeys.PAUSE, KeyCode.P.ToString()}
    };
    
    public static Dictionary<string, float> Volumes = new Dictionary<string, float>()
    {
        {PlayerPrefsKeys.VFX_VOLUME, 1},
        {PlayerPrefsKeys.MUSIC_VOLUME, 1},
    };

    public static void SetKey(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        Keys[key] = value;
    }

    public static void SetVolume(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        Volumes[key] = value;
    }
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
