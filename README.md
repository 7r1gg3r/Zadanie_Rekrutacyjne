# T_Komp_zadanie

Przygotowanie Bazy Danych
1. Create
W celu utworzenia bazy danych tworzymy nowe Query w serwerze SQL
CREATE DATABASE [DevData];
Po czym wykonujemy to query w celu utworzenia bazy.

2. Dodanie Tablic
Nast�pnie w tej bazie danych, b�d� w tym samym query (dzi�ki funkcji GO po CREATE DATABASE) umieszczamy reszt� query, tworz�ca tabel� z warto�ciami kolumn
CREATE TABLE [DevData].dbo.Table_A (Col_A1 int, Col_A2 varchar(10), Col_A3 date);
CREATE TABLE [DevData].dbo.Table_B (Col_B1 int, Col_B2 nchar(10), Col_B3 int);
CREATE TABLE [DevData].dbo.Table_C (Col_C1 varchar (10), Col_C2 timestamp, Col_C3 int, Col_C4 char(10) );
Po uruchomieniu stworzy si� tablice z kolumnami o podanych typach.

3. Dodanie custom usera z has�em
Przechodzimy w podgl�dzie serwera do Nazwa_serwera > Security > Logins. Klikamy prawym przyciskiem myszki na Logins i tworzymy nowy login.
Nazywamy nowego u�ytkownika oraz wybieramy opcj� SQL Server Authentication, kt�ra pozwoli nada� has�o tworzonemu u�ytkownikowi. 
Odklikujemy wymagan� polityk� zmiany has�a przy pierwszym logowaniu itp. dla uproszczenia.
Po wpisaniu loginu i has�a zatwierdzamy.

4. Dodanie mu uprawnie�
Klikamy PPM na u�ytkownika i przechodzimy do Properties. W Properties > Server Roles nadajemy u�ytkownikowi na wszelki wypadek
wszystkie role systemowe (sysadmin, serveradmin, setupadmin, securityadmin) i zatwierdzamy. To r�wnie� dla uproszczenia.


Przygotowanie aplikacji
1. Zmiana connection stringa w konstruktorze
W celu uruchomienia bazy danych na innym komputerze nale�y zmieni� definicj� connection stringa w konstruktorze.
Konstruktor ten znajduje si� w pliku Database_View_Model.cs, linijka 89.
Zmieniamy DataSource w connectionString na w�asn� nazw� serwera.