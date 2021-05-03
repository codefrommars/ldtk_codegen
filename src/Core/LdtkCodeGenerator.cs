using System.Collections.Generic;
using ldtk;

namespace LdtkGen
{
    public class LdtkCodeGenerator
    {
        public virtual void GenerateCode(LdtkJson ldtkJson, LdtkGeneratorContext ctx, CodeOutput output)
        {
            List<CompilationUnitFragment> fragments = new List<CompilationUnitFragment>();

            foreach (EnumDefinition ed in ldtkJson.Defs.Enums)
            {
                fragments.Add(GenerateEnum(ed, ctx));
            }

            foreach (EntityDefinition ed in ldtkJson.Defs.Entities)
            {
                CompilationUnitClass entity = GenerateEntity(ed, ctx);
                fragments.Add(entity);

                if (ctx.CodeCustomizer != null)
                    ctx.CodeCustomizer.CustomizeEntity(entity, ed, ctx);
            }

            CompilationUnitClass level = GenerateLevel(ldtkJson, ctx);
            fragments.Add(level);

            if (ctx.CodeCustomizer != null)
                ctx.CodeCustomizer.CustomizeLevel(level, ldtkJson, ctx);

            output.OutputCode(fragments, ctx);
        }

        public virtual CompilationUnitEnum GenerateEnum(ldtk.EnumDefinition enumDefinition, LdtkGeneratorContext ctx)
        {
            CompilationUnitEnum enumFragment = new CompilationUnitEnum();
            enumFragment.Name = enumDefinition.Identifier;

            foreach (ldtk.EnumValueDefinition evd in enumDefinition.Values)
            {
                enumFragment.Literals.Add(evd.Id);
            }

            return enumFragment;
        }

        public virtual CompilationUnitClass GenerateEntity(ldtk.EntityDefinition ed, LdtkGeneratorContext ctx)
        {
            CompilationUnitClass classFragment = new CompilationUnitClass();
            classFragment.Name = ed.Identifier;

            foreach (ldtk.FieldDefinition fd in ed.FieldDefs)
            {
                classFragment.Fields.Add(ctx.TypeConverter.ToCompilationUnitField(fd, ctx));
            }

            return classFragment;
        }

        public virtual CompilationUnitClass GenerateLevel(ldtk.LdtkJson ldtkJson, LdtkGeneratorContext ctx)
        {
            CompilationUnitClass levelClass = new CompilationUnitClass();
            levelClass.Name = ctx.LevelClassName;

            foreach (ldtk.FieldDefinition fd in ldtkJson.Defs.LevelFields)
            {
                levelClass.Fields.Add(ctx.TypeConverter.ToCompilationUnitField(fd, ctx));
            }

            return levelClass;
        }
    }

}