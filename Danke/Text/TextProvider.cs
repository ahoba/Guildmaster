using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Text
{
    public enum Languages
    {
        English = 0,
        Portuguese = 1
    }

    public class TextProvider
    {
        private static TextProvider _instance;

        public static TextProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TextProvider();
                }

                return _instance;
            }
        }

        public Languages Language { get; set; }

        public Dictionary<Guid, string>[] DictionariesByLanguage;

        public Dictionary<Guid, string> TextById { get => DictionariesByLanguage[(int)Language]; }

        private TextProvider()
        {
            Language = Languages.English;

            DictionariesByLanguage = new Dictionary<Guid, string>[Enum.GetValues(typeof(Languages)).Length];
        }

        public string GetText(Guid id)
        {
            return TextById.ContainsKey(id) ? TextById[id] : "Missing Text";
        }
    }
}
