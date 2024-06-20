namespace ST.Types;

public struct ST8
{
    private byte _value;
    private readonly SType _type;
    
    internal ST8(SType type, byte value)
    {
        _type = type;
        _value = value;
    }
    
    public ST8 SetField(string name, byte value)
    {
        (byte length, byte offset) = _type.GetFieldInfo(name);
        _value |= (byte)(value << offset);
        
        return this;
    }
    
    public byte GetField(string name)
    {
        (byte length, byte offset) = _type.GetFieldInfo(name);
        
        uint mask = (uint)((1 << length) - 1);
        uint shiftedMask = mask << offset;
        
        return (byte)((shiftedMask & _value) >> offset);
    }
    
    public byte GetValue() => _value;
}