# AplikacjaKulinarna-Backend

-------------------------------------WYMAGANIA--------------------------------------------------

Aplikacja kulinarna.
Wymagania:
1.	.Net Core, Entity Framework Core, BazaDanych MS SQL, dowolny framework javascriptowy

Podstawowe funkcjonalności:
1.	Dodawanie/ usuwanie/ edytowanie przepisów (produkty potrzebne, czas przygotowania, opis).
2.	Wyszukiwarka przepisów na podstawie :
•	produktów 
•	czasu przygotowania, 
•	nazw przepisów. 
3.	Filtrowanie przepisów po: 
•	Jakości.
•	Trudności wykonania.
•	Czasie przygotowania.
4.	Ocena jakości przepisów (ilość gwiazdek)
5.	Ocena trudności wykonania.
Dodatkowe :
1.	Deploy aplikacji na platformę Azure. 
2.	Autoryzacja z wykorzystaniem Identity Model

Podstawowe założenia: 
Cała logika dotycząca funkcjonalności wykonywana ma być po stronie backendu. Komunikacja backend – frontend 
powinna odbywać się poprzez Web Api. Backend powinien opierać się o architekturę Onion. 
Frontend powinien być osobną aplikacją typu SPA. Seed przykładowych przepisów na starcie aplikacji.

---------------------------------------------OPIS----------------------------------------------------------------

Udało mi się zrobić dodawanie/usuwanie oraz edycję przepisów (nazwa, produkty,czas przygotowanie, opis),
wyszukiwanie przepisów po nazwie, czasie przygotowanie, produktach i tutaj chciałbym zaznaczyć, że w Postmanie wszystko działa dobrze, 
ale na froncie jak wpisuje w input jakąs frazę np. (pierogi) to czasem wyszuka dobrze a czasem jakby sie zawiesiło. Walczyłem z tym,
ale jak narazie nie znalazlem rozwiązania :( . Oprócz tego po stronie backendu jest jeszcze dodawanie oceny jakosci przepisów oraz 
trudności wykonania. Front robiłem w Angularze, natomiast backend .NET CORE 2.1. Mam nadzieję, że ma to sens ponieważ pierwszy raz pisałem w .NET Core :)

Serdecznie pozdrawiam, 
Konrad Bywald
