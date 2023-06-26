SSWDI

[![Build Status](https://dev.azure.com/rgroenewold3/Avans%20Fysio/_apis/build/status/Avans%20Fysio-ASP.NET%20Core-CI?branchName=main)](https://dev.azure.com/rgroenewold3/Avans%20Fysio/_build/latest?definitionId=7&branchName=main)
 

Diagrams can be found in the folder Docs.

Video : https://www.youtube.com/watch?v=zBSGS44h-H8

Video Drive: https://drive.google.com/uc?id=1nzxLkVjsOfV9m1B_QjBHwN01fAvvSqbE&export=download

Github Repository : https://github.com/Errox/SSWDI

# Avans Fysio
This piece of software is made for the fysio project. This project includes a webservice and a website. Within the webservice, we want to emulate a way of a dutch standard of diagnoses and treatments for those diagnoses. It's possible with a API Richard level 2 to fetch data you need. But provides a way of a modern standard with GraphQL. The website provides a way of having employee's and patients. The employee's can create diagnoses and treatments for those diagnoses. The patients can view their diagnoses and treatments. 


## UML Diagrams
- Package- en klassendiagram voor toepassing van clean (onion) architectuur.
- Componentdiagram voor het gehele systeem.
- Deploymentdiagram voor het gehele systeem.


# Accounts
| Account name |  Role  | Password |
|:-|:-:|-:|
| ryangroenewold@hotmail.com  | Employee | "Secret1234!" |
| IiroCharmian@student.nl   |  Student  |   "Secret1234!" |
| olaEliza@hotmail.com  | Patient |    "Secret1234!" |
| sriJudd@hotmail.com   | Patient |    "Secret1234!" |

## Azure Locations
| Application | URL | 
|:-|:-:|
| Fysio Web Appliction  | https://fysiowebapplication.azurewebsites.net/ |
| Fysio Web Service   |  https://localhost:44353/  |  
| Fysio Web service GraphQL  | https://localhost:44353/graphql/ |  
| Fysio Web Service Swagger   | https://localhost:44353/swagger/index.html |  



## GraphQL examples

### Get a single diagnosis
`query GetTreat($code : String!){
  treatmentByCode(code: $code){
    code,
    description
  }
}`

### Get a single diagnosis
`query GetDiag($id : Int!){
  diagnosesByCode(id: $id){
    ...diagnoses2
  }
}`

### Get all Treatments
`query GetAllTreat{
  treatments {
    code
    description
  }
}`

### Get all Diagnosis
`query GetAllDiag{
  diagnoses {
    ...diagnoses2
  }
}`

### Fragment example
`fragment diagnoses2 on Diagnosis{
  id,
  bodyLocation,
  code,
  pathology
}`

### Mutating example
`mutation MutateDiagnosis($diagnosis : DiagnosisInput!){
  addDiagnosis(input: $diagnosis) {
    diagnosis {
      code,
      bodyLocation,
      pathology
    }
  }
}`