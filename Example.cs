using System.IO;
using ldtk;
using LdtkGen;

public class Example
{
    static void Main(string[] args)
    {
        string text = File.ReadAllText("Entities.ldtk");
        LdtkJson ldtkJson = LdtkJson.FromJson(text);

        LdtkGeneratorContext ctx = new LdtkGeneratorContext();
        ctx.TypeConverter = new LdtkTypeConverter();
        ctx.CodeSettings.Namespace = "MyNamespace.Test";

        SingleFileOutput fOut = new SingleFileOutput();
        fOut.OutputDir = "src-gen";
        fOut.Filename = "MyFileCode.cs";

        LdtkCodeGenerator cg = new LdtkCodeGenerator();
        cg.GenerateCode(ldtkJson, ctx, fOut);
    }
}
