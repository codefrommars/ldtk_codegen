# **LDtk Code Generator**

Auxiliary library for generating C# classes mapped from the objects defined in LDtk files.

## **Dependencies**

* Newtonsoft.Json

* The [quicktype generated file ](https://ldtk.io/files/quicktype/LdtkJson.cs)for loading LDtk json files 

## **How to use**

```csharp
//Load the ldtk file
string text = File.ReadAllText("Entities.ldtk");
LdtkJson ldtkJson = LdtkJson.FromJson(text);

//Configure a generator context
LdtkGeneratorContext ctx = new LdtkGeneratorContext();
ctx.TypeConverter = new LdtkTypeConverter();
ctx.CodeSettings.Namespace = "MyNamespace.Test";

//The output can be customized as well
SingleFileOutput fOut = new SingleFileOutput();
fOut.OutputDir = "src-gen";
fOut.Filename = "MyFileCode.cs";

//Run the generator
LdtkCodeGenerator cg = new LdtkCodeGenerator();
cg.GenerateCode(ldtkJson, ctx, fOut);
```

## **Extending**

* **LdtkCodeCustomizer**
  
  With the `LdtkCodeCustomizer` class it's possible to modify the generated classes

* **File Output**
  
  * SingleFileOuput
  
  * MultiFileOutput

## **Future**

* Wrap it in a [Source Generator](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/)

## **License**

MIT
