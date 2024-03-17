using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            Type typeClass = Type.GetType(className);
            MethodInfo[] classMethods = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {typeClass.BaseType.Name}");

            foreach (MethodInfo method in classMethods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().Trim();
        }
        public string StealFieldInfo(string className, params string[] namesOfTheFields)
        {
            StringBuilder sb = new StringBuilder();

            Type findingClass = Type.GetType($"{className}");

            FieldInfo[] classFields = findingClass.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            Object classInstance = Activator.CreateInstance(findingClass, null);

            sb.AppendLine($"Class under investigation: {findingClass.Name}");
            foreach (FieldInfo field in classFields.Where(f => namesOfTheFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
