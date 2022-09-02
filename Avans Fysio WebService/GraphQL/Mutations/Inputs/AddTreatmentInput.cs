namespace Avans_Fysio_WebService.GraphQL.Mutations.Inputs
{
    public record AddTreatmentInput(
        string Code,
        string Description,
        bool ExplanationRequired
    );
}
