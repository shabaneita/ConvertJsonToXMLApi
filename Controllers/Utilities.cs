using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace ConvertJsonToXMLApi.Controllers;

public static class Utilities
{
    public static string ConvertJsonToXml(string json)
    {
        var rootNode = new XElement("root");
        var parsedJson = JObject.Parse(json);
        ConvertJTokenToXElement(parsedJson, rootNode);
        return rootNode.ToString();
    }

    public static void ConvertJTokenToXElement(JToken token, XElement parent)
    {
        if (token == null) return;

        switch (token.Type)
        {
            case JTokenType.Object:
                foreach (var child in token.Children<JProperty>())
                {
                    var childElement = new XElement(child.Name);
                    ConvertJTokenToXElement(child.Value, childElement);
                    parent.Add(childElement);
                }
                break;
            case JTokenType.Array:
                for (int i = 0; i < token.Children().Count(); i++)
                {
                    var childElement = new XElement("item" + i);
                    ConvertJTokenToXElement(token.Children().ElementAt(i), childElement);
                    parent.Add(childElement);
                }
                break;
            default:
                parent.Value = token.Value<string>();
                break;
        }
    }
}
