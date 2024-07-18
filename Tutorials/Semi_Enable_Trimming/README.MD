# Enable Trimming for Semi Avalonia.

## How to use

1. Add the following code to your `csproj` file:

```xml
<ItemGroup>
    <TrimmerRootDescriptor Include="Roots.xml"/>
</ItemGroup>
```

2. Create a `Roots.xml` file in the same directory as your `csproj` file with the following content:

```xml
<linker>
    <assembly fullname="Semi.Avalonia, Version=11.0.7.4, Culture=neutral, PublicKeyToken=null"/>
</linker>
```

3. Build your project With trim enabled. 
