using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Type : MonoBehaviour
{
    public float[][,] TypeList = new float[281][,];
    float i;
    float j;
    int k = 1;
    public UnityEngine.UI.Text Matchtext;
    void Awake()
    {
        for (var i = 0; i < 256; i++)
        {
            TypeList[i] = new float[UnityEngine.Random.Range(1, 257), UnityEngine.Random.Range(1, 257)];      
            for (int y = 0; y < TypeList[i].GetLength(1); y++)
            {
                for (int x = 0; x < TypeList[i].GetLength(0); x++)
                {
                    TypeList[i][x,y] = UnityEngine.Random.Range(0, 2);
                }
            }
        }
        TypeList[256] = new float[1, 1]{
            
            { 1 }
        };
        for (i = 1, j = 2; j <= 256; i++,j=  Mathf.Pow(2,i))
        {
            for (int l = 1; k<=3*i; k++,l++)
            {
                
                TypeList[k + 256] = new float[(int)j, (int)j];
                TypeList[k + 256] = Typeassignment(TypeList[k + 256], l);
            }
        }
    }
    
float[,] Typeassignment(float[,] Case,int Type)
    {
        if (Type == 1)
        {
            for (int y = 0; y < Case.GetLength(1); y++)
            {
                for (int x = 0; x < Case.GetLength(0); x++)
                {
                    Case[x, y] = 1;
                }

            }
            
           
        }
        else if(Type == 2)
        {
            for (int y = 0; y < Case.GetLength(1); y+=2)
            {
                for (int x = 0; x < Case.GetLength(0); x++)
                {
                   
                    Case[x, y] = 1;
                }
            }
        }
        else if (Type == 3)
        {
            for (int y = 0; y < Case.GetLength(1); y++)
            {
                for (int x = 0; x < Case.GetLength(0); x+= 2)
                {
                   
                    Case[x, y] = 1;
                }
            }
        }

        return Case;
    }
}
    