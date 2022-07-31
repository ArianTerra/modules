using System.Text.RegularExpressions;

namespace Book_Task.Services
{
    /// <summary>
    /// Parses regex group values into specified class using group names
    /// </summary>
    /// <typeparam name="T">Any class that has default constructor and properties which types have Parse() method.</typeparam>
    public class RegexClassParser<T> where T : new()
    {
        private readonly string _data;
        private readonly string _pattern;

        public RegexClassParser(string data, string pattern)
        {
            _data = data;
            _pattern = pattern;
        }

        public T ParseClass()
        {
            Regex regex = new Regex(_pattern);
            var match = regex.Match(_data);

            var regexGroupNames = regex.GetGroupNames();

            var obj = (T)Activator.CreateInstance(typeof(T));

            foreach (var groupName in regexGroupNames)
            {
                if (groupName == "0")
                {
                    continue; // skip root group
                }

                string typeName = "string";
                string name = "";

                if (groupName.Contains('_'))
                {
                    var split = groupName.Split('_', 2);
                    name = split[0];
                    typeName = split[1].Replace('_', '.');
                }
                else
                {
                    name = groupName;
                }

                var property = obj.GetType().GetProperty(name);
                if (property == null)
                {
                    throw new ArgumentException($"Class of type {nameof(T)} does not have property {name}");
                }

                var value = match.Groups[groupName].Value;

                if (typeName == "string")
                {
                    property.SetValue(obj, value);
                }
                else
                {
                    Type t = GetType(typeName);
                    if (t == null)
                    {
                        throw new ArgumentException($"Type {typeName} does not exist");
                    }

                    var parseMethod = t.GetMethod("Parse", new []{typeof(string)});
                    if (parseMethod == null)
                    {
                        throw new ArgumentException($"Type {typeName} does not have method Parse()");
                    }

                    var newValue = parseMethod.Invoke(null, new object[] { value });

                    property.SetValue(obj, newValue);
                }
            }

            return obj;
        }

        private static Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null)
            {
                return type;
            }

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                {
                    return type;
                }
            }

            return null;
        }
    }
}