using UnityEngine;
using System.Collections;
using System.Collections.Generic; // List
using System.Xml; // Xml

public class Card_Info
{
    public int Atk;
    public int AtkType;
    public int Cost;
    public int Speed;
    public string Name;
    public string Text;
}

public class CardDataParse : MonoBehaviour
{
    public static List<Card_Info> InfoList = new List<Card_Info>(); // info save list

    /*
    void Start ()
    {
        InfoList = Read("CardData");
    }
    */

    public static List<Card_Info> Read(string filepath)
    {
        TextAsset data_xml = (TextAsset)Resources.Load(filepath, typeof(TextAsset));
        XmlDocument Document = new XmlDocument();
        Document.LoadXml(data_xml.text);

        XmlElement InfoListElement = Document["Data"];

        List<Card_Info> CardList = new List<Card_Info>();

        //foreach (XmlElement InfoElement in InfoListElement.ChildNodes)
        for (int i = 0; i < InfoListElement.ChildNodes.Count; i++)
        {
            Card_Info Info = new Card_Info();
            Info.Name = System.Convert.ToString(InfoListElement.GetAttribute("Name"));
            Info.Cost = System.Convert.ToInt32(InfoListElement.GetAttribute("Cost"));
            Info.Speed = System.Convert.ToInt32(InfoListElement.GetAttribute("Speed"));
            Info.Atk = System.Convert.ToInt32(InfoListElement.GetAttribute("Atk"));
            Info.AtkType = System.Convert.ToInt32(InfoListElement.GetAttribute("AtkType"));
            Info.Text = System.Convert.ToString(InfoListElement.GetAttribute("Text"));

            CardList.Add(Info);
            Debug.Log(Info.Name);
        }
        return CardList;
    }
}
