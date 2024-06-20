namespace ST.Types;

public struct ST32
{
    private uint _value;
    private readonly SType _type;
    
    internal ST32(SType type, uint value)
    {
        _type = type;
        _value = value;
    }
    
    public ST32 SetField(string name, int value)
    {
        (byte length, byte offset) = _type.GetFieldInfo(name);
        _value |= (uint)(value << offset);
        
        return this;
    }
    
    public int GetField(string name)
    {
        (byte length, byte offset) = _type.GetFieldInfo(name);
        
        uint mask = (uint)((1 << length) - 1);
        uint shiftedMask = mask << offset;
        
        return (int)((shiftedMask & _value) >> offset);
    }
    
    public uint GetValue() => _value;
}