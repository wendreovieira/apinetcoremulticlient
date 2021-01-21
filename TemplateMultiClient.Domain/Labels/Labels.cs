namespace TemplateMultiClient.Domain
{
    public static class Labels
    {
        public static string RequiredField() => "This field is required.";
        public static string FieldHasMinLen(int value) => $"This field must contain at least {value} characters.";
        public static string FieldHasMaxLen(int value) => $"This field must contain a maximum of {value} characters.";
        public static string FieldCannotContainSpaces() => "This field cannot contain spaces.";
        public static string RegisterNotFound() => "Register not found.";
    }
}