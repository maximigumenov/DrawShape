using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Save
{
    public class SaveToTxt
    {
        string path = "Assets/Resources/Levels/";
        string format = ".txt";

        public void WriteString(string nameFile, string data)
        {
            string pathSave = path + nameFile + format;

            using (StreamWriter writer =
            new StreamWriter(pathSave))
            {
                writer.Write(data);
            }

        }

       
        public void ReadString(string nameFile, out string message)
        {
            TextAsset test = Resources.Load<TextAsset>("Levels/" + nameFile);
            message = test.text;
        }

    }
}
