using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Save
{
    public interface ISaveObject<T>
    {

        void InitObject();
        void Load<U>(ref U loadObject);
        void Load<U>(ref U loadObject, string loadText);
        void Save<U>(U saveObject);
        void Save<U>(U saveObject, out string saveText);
        System.Type GetTypeSave();
    }
}
