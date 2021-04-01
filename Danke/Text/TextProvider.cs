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

        public Dictionary<string, string>[] DictionariesByLanguage;

        public Dictionary<string, string> TextById { get => DictionariesByLanguage[(int)Language]; }

        public string GetText(string id)
        {
            return TextById.ContainsKey(id) ? TextById[id] : "Missing Text";
        }
        
        public void SetText(string id, string value)
        {
            TextById[id] = value;
        }

        private TextProvider()
        {
            Language = Languages.English;

            DictionariesByLanguage = new Dictionary<string, string>[Enum.GetValues(typeof(Languages)).Length];

            for (int i = 0; i < DictionariesByLanguage.Length; i++)
            {
                DictionariesByLanguage[i] = new Dictionary<string, string>();
            }

            foreach (var fieldInfo in typeof(Texts).GetFields())
            {
                DictionariesByLanguage[(int)Languages.English].Add(fieldInfo.Name, (string)fieldInfo.GetValue(null));

                for (int i = 1; i < DictionariesByLanguage.Length; i++)
                {
                    DictionariesByLanguage[i].Add(fieldInfo.Name, string.Empty);
                }
            }
        }
    }
}
