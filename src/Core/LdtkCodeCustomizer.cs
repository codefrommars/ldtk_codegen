
namespace LdtkGen
{
    public class LdtkCodeCustomizer
    {

        public virtual void CustomizeEntity(CompilationUnitClass entity, ldtk.EntityDefinition ed, LdtkGeneratorContext ctx)
        {
            entity.Fields.Add(new CompilationUnitField("Uid", "long"));
            entity.Fields.Add(new CompilationUnitField("Identifier", "string"));
            entity.Fields.Add(new CompilationUnitField("Width", "float"));
            entity.Fields.Add(new CompilationUnitField("Height", "float"));
            entity.Fields.Add(new CompilationUnitField("Position", "float[]"));
            entity.Fields.Add(new CompilationUnitField("Pivot", "float[]"));
        }

        public virtual void CustomizeLevel(CompilationUnitClass level, ldtk.LdtkJson ldtkJson, LdtkGeneratorContext ctx)
        {
            level.Fields.Add(new CompilationUnitField("Uid", "long"));
            level.Fields.Add(new CompilationUnitField("Identifier", "string"));
            level.Fields.Add(new CompilationUnitField("WorldCoords", "float[]"));
            level.Fields.Add(new CompilationUnitField("Width", "float"));
            level.Fields.Add(new CompilationUnitField("Height", "float"));
            level.Fields.Add(new CompilationUnitField("Entities", "object[]"));
        }

    }
}