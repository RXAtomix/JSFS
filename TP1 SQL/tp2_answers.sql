--
-- TP de Le Guen Romain et Olivier Tan
--

--Question 5)
----a)
-----

---- on joint les coureurs avec leur équipes

----b)
-----

select coureurs.nom, dossard, equipe, couleur from (equipes join coureurs on equipe=equipes.nom)

----c)
-----

select coureurs.nom, directeur from (equipes join coureurs on equipe=equipes.nom)

----d)
------

select coureurs.nom, dossard from (equipes join coureurs on equipe=equipes.nom) where directeur='Ralph'

----e)
-----

select directeur from (equipes join coureurs on equipe=equipes.nom) where coureurs.nom='alphonse'

--Question 6)
----a)
-----

insert into equipes values ('DebanMaxxc','Marron','Sam')
