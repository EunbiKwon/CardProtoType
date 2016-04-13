using UnityEngine;
using System.Collections;

enum CARD_TYPE
{
    // 타입 추가
};

public class CardObject : MonoBehaviour
{
    private int m_Atk;
    public int Atk
    {
        get { return m_Atk; }
        set { m_Atk = Atk; }
    }
    private int m_Hp;
    public int Hp
    {
        get { return m_Hp; }
        set { m_Hp = Hp; }
    }
    private int m_Cost;
    public int Cost
    {
        get { return m_Cost; }
        set { m_Cost = Cost; }
    }
    private int m_Speed;
    public int Speed
    {
        get { return m_Speed; }
        set { m_Speed = Speed; }
    }
    private string m_Name;
    public string Name
    {
        get { return m_Name; }
        set { m_Name = Name; }
    }
    private string m_Text;
    public string Text
    {
        get { return m_Text; }
        set { m_Text = Text; }
    }
    private int m_Type;
    public int Type
    {
        get { return m_Type; }
        set { m_Type = Type; }
    }
}
