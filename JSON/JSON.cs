using System;
using System.Collections.Generic;
using System.Text;

namespace JSONLib
{
    public class JSON : IJSON
    {
        private int length;
        private StringBuilder json;
        public List<String> keys;

        public JSON()
        {
            length = 0;
            json = new StringBuilder("{");
            keys = new List<String>();
        }

        public IJSON Add(string key, string value)
        {
            StringBuilder str = new StringBuilder();

            if (length > 0)
                str.Append(", ");

            str.Append("\"").Append(key).Append("\" : ")
                .Append("\"").Append(value).Append("\"");

            length++;
            keys.Add(key);
            json.Append(str);

            return this;
        }

        public IJSON Add(string key, params string[] values)
        {
            StringBuilder str = new StringBuilder();

            if (length > 0)
                str.Append(", ");

            str.Append("\"").Append(key).Append("\" : [");

            bool first = true;

            foreach (string value in values)
            {
                if (!first)
                {
                    str.Append(", ");
                }
                else
                {
                    first = false;
                }
                str.Append("\"").Append(value).Append("\"");
            }
            str.Append("]");

            length++;
            keys.Add(key);
            json.Append(str);

            return this;
        }

        public IJSON Add(string key, int value)
        {
            Add(key, value.ToString());
            return this;
        }

        public IJSON Add(String key, int[] values)
        {
            String[] strValues = new String[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                strValues[i] = values[i].ToString();
            }

            this.Add(key, strValues);

            return this;
        }

        public IJSON Add(string key, double value)
        {
            Add(key, value.ToString());
            return this;
        }

        public IJSON Add(String key, double[] values)
        {
            String[] strValues = new String[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                strValues[i] = values[i].ToString();
            }

            this.Add(key, strValues);

            return this;
        }

        public IJSON Add(string key, List<string> values)
        {
            StringBuilder str = new StringBuilder();

            if (length > 0)
                str.Append(", ");

            str.Append("\"").Append(key).Append("\" : [");

            foreach (string value in values)
            {
                str.Append("\"").Append(value).Append("\"");
            }
            str.Append("]");

            length++;
            keys.Add(key);
            json.Append(str);

            return this;
        }

        public IJSON Clear()
        {
            length = 0;
            json.Clear();
            return this;
        }

        public IJSON Merge(IJSON json)
        {
            foreach (String key in keys)
            {
                foreach (String foreignKey in json.Keys())
                {
                    if (key.Equals(foreignKey))
                    {
                        throw new Exception("Key already exists!");
                    }
                }
            }

            StringBuilder str = new StringBuilder(json.GetFormatted());
            str.Remove(0, 1).Remove(str.Length - 1, 1);
            if (this.length > 0)
                this.json.Append(", ");
            this.json.Append(str.ToString());
            return this;
        }

        public IJSON Merge(IJSON[] jsons)
        {
            foreach (IJSON json in jsons)
            {
                foreach (String key in keys)
                {
                    foreach (String foreignKey in json.Keys())
                    {
                        if (key.Equals(foreignKey))
                        {
                            throw new Exception("Key already exists!");
                        }
                    }
                }
            }

            if (this.length > 0)
                this.json.Append(", ");

            foreach (IJSON json in jsons)
            {
                StringBuilder str = new StringBuilder(json.GetFormatted());
                str.Remove(0, 1).Remove(str.Length - 1, 1);

                this.json.Append(str);
                this.json.Append(", ");
            }
            return this;
        }

        public string GetFormatted()
        {
            json.Append("}");
            string str = json.ToString();
            json.Remove(json.Length - 1, 1);
            return str;
        }

        public int Length()
        {
            return length;
        }

        public List<String> Keys()
        {
            return keys;
        }

        private bool hasKey(string str)
        {
            foreach (string key in keys)
            {
                if (key.Equals(str))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
