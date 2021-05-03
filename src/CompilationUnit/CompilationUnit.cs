using System.Collections.Generic;

namespace LdtkGen
{
    public class CompilationUnit : CompilationUnitFragment
    {
        public string Namespace;
        public List<CompilationUnitFragment> Fragments = new List<CompilationUnitFragment>();

        public override void Render(CompilationUnitSource source)
        {
            if (Namespace != null)
            {
                source.AddLine($"namespace {Namespace}");
                source.StartBlock();
            }

            foreach (CompilationUnitFragment fragment in Fragments)
            {
                fragment.Render(source);
            }

            if (Namespace != null)
            {
                source.EndBlock();
            }
        }
    }
}