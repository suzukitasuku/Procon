using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;


public class Practice : MonoBehaviour
{
    
    public Text Questext;
    public Text Anstext;
    public int pieceX;
    public int pieceY;
    public List<List<int>> Ans = new();
    public List<List<int>> Ques = new();
    public void Awake()
    {
        Question();
        Answer(Ans);
        Indication(Ans, Anstext);
        Indication(Ques, Questext);
    }

    public void Question()
    {
        for (int y = 0; y < pieceY; y++)
        {
            List<int> Ansone = new();
            for (int x = 0; x < pieceX; x++)
            {
                Ansone.Add(UnityEngine.Random.Range(0, 4));
            }
            Ans.Add(Ansone);

        }
        
      
    }
    public void Answer(List<List<int>> Ans)
    {

        System.Random rand = new();
        List<List<int>> AnsChange = new();
        List<int> shufle = new();
        int j = 0;
        for (int y = 0; y < pieceY; y++)
        {
            for (int x = 0; x < pieceX; x++)
            {
                shufle.Add(Ans[y][x]);
            }
        }
        List<int> result = shufle.OrderBy(x => rand.Next()).ToList();
        for (int y = 0; y < pieceY; y++)
        {
            List<int> Quesone = new();
            for (int x = 0; x < pieceX; x++, j++)
            {
                Quesone.Add(result[j]);
            }
            Ques.Add(Quesone);
        }
    }
    public void Indication(List<List<int>> Ans, Text text)
    {
        text.text = "";
        for (int y = 0; y < Ans.Count(); y++)
        {

            for (int x = 0; x < Ans[0].Count(); x++)
            {
                text.text += Ans[y][x].ToString();
            }

            text.text += "\n";

        }
    }


}
