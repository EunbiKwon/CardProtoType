using UnityEngine;
using System.Collections;

public class AtkType : MonoBehaviour
{
	public void FrontAtk(int _space, int _first)
    {
        if(0 == _first)
        {
            // 적에게 데미지
            if (null != GameManager.Instance.Another_List[_space])
            {
                GameManager.Instance.Another_List[_space].Hp -=
                GameManager.Instance.Player_List[_space].Atk;
            }
            else
            {
                GameManager.Instance.Another_Main.Hp -=
                GameManager.Instance.Player_List[_space].Atk;
            }
        }
        else if(1 == _first)
        {
            // 나에게 데미지
            if(null != GameManager.Instance.Player_List[_space])
            {
                GameManager.Instance.Player_List[_space].Hp -=
                GameManager.Instance.Another_List[_space].Atk;
            }
            else
            {
                GameManager.Instance.Player_Main.Hp -=
                GameManager.Instance.Another_List[_space].Atk;
            }
        }
    }

    public void SideAtk(int _space, int _first)
    {
        int num = 0;

        if (0 == _first)
        {
            // 적에게 데미지
            if (_space - 1 >= 0)
            {
                GameManager.Instance.Another_List[_space-1].Hp -=
                    GameManager.Instance.Player_List[_space].Atk;
                num++;
            }
            if(_space + 1 < 5)
            {
                GameManager.Instance.Another_List[_space+1].Hp -=
                    GameManager.Instance.Player_List[_space].Atk;
                num++;
            }
            if(0 == num)
            {
                GameManager.Instance.Another_Main.Hp -=
                GameManager.Instance.Player_List[_space].Atk;
            }
        }
        else if (1 == _first)
        {
            // 나에게 데미지
            if (_space - 1 >= 0)
            {
                GameManager.Instance.Another_List[_space - 1].Hp -=
                    GameManager.Instance.Player_List[_space].Atk;
                num++;
            }
            if (_space + 1 < 5)
            {
                GameManager.Instance.Another_List[_space + 1].Hp -=
                    GameManager.Instance.Player_List[_space].Atk;
                num++;
            }
            if(0 == num)
            {
                GameManager.Instance.Player_Main.Hp -=
                GameManager.Instance.Another_List[_space].Atk;
            }
        }
    }

    public void AnotherAtk(int _space, int _first)
    {
        int num = 0;

        if (0 == _first)
        {
            // 적에게 데미지
            for (int i = 0; i < 5; i++)
            {
                if (_space != i && null != GameManager.Instance.Another_List[i])
                {
                    GameManager.Instance.Another_List[i].Hp -=
                    GameManager.Instance.Player_List[_space].Atk;
                    num++;
                }
            }
            if(0 == num)
            {
                GameManager.Instance.Another_Main.Hp -=
                GameManager.Instance.Player_List[_space].Atk;
            }
        }
        else if (1 == _first)
        {
            // 나에게 데미지
            for (int i = 0; i < 5; i++)
            {
                if (_space != i && null != GameManager.Instance.Another_List[i])
                {
                    GameManager.Instance.Player_List[i].Hp -=
                    GameManager.Instance.Another_List[_space].Atk;
                    num++;
                }
            }
            if (0 == num)
            {
                GameManager.Instance.Player_Main.Hp -=
                GameManager.Instance.Another_List[_space].Atk;
            }
        }
    }
}
