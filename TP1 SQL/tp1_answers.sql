--
-- TP de Le Guen Romain et Olivier Tan
--

--
--Question 1
----a)
------

select dossard,nom from coureurs

----b)
------

select dossard,nom from coureurs ORDER BY dossard

----c)
------

select equipe,dossard,nom from coureurs ORDER BY equipe,nom

----d)
------

select taille,dossard,nom from coureurs ORDER BY taille

----e)
-----

select nom,dossard from coureurs where equipe='LavePlusBlanc'

----f)
------

select "nom","dossard" from coureurs where "equipe"='LavePlusBlanc'

----g)
------

select nom,taille,equipe from coureurs where taille < 180

----h)
------

select nom,taille,equipe from coureurs where taille < 180 ORDER By taille

----i)
------

select couleur from equipes

--Question 2
----a)
-----

select nom||' appartient à l''équipe '|| equipe from coureurs

----b)
------

select nom || 'appartient à l''équipe'|| equipe as appartenance from coureurs

----c)
-----

select upper(nom)as "nom maj", char_length(nom) as lg from coureurs

----d)
------

select upper(nom)as "nom maj", char_length(nom) as lg from coureurs order by lg
select upper(nom)as "nom maj", char_length(nom) from coureurs order by char_length(nom)

----e)
------
select dossard, initcap(nom) as "nom", upper(substring(equipe for 3)) as "EQU" from coureurs

--Question3
----a)
------

select nom from coureurs where nom like 'a%'

----b)
------

select nom from coureurs where nom like '%er%'

----c)
------

select nom from coureurs where nom like '_____'

----d)
-----

select nom from coureurs where nom like '%a__'

----e)
------

select nom from coureurs where nom like '%a__%'

--Question 4)
-----a)
------

select taille/100 from coureurs;

----b)
-----

select taille/100.0 from coureurs
-- Il y a beaucoup trop de zéro derrière la virgule

----c)
-----

select cast(taille/100.0 as numeric(3,2)) as "taille en mètres" from coureurs

----d)
------

select trunc(taille/100.0,2) as "taille en mètres" from coureurs
