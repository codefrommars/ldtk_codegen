using System.IO;
using System.Collections.Generic;

namespace LdtkGen
{
    public class MultiFileOutput : CodeOutput
    {
        public string OutputDir { get; set; }

        public void OutputCode(List<CompilationUnitFragment> fragments, LdtkGeneratorContext ctx)
        {
            Directory.CreateDirectory(OutputDir);

            foreach (CompilationUnitFragment fragment in fragments)
            {
                CompilationUnit cuFile = new CompilationUnit();
                cuFile.Namespace = ctx.CodeSettings.Namespace;
                cuFile.Name = fragment.Name;
                cuFile.Fragments.Add(fragment);

                CompilationUnitSource source = new CompilationUnitSource(ctx.CodeSettings);
                cuFile.Render(source);

                string filePath = OutputDir + "/" + fragment.Name + ".cs";
                File.WriteAllText(filePath, source.GetSourceCode());
            }
        }
    }

}