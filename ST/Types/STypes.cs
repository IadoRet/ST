namespace ST.Types;

public static class STypes
{
    private static readonly Dictionary<string, SType> Types = new ();
    
    public static void Register(SType sType)
    {
        Types.Add(sType.Name, sType);
    }
    
    public static bool TryGet(string name, out SType? st)
    {
        return Types.TryGetValue(name, out st);
    }
}