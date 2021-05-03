using System;

namespace LdtkGen
{
    public class CodeSettings
    {
        public string Namespace { get; set; }
        public string GeneratedFileHeader { get; set; } = "//This file was automatically generated, any modifications might be lost!";
        public string IndentString { get; set; } = "\t";
        public string NewLine { get; set; } = Environment.NewLine;
    }

    public class LdtkGeneratorContext
    {
        public LdtkTypeConverter TypeConverter { get; set; }
        public LdtkCodeCustomizer CodeCustomizer { get; set; } = new LdtkCodeCustomizer();
        public CodeSettings CodeSettings { get; set; } = new CodeSettings();

        public string LevelClassName { get; set; } = "MyLevelClass";
    }
}