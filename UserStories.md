# **User Stories**

- ### **US_01**: 
  - ### Als fysiotherapeut wil ik een nieuwe patient in kunnen voeren in het systeem, zodat ik deze patient ook kan gaan behandelen.

Toelichting: Een medewerker of student die patient wil worden, moet natuurlijk eerst ingeschreven worden. Dit gebeurt tijdens het intakegesprek. Tijdens dit gesprek worden onderzoeken gedaan en de resultaten van deze onderzoeken worden als aantekeningen in het nieuw gemaakte dossier geplaatst. Bovendien
wordt een behandelplan opgesteld. Deze user Story mag alleen door een fysiotherapeut uit worden gevoerd. Studenten mogen dit nog niet zelfstandig doen. Als een student deze Stap uitvoert, dan moet dit opgenomen worden in het dossier onder wiens toezicht deze intake is uitgevoerd (het veld Intake onder supervisie van moet verplicht ingevuld worden).

In het behandelplan wordt bijgehouden hoeveel behandelingen per week moeten worden gedaan en
hoe lang elke sessie moet duren, De diagnosecode en -omschrijving moet opgehaald worden uit het
DCSPH-register (via een zelf te bouwen webservice, Zie kopje Opdracht voor meer informatie). In dit
register Worden de standaard diagnoses vastgelegd. De lijst is hier te vinden:
https://www.vektis.nl/u
2021 Versie 4.4


- ### **US _02** :
  - ### Als fysiotherapeut/student wil ik de status van een patiént bij kunnen werken, zodat de status duidelijk altijd up-to-date is.

**Toelichting**:
Een fysiotherapeut/student moet de status van een patiént/dossier bij kunnen werken. Voor ons
systeem betekent dit concreet:
De gegevens van de patiént moeten aan kunnen worden gepast.
Een behandeling moet in kunnen worden gevoerd bij het patiéntdossier.
Bestaande behandelingen moeten kunnen worden gewijzigd of verwijderd. Dit mag alleen op
dezelfde dag als de behandeling gemaakt is, orn correcties mogelijk te maken.
Opmerkingen moeten bij het patiéntdossier kunnen worden geplaatst, De opmerkingen zijn
read-only, dus eenmaal geplaatste opmerkingen kunnen NIET worden aangepast.
Een nieuwe afspraak moet kunnen worden gemaakt (IJS_06).
Van een behandeling moeten de volgende gegevens bij worden gehouden (dikgedrukte gegevens zijn
onconditioneel verplicht):
ld (automatisch door systeem bepaald)
Type (uit Vektis-lijst)
Omschrijving
Oefenzaal of behandelruimte
Een behandeling mag alleen in worden gevoerd in het systeem als de behandeling na de datum
binnenkomst ligt en voor de datum ontslag van de patiént.
De typen behandelingen zijn afkomstig uit een Vektis-lijst voor paramedische zorg (COD192-VEK1, Zie
https://tog.vektis.nl/Bestanden/Prestatiecodelijsten/012_-_PC_PARAMED_HULP_(COD192-VEK1)=
_20170901(51) .xlsx) via een zelf te bouwen webservice, Zie kopje Opdracht voor meer informatie). Aan
de hand van deze codes kan een zorgverlener declaraties indienen bij de zorgverzekeraar van de
patiént. Deze lijst wordt dus gebruikt om aan te geven welke behandelingen uitgevoerd Zijn bij een
patiént die een bepaalde diagnose heeft gekregen.
Een behandeling wordt uitgevoerd in de oefenzaal Of in de behandelruimte, Dit is een eigenschap van
een type behandeling. De gebruiker moet hieruit kunnen kiezen.
Bij de behandelingen waarbij in de Vektis-lijst is opgenomen dat een toelichting verplicht is, moeten
verplicht de bijzonderheden in worden gevuld. De Vektis-lijst ontsluit je met een zelf te bouwen
webservice.



- ### **US _03** 
  - ### Als fysiotherapeut/student wil ik een overzicht hebben van al mijn afspraken op een dag, zodat ik weet welke patiénten ik moet behandelen op een dag

**Toelichting**:
Patiénten komen in de praktijk zelfstandig binnen en wachten in de wachtruimte, Als behandelaar wil
ik een overzicht hebben wie ik moet behandelen, zodat ik voordat ik de patiént binnen roep, snel in
het dossier kan kijken, zodat ik weet wat ik moet doen. Daarom moet deze lijst ook gesorteerd zijn
op basis van de behandeltijd op die dag. 1k wil 00k de mogelijkheid hebben om losse afspraken toe te
voegen. Deze afspraken moeten of vandaag zijn of de datum van de afspraak moet in de toekomst
liggen.

- ### **US_04** 
  - ### Als patient wil ik online mijn afsproken kunnen beheren, zodat ik niet altijd de praktijk hoef te bellen

**Toelichting**:
Als patiént wil ik graag online mijn afspraken in kunnen zien, kunnen wijzigen of een nieuwe afspraak
kunnen maken. Annuleren Of wijzigen van een afspraak kan alleen maar meer dan 24 uur van tevoren.
Een nieuwe afspraak wordt gemaakt bij mijn eigen hoofdbehandelaar en alleen als deze beschikbaar
is. In mijn behandelplan staat hoeveel sessies ik per week moet volgen en hoe lang deze moeten durene
1k mag niet meer sessies per week inplannen dan in mijn behandelplan Staat opgenomen. Voor dete
functionaliteit moet ik in kunnen loggen in het systeem. 1k kan me zelf registreren in het systeem als ik
nog geen account heb. 1k moet bij het registreren hetzelfde e-mailadres gebruiken als ik doorgegeven
heb tijdens de intake,

- ### **US_05**  
  - ### Als klant Wil ik online inzage hebben in mijn behandeldossier.

**Toelichting**:
In het kader van transparantie wil ik als patiént inzage in mijn dossier hebben. 1k mag geen wijzigingen
in mijn dossier aanbrengen, met uitzondering van mijn eigen adresgegevens. Opmerkingen die als niet
zichtbaar voor de patiént zijn gemarkeerd, zullen niet worden getoond.

- ### **US_06** 
  - ### Als fysiotherapeut/student wil een nieuwe afspraak kunnen maken voor behandeling van een potiént, 20dat een patiént meteen een nieuwe afspraak heeft.
  
**Toelichting**:
Als fysiotherapeut/student wil ik een nieuwe afspraak kunnen maken voor een patiént die ik aan het
behandelen ben. De datum van de afspraak kan alleen in de toekomst liggen en kan worden gemaakt
bij de actieve behandelaar of als de actieve behandelaar een fysiotherapeut is, bij een student. In het
behandelplan staat hoeveel sessies per week gehouden moet worden en hoelang deze moeten duren.
Er mogen niet meer sessies per week ingepland Worden dan in het behandelplan staat opgenomen.
De afspraak mag alleen worden gemaakt op een moment dat nog beschikbaar is voor de gekozen
behandelaar.




## **UML Diagrammen:**
De beschrijving van het Fysiotherapie-systeem is vrij generiek. Je geeft zelf de opdracht meer kleur door een thema te kiezen, door je bijvoorbeeld te richten op jonge mensen, ouderen, enz. Je houdt daarbij expliciet rekening met betrekking tot het UX-design. Je stuurt hiermee ook welke persona je van toepassing vindt en welke maatregelen je treft om een gebruiksvriendelijke userinterface te maken. De uitwerking het UX-design neem je op in het portfolio dat dat vak is
voorgesch Je maakt ook een aantal (U ML-)diagrammen:
- Package- en klassendiagram voor toepassing van clean (onion) architectuur.
- Componentdiagram voor het gehele systeem.
- Deploymentdiagram voor het gehele systeem.
- De diagrammen heb je zelf met de hand gemaakt en zijn dus niet gegenereerd vanuit de code door bijvoorbeeld Visual Studio.
 
De Avans Fysio WebService biedt zijn functionaliteit aan via een correcte RESTful Web API die voldoet
aan **Richardson level 2 en een los GraphQL-endpoint**. **De RMM2 variant voldoet aan de volgende
criteria voor RESTful architectuur constraints** (Zie ook studiemateriaal SO&A 2):
- Client/server
- Resources
- Standard
- operations
- Stateless communication
- Resources with multiple representations






## Business Rules
- **BR_1** Het maximaal aantal afspraken per week wordt niet overschreden bij het boeken van een afspraak.
- **BR_2**. Afspraken kunnen alleen worden gemaakt op beschikbare momenten van de
hoofdbehandelaar. Hierbij moet rekening gehouden worden met de algemene
beschikbaarheid en de reeds gemaakte afspraken.
- **BR_3** Een behandeling kan niet in worden gevoerd als de patiént nog niet in de praktijk is geregistreerd of nadat de behandeling is beéindigd.
- **BR 4** Bij een aantal behandelingen is een toelichting verplicht.
- **BR_5** De leeftijd van een patiént is > 16.
- **BR_6** Een afspraak kan niet door een patient worden geannuleerd minder van 24 uur voorafgaand aan de afspraak.



## In te leveren:
- pdf met (UML-)diagrammen en verdere onderbouwing.
- Gehele Visual Studio solution met alle projecten, zonder obj-files, binaries en packages folders.
- Gebruik de functie 'Clean Project' uit het menu en verwijder eventueel de packages folder!
- URL van de gedeployde applicatie op Azure zodat de applicatie bezocht kan Worden.
- Een account (gebruikersnaam én wachtwoord) waarmee de docent kan inloggen op jouw
webapplicatie in Azure. Dit account moet voldoende rechten hebben om alle activiteiten van
een docent uit te kunnen voeren,
- Binnen de gedeployde applicatie moeten een aantal gebruikers (docenten en studenten)
aanwezig zijn als behandelaar en een aantal patiénten.
- Swagger API documentatie
- Postman collection
- Video met een schermopname om aan te tonen dat alle functionaliteit in de applicatie is
opgenomen. De scriptstappen zullen worden gecommuniceerd.


Bovenstaande producten ingepakt in I zipfile met de volgende naam:
<klas> - <voomaam + achternaam> - IVT2-1-FysioApp.zip
