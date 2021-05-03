using System.Collections.Generic;

namespace LdtkGen
{
    public class CompilationUnitClass : CompilationUnitFragment
    {
        public string BaseClass { get; set; } = null;
        public List<CompilationUnitField> Fields = new List<CompilationUnitField>();

        public override void Render(CompilationUnitSource source)
        {
            string extends = "";
            if (BaseClass != null)
            {
                extends = $" : {BaseClass}";
            }

            source.AddLine($"public class {Name}{extends}");
            source.StartBlock();

            foreach (CompilationUnitField field in Fields)
            {
                field.Render(source);
            }
            source.EndBlock();
        }
    }
}