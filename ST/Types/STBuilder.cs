namespace ST.Types;

public class STBuilder
{
    private readonly SType _sType;
    private byte _offset;

    private STBuilder(string name)
    {
        _sType = new SType(name);
    }

    public static STBuilder NewType(string name)
    {
        return new STBuilder(name);
    }
    
    public STBuilder NextField(string name, byte length)
    {
        _sType.WithField(name, _offset, length);
        _offset += length;
        
        return this;
    }
    
    public STBuilder Register()
    {
        STMap.Register(_sType);
        return this;
    }
    
    public SType Get() => _sType;
}