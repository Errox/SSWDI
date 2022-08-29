using MainLibrary.DomainModel;

namespace Avans_Fysio_WebService.GraphQL.Mutations.Payloads
{
    public class AddTreatmentPayload
    {
        public AddTreatmentPayload(Treatment treatment)
        {
            Treatment = treatment;
        }

        public Treatment Treatment { get;  }
    }
}
