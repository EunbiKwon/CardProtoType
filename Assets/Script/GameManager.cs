using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    const int ROUND = 6;
    const int SPEED = 6;

    private int Player_Cost;
    private int Another_Cost;

    // GameObject
    public GameObject PlayerMObj;
    public GameObject AnotherMObj;
    public GameObject[] PlayerLObj = new GameObject[5];
    public GameObject[] AnotherLObj = new GameObject[5];

    // CardInfo
    public CardObject Player_Main;     // Player Main Character
    public CardObject Another_Main;    // Other Main Character
    public CardObject[] Player_List = new CardObject[5];   // Player field card
    public CardObject[] Another_List = new CardObject[5];  // Other field card

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }

            if (instance == null)
            {
                GameObject obj = new GameObject("GameManager");
                instance = obj.AddComponent<GameManager>() as GameManager;
            }

            return instance;
        }
    }

    void Awake ()
    {
        Init();
	}
	
	void Update ()
    {
	    // 게임 순서 Init -> Battle -> Change
        // 그 뒤로는 메인 캐릭이 체력이 0이하가 될 때까지 Battle -> Change 반복

        while( Player_Main.Hp > 0 && Another_Main.Hp > 0 )
        {
            for (int i = 0; i < ROUND; i++)
            {
                Battle(i);
            }
        }
	}

    void Init()
    {
        Player_Cost = 0;
        Another_Cost = 0;
        Player_Main = new CardObject();
        Another_Main = new CardObject();

        // 플레이어 카드 선택 일단 보류
        // 프로토타입이라 일단 리스트 가져오겟슴
        //Player_List = CardManager.getInstance.Player_Card;
        //Another_List = CardManager.getInstance.Another_Card;
    }

    void Battle(int _round)
    {
        for(int i = 0; i < SPEED; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                // 똑같으면 확률
                if (null != Player_List[j] && null != Another_List[j])
                {
                    if(0 == Player_List[j].sCount && 0 == Another_List[j].sCount)
                    {
                        int rand = Random.Range(0, 1);
                        /*
                        if (0 == rand)
                            Player_List[j];
                        else
                            Another_List[j];
                        */
                    }
                    //Player_List[j].sCount = Player_List[j].Speed;
                }

                if (null != Player_List[j].Name && 0 == Player_List[j].sCount)
                {
                    Player_List[j].sCount = Player_List[j].Speed;
                }
                else if (null != Player_List[j].Name)
                {
                    Player_List[j].sCount--;
                }
                else { }
            }
        }
        ++Player_Cost;
        ++Another_Cost;
    }

    void Change()
    {

    }
}
