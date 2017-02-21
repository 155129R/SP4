using UnityEngine;
using System.Collections;

public class GameStateManager : Singleton<GameStateManager>
{
   public enum GameState
    {
        DEFAULT_STATE,
        Game_STATE,

    };

    public enum Character
    {
        CASTOR,
        POLLUX,
        NIL,

    }

    private GameState m_GameState = GameState.Game_STATE;

    public Character m_Character = Character.NIL;

    public GameState GetGameState()
    {
        return m_GameState;
    }
    public void SetGameState(GameState input)
    {
        m_GameState = input;
    }
    public Character GetCharacterState()
    {
        return m_Character;
    }
    public void SetCharacter(Character input)
    {
        m_Character = input;
    }

    protected GameStateManager()//ensures singleton
    {

    }
        
	// Use this for initialization
	void Start()
    {
        if(PlayerPrefs.GetInt("Character")==0)
        {
            m_Character = Character.POLLUX;
        }
        else if (PlayerPrefs.GetInt("Character") == 1)
        {
            m_Character = Character.CASTOR;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        Debug.Log(PlayerPrefs.GetInt("Character"));
        Debug.Log(m_Character);
	}
}
