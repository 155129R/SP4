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
        NIL,
        CASTOR,
        POLLUX,
    }

    private GameState m_GameState = GameState.Game_STATE;

    private Character m_Character = Character.POLLUX;

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
	void Start ()
    {
        //m_GameState = GameState.Game_STATE;
        //m_Character = Character.POLLUX;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
