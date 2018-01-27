using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


namespace Save
{
    [System.Serializable]
    public class SaveObject : ISaveObject<SaveObject>
    {
        protected System.Type myType;
        protected string prefixSave = "SaveLoadController1";

        public void InitObject()
        {
            myType = this.GetType();
            SaveController.AddObj(this);
        }

        public void Load<U>(ref U loadObject)
        {
            StringBuilder nameSave = new StringBuilder();
            nameSave.Append(prefixSave);
            nameSave.Append(myType.ToString());
            nameSave.Append(SaveController.GetNumSave());
            if (PlayerPrefs.HasKey(nameSave.ToString()))
            {
                
                string serialized = PlayerPrefs.GetString(nameSave.ToString());
                loadObject = JsonUtility.FromJson<U>(serialized);
            }
        }

        public void Load<U>(ref U loadObject, string loadText)
        {
            
            loadObject = JsonUtility.FromJson<U>(loadText);

        }

        public void Save<U>(U saveObject)
        {
            StringBuilder nameSave = new StringBuilder();
            nameSave.Append(prefixSave);
            nameSave.Append(myType.ToString());
            nameSave.Append(SaveController.GetNumSave());
            string serialized = JsonUtility.ToJson(saveObject);
            PlayerPrefs.SetString(nameSave.ToString(), serialized);
        }

        public Type GetTypeSave()
        {
            return myType;
        }

        public void Save<U>(U saveObject, out string saveText)
        {
            StringBuilder nameSave = new StringBuilder();
            nameSave.Append(prefixSave);
            nameSave.Append(myType.ToString());
            nameSave.Append(SaveController.GetNumSave());
            string serialized = JsonUtility.ToJson(saveObject);
            saveText = serialized;
            
        }

        
    }
}


