
namespace LdtkGen
{
    public class LdtkTypeConverter
    {
        public virtual string GetArrayImport()
        {
            return null;
        }

        protected string GetCSharpTypeFor(string ldtkType)
        {
            if (ldtkType.StartsWith("LocalEnum"))
            {
                return ldtkType.Substring(10);
            }

            switch (ldtkType)
            {
                case "Int":
                    return "int";
                case "Float":
                    return "float";
                case "Bool":
                    return "bool";
                case "Point":
                    return "float[]";
                case "Color":
                    return "int[]";
                default:
                    return "string";
            }
        }

        public virtual string GetDeclaringTypeFor(ldtk.FieldDefinition fieldDefinition, LdtkGeneratorContext ctx)
        {
            string baseType = fieldDefinition.Type;
            if (fieldDefinition.IsArray)
                baseType = baseType.Substring(6, baseType.Length - 7);

            string declType = GetCSharpTypeFor(baseType);

            if (fieldDefinition.IsArray)
                declType += "[]";

            return declType;
        }

        public CompilationUnitField ToCompilationUnitField(ldtk.FieldDefinition fieldDefinition, LdtkGeneratorContext ctx)
        {
            CompilationUnitField field = new CompilationUnitField();
            field.Name = fieldDefinition.Identifier;
            field.Type = GetDeclaringTypeFor(fieldDefinition, ctx);
            field.Visibility = CompilationUnitField.FieldVisibility.Public;

            if (fieldDefinition.IsArray)
                field.RequiredImport = GetArrayImport();

            return field;
        }
    }
}