using ST.Types;

//Create a type with <int_32> as a memory buffer
SType type = STBuilder.NewType(name: "Voxel")
                      .NextField(name: "x", length: 3)
                      .NextField(name: "y", length: 3)
                      .NextField(name: "z", length: 3)
                      .NextField(name: "color", length: 7)
                      .NextField(name: "opacity", length: 4)
                      .NextField(name: "roughness", length: 4)
                      .NextField(name: "metallic", length: 4)
                      .NextField(name: "subsurface", length: 4)
                      .Register()
                      .Get();

//Create an instance of declared type.
ST32 st32 = type.NewST32()
                .SetField("x", 4)
                .SetField("y", 6)
                .SetField("z", 3)
                .SetField("color", 125)
                .SetField("opacity", 15)
                .SetField("roughness", 3)
                .SetField("metallic", 15)
                .SetField("subsurface", 1);

uint value = st32.GetValue();

STypes.TryGet("Voxel", out SType? typeFromMap);

//Copy of an st32 instance (just an <int_32> copy)
ST32 st32Copy = typeFromMap!.From(value);

//Get values from an <int_32> memory buffer using stored offsets and lengths
int x = st32Copy.GetField("x");
int y = st32Copy.GetField("y");
int z = st32Copy.GetField("z");
int color = st32Copy.GetField("color");
int opacity = st32Copy.GetField("opacity");
int roughness = st32Copy.GetField("roughness");
int metallic = st32Copy.GetField("metallic");
int subsurface = st32Copy.GetField("subsurface");

Console.WriteLine($"x: {x},\ny: {y},\nz: {z},\ncolor: {color},\nopacity: {opacity}," +
                  $"\nroughness: {roughness},\nmetallic: {metallic},\nsubsurface: {subsurface}.\n" +
                  $"Underlying value: {Convert.ToString(st32.GetValue(), 2).PadLeft(32, '0')}");