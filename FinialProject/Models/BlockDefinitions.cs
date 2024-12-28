using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace FinialProject.Models
{
    [XmlRoot("tetris-blocks")]
    public sealed class BlockDefinitions
    {
        [XmlArray("blocks")]
        [XmlArrayItem("block")]
        public List<BlockDefinition> Definitions { get; set; } = new();

        public override string ToString() => Definitions?.Count.ToString();

        public static BlockDefinitions LoadFromFile(string fileName)
        {
            var serializer = new XmlSerializer(typeof(BlockDefinitions));
            using var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            return (BlockDefinitions)serializer.Deserialize(fs);
        }
    }
}
