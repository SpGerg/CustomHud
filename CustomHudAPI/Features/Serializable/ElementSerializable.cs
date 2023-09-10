using CustomHudAPI.Features.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHudAPI.Features.Serializable
{
    public class ElementSerializable
    {
        public List<string> Lines { get; set; }

        public int Id { get; set; }

        public ElementSerializable(List<string> lines)
        {
            Lines = lines;
        }

        public ElementSerializable()
        {
            Lines = new List<string>();
        }

        public Element ToElement()
        {
            return new Element(Lines, Id);
        }
    }
}
