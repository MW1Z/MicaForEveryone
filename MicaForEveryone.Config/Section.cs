﻿using System;
using System.Collections.Generic;
using System.Linq;

using MicaForEveryone.Models;

namespace MicaForEveryone.Config
{
    public class Section
    {
        public Section(EvaluatedSymbol<SectionType> type, Symbol parameter)
        {
            Type = type;
            Parameter = parameter;
            Name = Type.Value switch
            {
                SectionType.Global => "Global",
                SectionType.Process => $"Process({Parameter!.Name})",
                SectionType.Class => $"Class({Parameter!.Name})",
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        public EvaluatedSymbol<SectionType> Type { get; }

        public Symbol Parameter { get; }

        public string Name { get; }

        public Dictionary<EvaluatedSymbol<KeyName>, Symbol> Pairs { get; } = new();

        public EvaluatedSymbol<TitlebarColorMode> GetTitleBarColor()
        {
            return (EvaluatedSymbol<TitlebarColorMode>)
                Pairs.First(pair => pair.Key.Value == KeyName.TitleBarColor).Value;
        }

        public EvaluatedSymbol<BackdropType> GetBackdropPreference()
        {
            return (EvaluatedSymbol<BackdropType>)
                Pairs.First(pair => pair.Key.Value == KeyName.BackdropPreference).Value;
        }

        public EvaluatedSymbol<bool> GetExtendFrameIntoClientArea()
        {
            return (EvaluatedSymbol<bool>)
                Pairs.First(pair => pair.Key.Value == KeyName.ExtendFrameToClientArea).Value;
        }
    }
}