using ContosoConsultancy.Rest.Client.ContosoConsultancyRest.Models;

namespace ContosoConsultancy.Administration.UI.Model
{
    public class ConsultantWrapper
    {
        public ConsultantWrapper(ContosoConsultancyRestModelsConsultantsConsultantModel consultant)
        {
            Consultant = consultant;
        }

        public ContosoConsultancyRestModelsConsultantsConsultantModel Consultant { get; }

        public override string ToString()
        {
            return $"{Consultant.Name} {Consultant.FirstName}";
        }
    }
}
