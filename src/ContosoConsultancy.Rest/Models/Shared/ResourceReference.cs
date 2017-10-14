
namespace ContosoConsultancy.Rest.Models.Shared
{
    public class ResourceReference
    {
        public ResourceReference(long id,string href)
        {
            Id = id;
            Href = href;
        }

        public long Id { get; }
        public string Href { get; }
    }
}