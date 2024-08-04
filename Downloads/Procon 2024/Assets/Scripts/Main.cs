using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;
using System;
using System.Text.RegularExpressions;

public class Main : MonoBehaviour
{
    
    public Text Matchtext;
    public GameObject Object;
    public Case Array;
    public Type Type;
    public Practice Practice;
    public List<List<int>> MatchInfo = new();
    public List<List<int>> MatchInfos = new();
    delegate List<List<int>> DieCutting(List<List<int>> Ques, float[,] Type, int PointX, int PointY);
    void Start()
    {
       Object = GameObject.Find("Scripts");
       Array = Object.GetComponent<Case>();
       Type = Object.GetComponent<Type>();
       Practice = Object.GetComponent<Practice>();
        float[,] Test = new float[4, 3]
        {
            {1, 1,0},
            {1, 0,0},
            {1, 1,1},
            {0, 1,1},
        };
       
        Matchcalculate();
    }
    void Matchcalculate()
    {
        float MAXmatch = 0f;
        int u = 0;
        var ques = new List<List<int>>();
        DieCutting DieCutting;
        while (u < 10)
        {
            for (int direction = 0; direction < 4; direction++)
            {
                
                if (direction == 0)
                {
                    DieCutting = Array.DieCuttingUP;
                }
                else if (direction == 1)
                {
                    DieCutting = Array.DieCuttingDown;
                }
                else if (direction == 2)
                {
                    DieCutting = Array.DieCuttingLeft;
                }
                else
                {
                    DieCutting = Array.DieCuttingRight;
                }
                for (int i = 0; i < 281; i++)
                {
                    for (int y = 0; y < Practice.pieceY; y++)
                    {
                        for (int x = 0; x < Practice.pieceX; x++)
                        {
                            float MatchR = Check(Practice.Ans, DieCutting(Practice.Ques, Type.TypeList[i], x, y));
                            if (MatchR > MAXmatch)
                            {
                                MAXmatch = MatchR;
                                ques = DieCutting(Practice.Ques, Type.TypeList[i], x, y);
                                MatchInfo.Add(new List<int> { i, x, y, direction });
                            }

                        }
                    }
                }
            }
            Matchtext.text = MAXmatch.ToString();
            print(MAXmatch);
            u++;
        }
    }
    public float Check(List<List<int>> Ans, List<List<int>> Ques)
    {
        var mass = Practice.pieceX * Practice.pieceY;
        float match = 100f/mass;
        float matchR = 0;
        for (int y = 0; y < Practice.pieceY; y++)
        {
            for (int x = 0; x < Practice.pieceX; x++)
            {
                if (Ans[y][x] == Ques[y][x])
                {
                    matchR += match;
                }
               
            }
        }
        return matchR;
    }
    
}
