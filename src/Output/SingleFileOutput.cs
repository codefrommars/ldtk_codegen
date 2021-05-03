using System.IO;
using System.Collections.Generic;

namespace LdtkGen
{
    public class SingleFileOutput : CodeOutput
    {
        public string OutputDir { get; set; }
        public string Filename { get; set; }

        public void OutputCode(List<CompilationUnitFragment> fragments, LdtkGeneratorContext ctx)
        {
            Directory.CreateDirectory(OutputDir);

            CompilationUnit cu = new CompilationUnit();
            cu.Name = Filename;
            cu.Namespace = ctx.CodeSettings.Namespace;
            cu.Fragments = fragments;

            CompilationUnitSource source = new CompilationUnitSource(ctx.CodeSettings);
            cu.Render(source);

            string filePath = OutputDir + "/" + Filename;
            File.WriteAllText(filePath, source.GetSourceCode());

        }
    }

}