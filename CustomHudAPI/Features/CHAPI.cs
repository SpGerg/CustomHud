using CustomHudAPI.Enums;
using CustomHudAPI.Features.Elements;
using Exiled.API.Features;
using NorthwoodLib.Pools;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MEC;
using Discord;
using System.Threading.Tasks;

namespace CustomHudAPI.Features
{
    public static class CHAPI
    {
        public static Dictionary<AlignType, List<ElementRenderInfo>> Messages = new Dictionary<AlignType, List<ElementRenderInfo>>()
        {
            { AlignType.Left, new List<ElementRenderInfo>() },
            { AlignType.Right, new List<ElementRenderInfo>() },
            { AlignType.Center, new List<ElementRenderInfo>() },
            { AlignType.None, new List<ElementRenderInfo>() },
        };

        private static float updateRate = 0.51f;

        public static float UpdateRate
        {
            set
            {
                if (value < 0.51f)
                {
                    updateRate = 0.51f;

                    return;
                }

                updateRate = value;
            }
            get
            {
                return updateRate;
            }
        }

        static CHAPI()
        {
            Timing.RunCoroutine(RenderCoroutine());
        }

        public static void SetOrAdd(List<string> lines, AlignType alignType, int id)
        {
            var element = Messages[alignType].FirstOrDefault(_element => _element.Element.Id == id);

            if (element != default)
            {
                element.Element.Lines = lines;
            }
            else
            {
                Messages[alignType].Add(new ElementRenderInfo(new Element(lines, id)));
            }
        }

        public static void SetOrAdd(Element newElement, AlignType alignType)
        {
            var element = Messages[alignType].FirstOrDefault(_element => _element.Element.Id == newElement.Id);

            if (element != default)
            {
                element.Element.Lines = newElement.Lines;
            }
            else
            {
                Messages[alignType].Add(new ElementRenderInfo(new Element(newElement.Lines, newElement.Id)));
            }
        }

        public static string GetMessage()
        {
            string result = string.Empty;

            foreach (var keyValuePair in Messages)
            {
                if (keyValuePair.Key != AlignType.None)
                {
                    result += $"<align={keyValuePair.Key}>{GetTextFromElementList(keyValuePair.Key)}</align>";
                }
                else
                {
                    result += $"{GetTextFromElementList(keyValuePair.Key)}";
                }
            }

            return result;
        }

        private static void AddNewLine()
        {
            foreach (var keyValuePair in Messages.Values)
            {
                foreach (var message in keyValuePair)
                {
                    if (message.CurrentLine == message.Element.Lines.Count-1)
                    {
                        message.CurrentLine = 0;

                        continue;
                    }

                    message.CurrentLine++;
                }
            }
        }

        private static string GetTextFromElementList(AlignType alignType)
        {
            string result = string.Empty;

            foreach (var keyValuePair in Messages[alignType])
            {
                result += keyValuePair.Element.Lines[keyValuePair.CurrentLine] + Environment.NewLine;
            }

            return result;
        }

        private static IEnumerator<float> RenderCoroutine()
        {
            while (true)
            {
                foreach (var player in Player.List)
                {
                    player.ShowHint(GetMessage(), UpdateRate);
                }

                AddNewLine();

                yield return Timing.WaitForSeconds(UpdateRate);
            }
        }
    }

    public class ElementRenderInfo
    {
        public Element Element { get; }

        public int CurrentLine { get; set; }

        public ElementRenderInfo(Element element)
        {
            Element = element;
        }
    }
}
