using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHudAPI.Features.Elements
{
    public class Element
    {
        public List<string> Lines { get; set; }

        public int Id { get; }

        public Element(List<string> lines, int id)
        {
            Lines = lines;
            Id = id;
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (var line in Lines)
            {
                result += line.ToString() + Environment.NewLine;
            }

            return result;
        }
    }
}
