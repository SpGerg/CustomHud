using CustomHudAPI.Enums;
using CustomHudAPI.Features.Serializable;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace CustomHud
{
    public class Config : IConfig
    {
        [Description("Enabled or not.")]
        public bool IsEnabled { get; set; }

        [Description("Debug or not.")]
        public bool Debug { get; set; }

        [Description("Elements.")]
        public Dictionary<AlignType, Dictionary<int, List<ElementSerializable>>> Elements { get; set; } = new Dictionary<AlignType, Dictionary<int, List<ElementSerializable>>>()
        {
            { AlignType.Left, new Dictionary<int, List<ElementSerializable>>
                {
                    {
                        0,
                        new List<ElementSerializable> {
                            new ElementSerializable(new List<string>() { "<color=Red>D</color>og and hot-dog", "D<color=Red>o</color>g and hot-dog", "Do<color=Red>g</color> and hot-dog" })
                        }
                    },
                    {
                        1,
                        new List<ElementSerializable> {
                            new ElementSerializable(new List<string>() { "Dog <color=Red>a</color>nd hot-dog", "Dog a<color=Red>n</color>d hot-dog", "Dog an<color=Red>d</color> hot-dog" })
                        }
                    },
                    {
                        2,
                        new List<ElementSerializable> {
                            new ElementSerializable(new List<string>() { "Dog and <color=Red>h</color>ot-<color=Red>d</color>og", "Dog and h<color=Red>o</color>t-d<color=Red>o</color>g", "Dog and ho<color=Red>t</color>-do<color=Red>g</color>" })
                        }
                    }
                }
            }
        };

        public int UpdateRateInSeconds { get; set; }
    }
}
