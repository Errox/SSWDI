SSWDI

[![Build Status](https://dev.azure.com/rgroenewold3/Avans%20Fysio/_apis/build/status/Avans%20Fysio-ASP.NET%20Core-CI?branchName=main)](https://dev.azure.com/rgroenewold3/Avans%20Fysio/_build/latest?definitionId=7&branchName=main)
 



# Avans Fysio




# To do list:
- [ ] Finish the TODO: in the project.
  - [ ] Make the link with webservice
- [ ] Make diagrams
- [ ] Make the API Richardson Level 2
- [ ] Make tests based on interfaces.
- [ ] Double check the user stories 
- [ ] Double check the Business Rules
- [ ] Make tests for the business rules
- [ ] Write a good Readme
- [ ] Give the site a little makeover
- [ ] Button on MedicalFile on patients profile to check appointments.



## UML Diagrams
- Package- en klassendiagram voor toepassing van clean (onion) architectuur.
- Componentdiagram voor het gehele systeem.
- Deploymentdiagram voor het gehele systeem.


## User stories done. 
- [x] US_01
- [ ] US_02 // Double check if this is done.
- [x] US_03
- [x] US_04
- [x] US_05
- [x] US_06


## Business rules done.
- [ ] BR_1 
- [x] BR_2
- [ ] BR_3
- [ ] BR_4
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