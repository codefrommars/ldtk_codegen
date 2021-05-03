using System.Collections.Generic;

namespace LdtkGen
{
    public class CompilationUnitEnum : CompilationUnitFragment
    {
        public List<string> Literals = new List<string>();

        public override void Render(CompilationUnitSource source)
        {
            source.AddLine($"public enum {Name}");
            source.StartBlock();

            foreach (string literal in Literals)
            {
                source.AddLine($"{literal},");
            }
            source.EndBlock();
        }
    }
}