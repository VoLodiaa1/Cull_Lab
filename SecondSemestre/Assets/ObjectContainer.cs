using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace LevelEditor
{

    [XmlRoot("ObjectLevel")]
    public class ObjectContainer : MonoBehaviour
    {

        [XmlArray("Obj")]
        [XmlArrayItem("Obj")]
        public List<ObjectSaver> ListObjectInLvl = new List<ObjectSaver>();
        public void Save(string path)
        {
            var serializer = new XmlSerializer(typeof(ObjectContainer));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(stream, this);
            }
        }

        public static ObjectContainer Load(string path)
        {
            var serializer = new XmlSerializer(typeof(ObjectContainer));
            using (var stream = new FileStream(path, FileMode.Open))
            {
                return serializer.Deserialize(stream) as ObjectContainer;
            }
        }

        //Loads the xml directly from the given string. Useful in combination with www.text.
        public static ObjectContainer LoadFromText(string text)
        {
            var serializer = new XmlSerializer(typeof(ObjectContainer));
            return serializer.Deserialize(new StringReader(text)) as ObjectContainer;
        }

    }
}
