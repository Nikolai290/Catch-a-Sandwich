using System.IO;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scriptes.UI.LanguageSystem {
    public class TextSubstitutor : MonoBehaviour {

        public Text[] elements; // все текстовые элементы интерфейса, для которых предусмотрен перевод
        public string path = "Localization"; // путь где будут все локали
        public Dropdown dropdown; // меню языков, делаем из стандартного UI

        [HideInInspector] public int[] idList; // создается/обновляется вместе с шаблоном языка

        private string[] fileList;
        private string locale;
        private readonly string LOCALE_KEY = "LOCALE";
        void Start() {
            var playerPrefsLocale = "";
            if (PlayerPrefs.HasKey(LOCALE_KEY)) {
                playerPrefsLocale = PlayerPrefs.GetString(LOCALE_KEY);
            }
            LoadLocale(); // создание списка всех доступных локалей
            var defaultLocale = dropdown.options.FindIndex(x => x.text == playerPrefsLocale);
            DefaultLocale(defaultLocale); // установка локали по умолчанию, в данном случае, будет выбрана первая из списка
        }

        // создание массива id значений, относительно текстовых элементов
        // одинаковым текстовым элементам, будет присвоен одинаковый id
        void GetID() {
            int i = 1;
            idList = new int[elements.Length];
            for (int j = 0; j < elements.Length; j++) {
                if (idList[j] == 0) {
                    string key = elements[j].text;
                    idList[j] = i;
                    for (int t = j + 1; t < elements.Length; t++) {
                        if (elements[t].text.CompareTo(key) == 0) {
                            idList[t] = i;
                        }
                    }
                    i++;
                }
            }
        }

        public void DefaultLocale(int value) {
            dropdown.value = value;
        }

        void SetData(string value) {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = Path.GetFileNameWithoutExtension(value);
            dropdown.options.Add(option);
        }

        public void LoadLocale() {
            dropdown.options = new System.Collections.Generic.List<Dropdown.OptionData>();

            if (!Directory.Exists(path)) {
                SetData("none");
                return;
            }

            fileList = Directory.GetFiles(path, "*.xml");

            if (fileList.Length == 0) {
                SetData("none");
                return;
            }

            for (int i = 0; i < fileList.Length; i++) {
                var item = fileList[i];
                if (item.Contains("Default")) {
                    item = "Russian";
                }
                SetData(item);
            }

            dropdown.onValueChanged.AddListener(delegate { SetLocale(); });
        }

        public void BuildDefaultLocale() // для редактора, создание/обновление локали по умолчанию
        {
            if (!Directory.Exists(path)) {
                Debug.LogWarning(this + " Путь указан не верно!");
                return;
            }

            GetID();
            string file = path + "/Default.xml"; // имя стандартной локали

            string[] arr = new string[elements.Length];
            for (int i = 0; i < elements.Length; i++) {
                arr[i] = elements[i].text; // копируем все текстовые элементы
            }

            string[] res_txt = arr.Distinct().ToArray(); // убираем элементы, которые повторяются
            int[] res_id = idList.Distinct().ToArray();

            XmlElement elm;
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Locale");
            xmlDoc.AppendChild(rootNode);

            for (int i = 0; i < res_txt.Length; i++) // запись в файл, без повторяющихся элементов
            {
                elm = xmlDoc.CreateElement("text");
                elm.SetAttribute("id", res_id[i].ToString());
                rootNode.AppendChild(elm);
                elm.SetAttribute("value", res_txt[i]);
                rootNode.AppendChild(elm);
            }

            xmlDoc.Save(file);
            Debug.Log(this + " Создан фаил --> " + file);
        }

        int GetInt(string text) {
            int value;
            if (int.TryParse(text, out value)) return value;
            return 0;
        }

        void SetLocale() // чтение файла и замена текста
        {
            locale = fileList[dropdown.value];
            var playerPrefs = locale.Split('\\').Last().Split('.').First();
            PlayerPrefs.SetString(LOCALE_KEY, playerPrefs);
            try {
                XmlTextReader reader = new XmlTextReader(locale);
                while (reader.Read()) {
                    if (reader.IsStartElement("text")) {
                        ReplaceText(GetInt(reader.GetAttribute("id")), reader.GetAttribute("value"));
                    }
                }
                reader.Close();
            } catch (System.Exception) {
                Debug.LogError(this + " Ошибка чтения файла! --> " + locale);
            }
        }

        void ReplaceText(int id, string text) // поиск и замена всех элементов, по ключу
        {
            for (int j = 0; j < idList.Length; j++) {
                if (idList[j] == id) elements[j].text = text;
            }
        }
    }
}