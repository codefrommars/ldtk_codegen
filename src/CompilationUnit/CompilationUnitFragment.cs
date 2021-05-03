
namespace LdtkGen
{
    public abstract class CompilationUnitFragment
    {
        public string Name;
        public abstract void Render(CompilationUnitSource source);
    }
}