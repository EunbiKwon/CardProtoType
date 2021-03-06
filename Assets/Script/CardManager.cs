﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml; // Xml

public class CardManager : MonoBehaviour
{
    // Singleton
    private static CardManager instance;
    public static CardManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(CardManager)) as CardManager;
            }

            if (instance == null)
            {
                GameObject obj = new GameObject("CardManager");
                instance = obj.AddComponent<CardManager>() as CardManager;
            }

            return instance;
        }
    }

    public List<CardObject> Player_Card = new List<CardObject>();
    public List<CardObject> Another_Card = new List<CardObject>();  // Temp

    private void Awake ()
    {
        Player_Card = Setting("PlayerData");
        Another_Card = Setting("PlayerData"); // Temp
    }

    public static List<CardObject> Setting(string filepath)
    {
        TextAsset data_xml = (TextAsset)Resources.Load(filepath, typeof(TextAsset));
        XmlDocument Document = new XmlDocument();
        Document.LoadXml(data_xml.text);
        
        XmlElement InfoListElement = Document["CardData"];
        //XmlNode root = Document.DocumentElement;

        List<CardObject> SetList = new List<CardObject>(); // 사용자 카드
        List<CardObject> CardList = new List<CardObject>(); // 카드 리스트

        Debug.Log(InfoListElement.ChildNodes[0].InnerText);

        // Card Data Init
        CardList = DataInfoRead("CardData");

        // Player Card Info Setting
        //for (int i = 0; i < InfoListElement.ChildNodes.Count; i++)
        foreach (XmlElement InfoElement in InfoListElement.ChildNodes)
        {
            CardObject Info = new CardObject();
            // Card name list Input
            Info.Name = InfoListElement.GetAttribute("Name");

            // Data Input
            for(int j = 0; j < CardList.Count; j++)
            {
                if(Info.Name == CardList[j].Name)
                {
                    Info = CardList[j];
                    break;
                }
            }

            CardList.Add(Info);
        }
        
        return SetList;
    }

    public static List<CardObject> DataInfoRead(string filepath)
    {
        TextAsset data_xml = (TextAsset)Resources.Load(filepath, typeof(TextAsset));
        XmlDocument Document = new XmlDocument();
        Document.LoadXml(data_xml.text);

        XmlElement InfoListElement = Document["Data"];
        //XmlNode root = Document.DocumentElement;

        List<CardObject> CardList = new List<CardObject>();

        //for (int i = 0; i < InfoListElement.ChildNodes.Count; i++)
        foreach (XmlElement InfoElement in InfoListElement.ChildNodes)
        {
            CardObject Info = new CardObject();
            Info.Name = InfoListElement.GetAttribute("Name");
            Info.Cost = System.Convert.ToInt32(InfoListElement.GetAttribute("Cost"));
            Info.Speed = System.Convert.ToInt32(InfoListElement.GetAttribute("Speed"));
            Info.Atk = System.Convert.ToInt32(InfoListElement.GetAttribute("Atk"));
            Info.Type = System.Convert.ToInt32(InfoListElement.GetAttribute("AtkType"));
            Info.Text = System.Convert.ToString(InfoListElement.GetAttribute("Text"));

            CardList.Add(Info);
            Debug.Log(Info.Name);
        }
        return CardList;
    }
}
