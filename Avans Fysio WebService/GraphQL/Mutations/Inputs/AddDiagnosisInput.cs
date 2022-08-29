namespace Avans_Fysio_WebService.GraphQL.Mutations.Inputs
{
    public record AddDiagnosisInput(
        int Code,
        string BodyLocation,
        string Pathology
    );
}
