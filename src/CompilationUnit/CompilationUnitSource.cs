using System.Text;
using System.Collections.Generic;

namespace LdtkGen
{
    public class CompilationUnitSource
    {
        private StringBuilder verbatimSrc;
        private int currIndent;
        private CodeSettings cs;
        private SortedSet<string> imports;

        public CompilationUnitSource(CodeSettings cs)
        {
            this.cs = cs;
            verbatimSrc = new StringBuilder();
            currIndent = 0;
            imports = new SortedSet<string>();
        }

        public void Using(string package)
        {
            if (package == null)
                return;

            imports.Add(package);
        }

        public void AddLine(string line)
        {
            for (int i = 0; i < currIndent; i++)
            {
                verbatimSrc.Append(cs.IndentString);
            }
            verbatimSrc.Append(line);
            verbatimSrc.Append(cs.NewLine);
        }

        public void StartBlock()
        {
            AddLine("{");
            currIndent++;
        }

        public void EndBlock()
        {
            currIndent--;
            AddLine("}");
        }

        public string GetSourceCode()
        {
            StringBuilder code = new StringBuilder();

            if (cs.GeneratedFileHeader != null)
                code.AppendLine(cs.GeneratedFileHeader);

            foreach (string use in imports)
            {
                code.AppendLine($"using {use};");
            }

            code.AppendLine();
            code.Append(verbatimSrc.ToString());
            return code.ToString();
        }
    }
}