namespace app_cw3;

public class SerialNumberGenerator
{
    private static Dictionary<ContainerTypes, int> counter = new Dictionary<ContainerTypes, int>();

    public static string GenerateNumber(ContainerTypes type)
    {
        if (!counter.ContainsKey(type))
        {
            counter[type] = 1;
        }
        else
        {
            counter[type]++;
        }
        
        return $"KON-{type.ToString().Substring(0, 1)}-{counter[type]}";
    }
}