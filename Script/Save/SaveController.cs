using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
    public static class SaveController
    {


        static List<ISaveObject<SaveObject>> listObj = new List<ISaveObject<SaveObject>>();
        private static int numberSave = 0;

        public static void AddObj(ISaveObject<SaveObject> saveObject)
        {
            listObj.Add(saveObject);
        }

        public static void Load<T>(ref T Tobj)
        {
            if (listObj.Count > 0)
            {
                for (int i = 0; i < listObj.Count; i++)
                {
                    if (Tobj.GetType() == listObj[i].GetTypeSave())
                    {
                        listObj[i].Load<T>(ref Tobj);
                    }
                }
            }
        }

        public static void Load<T>(ref T Tobj, string loadText)
        {
            if (listObj.Count > 0)
            {
                for (int i = 0; i < listObj.Count; i++)
                {
                    if (Tobj.GetType() == listObj[i].GetTypeSave())
                    {
                        listObj[i].Load<T>(ref Tobj, loadText);
                    }
                }
            }
        }


        public static void Save<T>(T obj)
        {
            if (listObj.Count > 0)
            {
                for (int i = 0; i < listObj.Count; i++)
                {
                    if (obj.GetType() == listObj[i].GetTypeSave())
                    {
                        listObj[i].Save<T>(obj);
                    }
                }
            }
        }

        public static void Save<T>(T obj, out string saveText)
        {
            saveText = "";
            if (listObj.Count > 0)
            {
                for (int i = 0; i < listObj.Count; i++)
                {
                    if (obj.GetType() == listObj[i].GetTypeSave())
                    {
                        listObj[i].Save<T>(obj, out saveText);
                    }
                }
            }
        }



        public static int GetNumSave()
        {
            return numberSave;
        }


    }
}
