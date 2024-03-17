using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.HighQualityMistakes
{
    public class Spy
    {
        StringBuilder sb = new StringBuilder();
        public string AnalyzeAccessModifiers(string className)
        {

            Type typeClass = Type.GetType(className);
            FieldInfo[] classField = typeClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicInfo = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicInfo = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in classField)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in classPublicInfo.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            foreach (MethodInfo method in classNonPublicInfo.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            

            return sb.ToString().Trim();
        }

        public string StealFieldInfo(string inputClassName, params string[] fields)
        {


            Type findingClass = Type.GetType($"Spy.{inputClassName}");
            FieldInfo[] classFields = findingClass.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            sb.AppendLine($"Class under investigation: {findingClass.Name}");

            //classFields = (FieldInfo)classFields.Where(f => fields.Contains(f.Name));

            Object classInstance = Activator.CreateInstance(findingClass, null);

            foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
