using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonRechnerWPF
{
    class XMLSerializer : IMonsterSerializer
    {
        public Monster Deserialize(string _path)
        {
            XDocument document = XDocument.Load(_path);

            XElement rootElement = document.Root;

            if (rootElement.Name != "Monster")
                throw new InvalidDataException("No valid Game xml.");

            Monster monster = new Monster();

            monster.Name = rootElement.Element("Name").Value;
            monster.Health = int.Parse(rootElement.Element("Health").Value);
            monster.Defense = int.Parse(rootElement.Element("Defense").Value);
            monster.Armor = int.Parse(rootElement.Element("Armor").Value);

            return monster;
        }
    }
}
