using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minifying : MonoBehaviour
{
    public void Minify()
    {
        string str = GameObject.FindGameObjectWithTag("mainText").GetComponent<UnityEngine.UI.InputField>().text;
        str=str.Trim();
        str=str.Replace("\n", "");
        str = str.Replace("\r", "");

        for (int index = 0; index < str.Length; index++)
        {
            bool flag = true;

            if (str[index]=='>')
            {
                int startingIndex = index+1;
                int endingIndex = startingIndex;
                index++;
                while (index < str.Length)
                {
                    if (str[index] != ' ')
                    {
                        flag = false;
                        break;
                    }

                    if (str[index] != '<')
                    {
                        endingIndex = index;
                        index++;
                    }

                    else
                    {
                        break;
                    }
                }


                if( !flag & endingIndex - startingIndex>0)
                {
                    str = str.Remove(startingIndex, endingIndex - startingIndex);
                    index -= endingIndex - startingIndex;
                }

            }
        }
        GameObject.FindGameObjectWithTag("mainText").GetComponent<UnityEngine.UI.InputField>().text = str;
    }
}
