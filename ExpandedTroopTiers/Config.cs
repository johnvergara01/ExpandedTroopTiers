using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;
using TaleWorlds.Library;

namespace ExpandedTroopTiers
{
    public class Config
    {
        public static int HighestTier;
        public static List<int> Wages = new List<int>();

        public Config()
        {
            try
            {
                string path = Path.Combine(new string[]
                {
                    BasePath.Name,
                    "Modules",
                    "ExpandedTroopTiers",
                    "config.xml"
                });

                XmlReader reader = XmlReader.Create(path);
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HighestTier"))
                    {
                        HighestTier = Int32.Parse(reader.ReadElementContentAsString());
                    }
                    else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Wages"))
                    {
                        Wages = reader.ReadElementContentAsString().Split(',').Select(Int32.Parse).ToList();
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }
    }
}