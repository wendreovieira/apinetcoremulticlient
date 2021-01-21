using TemplateMultiClient.Domain.Enums;

namespace TemplateMultiClient.Domain.Entities
{
    public class Permission
    {
        public EPermissionType Type { get; private set; }
        public bool ToView { get; private set; }
        public bool Add { get; private set; }
        public bool Edit { get; private set; }
        public bool Remove { get; private set; }
    }
}