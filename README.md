SSWDI

[![Build Status](https://dev.azure.com/rgroenewold3/Avans%20Fysio/_apis/build/status/Avans%20Fysio-ASP.NET%20Core-CI?branchName=main)](https://dev.azure.com/rgroenewold3/Avans%20Fysio/_build/latest?definitionId=7&branchName=main)
 

Documentation can be found in the folder Docs.

# Avans Fysio
This piece of software is made for the fysio project. This project includes a webservice and a website. Within the webservice, we want to emulate a way of a dutch standard of diagnoses and treatments for those diagnoses. It's possible with a API Richard level 2 to fetch data you need. But provides a way of a modern standard with GraphQL. The website provides a way of having employee's and patients. The employee's can create diagnoses and treatments for those diagnoses. The patients can view their diagnoses and treatments. 



# To do list: 
- [ ] Make tests for the business rules
  - [ ] Make tests based on interfaces.


## UML Diagrams
- Package- en klassendiagram voor toepassing van clean (onion) architectuur.
- Componentdiagram voor het gehele systeem.
- Deploymentdiagram voor het gehele systeem.


## User stories done. 
- [x] US_01
- [X] US_02 
- [x] US_03
- [x] US_04
- [x] US_05
- [x] US_06


## Business rules done.
- [x] BR_1 
- [x] BR_2
- [x] BR_3 // Only check the "After treatment is finished/ended date check" part.
- [x] BR_4 // Make the description mandetory if webservice is asking for it.
- [x] BR_5 // Just the test needs to be made
- [x] BR_6 // Just the test needs to be made


### Business rules
- **BR_1** Het maximaal aantal afspraken per week wordt niet overschreden bij het boeken van een afspraak.
- **BR_2**. Afspraken kunnen alleen worden gemaakt op beschikbare momenten van de
hoofdbehandelaar. Hierbij moet rekening gehouden worden met de algemene
beschikbaarheid en de reeds gemaakte afspraken.
- **BR_3** Een behandeling kan niet in worden gevoerd als de patiént nog niet in de praktijk is geregistreerd of nadat de behandeling is beéindigd.
- **BR 4** Bij een aantal behandelingen is een toelichting verplicht.
- **BR_5** De leeftijd van een patiént is > 16.
- **BR_6** Een afspraak kan niet door een patient worden geannuleerd minder van 24 uur voorafgaand aan de afspraak.


# Accounts
| Account name |  Role  | Password |
|:-|:-:|-:|
| ryangroenewold@hotmail.com  | Employee | "Secret1234!" |
| IiroCharmian@student.nl   |  Student  |   "Secret1234!" |
| olaEliza@hotmail.com  | Patient |    "Secret1234!" |
| sriJudd@hotmail.com   | Patient |    "Secret1234!" |



## graphql examples

### Get a single diagnosis
query GetTreat($code : String!){
  treatmentByCode(code: $code){
    code,
    description
  }
}

### Get a single diagnosis
query GetDiag($id : Int!){
  diagnosesByCode(id: $id){
    ...diagnoses2
  }
}

### Get all Treatments
query GetAllTreat{
  treatments {
    code
    description
  }
}

### Get all Diagnosis
query GetAllDiag{
  diagnoses {
    ...diagnoses2
  }
}

### Fragment example
fragment diagnoses2 on Diagnosis{
  id,
  bodyLocation,
  code,
  pathology
}

### Mutating example
mutation MutateDiagnosis($diagnosis : DiagnosisInput!){
  addDiagnosis(input: $diagnosis) {
    diagnosis {
      code,
      bodyLocation,
      pathology
    }
  }
}