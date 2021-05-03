using System.Collections.Generic;

namespace LdtkGen
{
    public interface CodeOutput
    {
        void OutputCode(List<CompilationUnitFragment> fragments, LdtkGeneratorContext ctx);
    }
}