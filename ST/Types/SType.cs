namespace ST.Types;

public class SType
{
    private readonly Dictionary<string, (byte length, byte offset)> _fields = new();

    public string Name { get; set; }

    public SType(string name)
    {
        Name = name;
    }
    
    internal void WithField(string name, byte offset, byte length)
    {
        _fields.Add(name, (length, offset));
    }
    
    internal (byte length, byte offset) GetFieldInfo(string name)
    {
        if(!_fields.TryGetValue(name, out (byte length, byte offset) data))
            throw new MissingFieldException(name);
            
        return data;
    }
    
    public ST32 NewST32()
    {
        return new ST32(this, 0);
    }
    
    public ST16 NewST16()
    {
        return new ST16(this, 0);
    }
    
    public ST8 NewST8()
    {
        return new ST8(this, 0);
    }
    
    public ST32 From(uint value)
    {
        return new ST32(this, value);
    }
    
    public ST16 From(ushort value)
    {
        return new ST16(this, value);
    }
    
    public ST8 From(byte value)
    {
        return new ST8(this, value);
    }
}
