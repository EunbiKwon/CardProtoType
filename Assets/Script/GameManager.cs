using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    const int ROUND = 6;
    const int SPEED = 6;

    private CardObject Player_Main;     // Player Main Character
    private CardObject Another_Main;    // Other Main Character
    private List<CardObject> Player_List = new List<CardObject>();   // Player field card
    private List<CardObject> Another_List = new List<CardObject>();   // Other field card

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
        Player_Main = new CardObject();
        Another_Main = new CardObject();

        // 플레이어 카드 선택 일단 보류
        // 프로토타입이라 일단 리스트 가져오겟슴
        Player_List = CardManager.getInstance.Player_Card;
        Another_List = CardManager.getInstance.Another_Card;
    }

    void Battle(int _round)
    {
        for(int i = 0; i < SPEED; i++)
        {
            // 선공 안정해서 일단 플레이어부터 공격
            if(0 == (Player_List[i].Speed % (i+1)))
            {

            }
        }
    }

    void Change()
    {

    }
}
