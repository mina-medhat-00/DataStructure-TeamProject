using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minifying : MonoBehaviour
{
    public void Minify()
    {
        Debug.Log("did something");
        string str = GameObject.FindGameObjectWithTag("mainText").GetComponent<UnityEngine.UI.InputField>().text;
        str=str.Trim();
        str=str.Replace("\n", "");
        str = str.Replace("\r", "");

        for (int index = 0; index < str.Length; index++)
        {
            if(str[index]=='<')
            {
                if(str[++index]=='/')
                {
                    while(str[index]!='>')
                    {
                        index++;
                    }
                    int startingIndex = index+1;
                    int endingIndex = startingIndex;
                    while (index < str.Length)
                    {
                        if (str[index] != '<')
                        {
                            index++;
                            endingIndex = index;
                        }
                        else
                        {
                            break;

                        }

                    }
                    str = str.Remove(startingIndex, endingIndex - startingIndex);
                    index -= endingIndex - startingIndex;
                }

            }
        }
        Debug.Log(str);
        GameObject.FindGameObjectWithTag("mainText").GetComponent<UnityEngine.UI.InputField>().text = str;
    }
}
