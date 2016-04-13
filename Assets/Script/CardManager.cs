using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml; // Xml

public class CardManager : MonoBehaviour
{
    public List<CardObject> Player_Card = new List<CardObject>();
    public List<CardObject> Another_Card = new List<CardObject>();

    void Awake ()
    {
        Player_Card = Setting("PlayerData");
        Another_Card = Setting("PlayerData"); // 임시

        // 카드 정보 파싱한 곳에서 찾아 데이터 집어넣기
    }

    public static List<CardObject> Setting(string filepath)
    {
        TextAsset data_xml = (TextAsset)Resources.Load(filepath, typeof(TextAsset));
        XmlDocument Document = new XmlDocument();
        Document.LoadXml(data_xml.text);

        XmlElement InfoListElement = Document["Data"];

        List<CardObject> CardList = new List<CardObject>();

        //foreach (XmlElement InfoElement in InfoListElement.ChildNodes)
        for (int i = 0; i < InfoListElement.ChildNodes.Count; i++)
        {
            CardObject Info = new CardObject();
            Info.Name = System.Convert.ToString(InfoListElement.GetAttribute("Name"));

            for(int j = 0; j < transform.Find("CardData").GetComponent<CardDataParse>.InfoList.Count; j++)
            {
                if(Info.Name == transform.Find("CardData").GetComponent<CardDataParse>.InfoList.Name)
                {
                    // 정보 넣기
                    break;
                }
            }

            CardList.Add(Info);
        }



        return CardList;
    }
}
