using CustomHudAPI.Enums;
using CustomHudAPI.Features;
using CustomHudAPI.Features.Serializable;
using Exiled.API.Features;
using System.Collections.Generic;

namespace CustomHud
{
    public class Plugin : Plugin<Config>
    {
        public override void OnEnabled()
        {
            foreach (var keyValuePair in Config.Elements)
            {
                foreach (var elements in keyValuePair.Value)
                {
                    foreach (var element in elements.Value)
                    {
                        CHAPI.SetOrAdd(element.Lines, keyValuePair.Key, elements.Key);
                    }
                }
            }

            base.OnEnabled();
        }
    }
}
