-> MAIN

=== MAIN ===
Hallo! #speaker: Bart #portrait: NPC1Dialogue

De vader van Jelle, Bart, vertelt trots tegen jou dat Jelle van 3,5 jaar al goed kan rekenen. Hij oefent iedere dag met hem de tafels. Hij vraag of jij bij het kinderdagverblijf hier met Jelle ook wat mee kan oefenen. Je hebt al vaker gemerkt dat Jelle door zijn ouders behoorlijk overvraagd wordt. Jelle is in jouw ogen nog echt niet toe aan tafels oefenen. #speaker: Verteller

Je zou het veel belangrijker vinden als Jelle wat meer met andere kinderen zou spelen en eens lekker buiten zou rennen. Je maakt je namelijk een beetje zorgen om Jelle want hij speelt tot nu toe nog helemaal niet met andere kinderen. Jij moet in gesprek gaan met vader om jouw zorgen te delen en een advies te geven. Hoe ga je dit gesprek voeren? #speaker: Verteller

+ [Je maakt een afspraak voor een zitgesprek]
    -> chosen1
    
+ [Je bespreekt de ouders in een sta gesprek]
    -> chosen2

=== chosen1 ===
Welkom, wat fijn dat u er bent. Kom binnen en dan zoeken we even een rustig plekje om te gaan zitten. #speaker: U

Bedankt. #speaker: Bart #speaker: NPC1Dialogue

-> MAIN1

=== chosen2 ===
Ik wil het graag met u hebben over de sociaal-emotionele ontwikkeling van Jelle. We merken dat hij het lastig vindt om met andere kinderen te spelen. #speaker: U

Dit is een serieus onderwerp, dat kunnen we toch niet bespreken hier bij de deur. Ik voel me niet serieus genomen door jullie. Laat maar zitten, we oefenen thuis wel. #speaker: Bart #speaker: NPC1DialogueAngry

OPNIEUW BEGINNEN #speaker: Verteller

-> MAIN





=== MAIN1 ===
Waar start je het gesprek mee? #speaker: Verteller

+ [Start direct met het geven van jouw advies]
    -> chosen3
    
+ [Je houd en social talk]
    -> chosen4
    
=== chosen3 ===
Het lijkt ons goed als Jelle vaker met andere kinderen gaat afspreken. #speaker: U

Ik kom hier met de vraag of jullie met mijn zoon willen rekenen en vervolgens krijg ik een advies waar ik niet om heb gevraagd. Daarnaast kan mijn zoon heel goed samen spelen met andere kinderen. #speaker: Bart

OPNIEUW BEGINNEN #speaker: Verteller

-> MAIN1

=== chosen4 ===
Fijn dat je er bent. Hoe gaat het met jullie en Jelle? #speaker: U

Het gaat goed met ons en ook met Jelle gaat het super goed. We oefenen iedere dag met de tafels en hij kan hierdoor al super goed rekenen. #speaker: Bart

Fijn om te horen dat het thuis goed gaat met Jelle. #speaker: U

-> MAIN2





=== MAIN2 ===
Met welke fase ga je nu verder? #speaker: Verteller

+ [Planningsfase]
    -> chosen5
    
+ [Aanloopfase]
    -> chosen6
    
=== chosen5 ===
Vanochtend gaf u aan dat u het fijn zou vinden als wij samen met Jelle op de groep wat meer bezig zouden zijn met rekenen. Naar aanleiding daarvan leek het mij fijn om het hier iets uitgebreider over te hebben. We hebben voor dit gesprek ongeveer een 15 minuten. Heeft u nog andere punten die u tijdens dit gesprek wilt bespreken? #speaker: U

 Wat fijn dat je hier de tijd voor neemt. Jelle is inderdaad erg goed met rekenen en daarom zou ik het fijn vinden als jullie hier op de groep ook wat meer mee aan de slag zouden gaan. Verder heb ik geen punten. #speaker: Bart
 
 -> MAIN3

=== chosen6 ===
Hoe was het op vakantie? Ik begreep van Jelle dat jullie naar Spanje zijn geweest. #speaker: U

Kunnen we to the point komen. We ziten hier voor het reken van mijn zoon en niet voor de gezelligheid. #speaker: Bart

OPNIEUW BEGINNEN #speaker: Verteller

-> MAIN2





=== MAIN3 === 
Wat zeg je tegen de vader? #speaker: Verteller

+ [Compliment over het rekenen en geef aan dat je ziet dat Jelle sociaal-emotioneel wat moeite heeft.]
    -> chosen7
    
+ [Compliment over het rekenen, geef aan dat je ziet dat Jelle sociaal-emotioneel wat moeite heeft, maar dat vader ook wel veel van hem vraagt.]
    -> chosen8
    
=== chosen7 ===
Jelle kan inderdaad goed rekenen dat is super knap. Wij merken alleen dat hij op sociaal-emotioneel vlak wat meer moeite heeft. Hij vindt het lastig om contact te maken met andere kinderen. Hoe kijkt u daar tegenaan? #speaker: U

Hier schrik ik van. Hij heeft geen broers en zussen en daarom gaan we vaak naar de speeltuin toe zodat hij wel in contact komt met andere kinderen. Ik merk dan inderdaad vaak dat hij alleen speelt. Wat kunnen we doen? Wat is jullie advies? #speaker: Bart

-> MAIN4


=== chosen8 ===
Jelle kan inderdaad goed rekenen, dat is super knap. Hij loopt alleen wel achter in de sociaal-emotionele ontwikkeling. U vraagt als ouder ook wel veel van hem. #speaker: U

Hij wil graag leren en er is niks mis mijn zijn sociaal emotionele ontwikkeling. Hij is dan wel enigst kind, maar speelt graag met andere kinderen. #speaker: Bart

OPNIEUW BEGINNEN #speaker: Verteller

-> MAIN3





=== MAIN4 ===
Welk advies geef je de vader? #speaker: Verteller

+ [De vader kan zich beter kan focussen op het spelen met andere kinderen i.p.v. het oefenen met rekenen.]
    -> chosen9
    
+ [Teamsport en het stimuleren van samenspelen met andere kinderen kan helpen en vraag hoe vader dit ziet.]
    -> chosen10
    
=== chosen9 ===
Misschien kunt u minder tijd stoppen in het oefenen van rekenspellen, maar hem meer laten spelen met andere kinderen. #speaker: U

 Ik doe ook alleen maar mijn best en nu vertelt u dat ik het niet goed doe. #speaker: Bart
 
 OPNIEUW BEGINNEN #speaker: Verteller
 
 -> MAIN4
 
 === chosen10 ===
 Misschien kun je Jelle mee laten doen aan een teamsport of hem vaker laten afspreken. Hoe kijkt u hier tegen aan? We kunnen jullie natuurlijk ook hierin begeleiden? #speaker: U
 
 Bedankt voor jullie advies hier gaan we mee aan de slag. #speaker: Bart
 
 -> MAIN5
 
 
 
 
 
 === MAIN5 ===
 Hoe sluit je het gesprek af? #speaker: Verteller
 
 + [Vat het gesprek samen en sluit het gesprek af.]
    -> chosen11
    
+ [Bedank vader voor het gesprek.]
    -> chosen12
    
=== chosen11 ===
Wat fijn om te horen. Kort samengevat hebben we zojuist besproken dat Jello inderdaad erg goed kan rekeken, maar dat hij op sociaal-emotioneel gebied moeite heeft. Zo heeft hij moeite met het maken van contact met anderen. #speaker: U

Naar aanleiding daarvan gaf u ook aan dat u merkt dat hij vaak alleen speelt en daarom heb ik het advies gegeven om samen met Timo te kijken naar een sport waarin hij leert samenspelen zoals bijvoorbeeld voetbal, maar daarnaast kan het ook helpen om hem vaker met andere kinderen af te laten spreken. Klopt dit? #speaker: U

 Ja inderdaad, fijn dat advies! #speaker: Bart
 
 Dan wil ik u hartelijk bedankt voor het gesprek en hoor ik het graag wanneer u vragen heeft. FIjne avond! #speaker: U
 
 Bedankt voor het prettige gesprek. Fijne dag nog. #speaker: Bart
 
 -> END

=== chosen12 ===
Bedankt voor het prettig gesprek. Ik wil u nog een fijne avond wensen. #speaker: U

Ik had het prettig gevonden als je alles nog eens had herhaald. We hebben zoveel besproken, ik weet niet meer precies wat ik nu moet doen. #speaker: Bart

OPNIEUW BEGINNEN #speaker: Verteller

-> MAIN5



























