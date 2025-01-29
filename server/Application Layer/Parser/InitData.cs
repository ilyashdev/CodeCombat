namespace CodeCombat.Application_Layer;
static public class InitData
{
    public static Dictionary<string, string> Parse(string data)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        string[] pairs = data.Split('&');
        foreach (string pair in pairs)
        {
            string[] keyValue = pair.Split('=');
            if (keyValue.Length == 2)
            {
                parameters[keyValue[0]] = keyValue[1];
            }
        }
        return parameters;
    }
}