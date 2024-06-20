namespace ST.Types;

public struct ST16
{
    private ushort _value;
    private readonly SType _type;
    
    internal ST16(SType type, ushort value)
    {
        _type = type;
        _value = value;
    }
    
    public ST16 SetField(string name, byte value)
    {
        (byte length, byte offset) = _type.GetFieldInfo(name);
        _value |= (ushort)(value << offset);
        
        return this;
    }
    
    public ushort GetField(string name)
    {
        (byte length, byte offset) = _type.GetFieldInfo(name);
        
        uint mask = (uint)((1 << length) - 1);
        uint shiftedMask = mask << offset;
        
        return (ushort)((shiftedMask & _value) >> offset);
    }
    
    public ushort GetValue() => _value;
}