# Interview Task for Madiff

## Założenia i podejście
Obecne rozwiązanie skupia się na czytelności kodu i możliwości łatwego rozszerzenia funkcjonalności - nawet w przypadku złożonych reguł biznesowych. Na podstawie treści zadania przyjąłem, że takie rozwiązanie jest oczekiwane a wszystkie akcje są znane podczas kompilacji. W realnym projekcie podejście mogłoby być inne w zależności od przedyskutowanych ustaleń i wymagań.

### Alternatywne rozwiązania
Podczas implementacji rozważyłem jakie inne rozwiązania by były korzystne w przypadku innych wymagań. Na przykład w przypadku gdy definicje akcji miałyby pochodzić z zewnętrznego źródła (np. API lub pliku JSON), można zastosować strukturę opartą na `Dictionary<CardStatus, CardCondition>`, gdzie `CardCondition` byłby typem enum mapowanym na odpowiednie wyrażenia logiczne.