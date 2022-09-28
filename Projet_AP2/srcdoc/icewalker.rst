=========================
:mod:`icewalker` module
=========================

Ce module définit des classes et fonctions auxiliaires pour gérer le plateau du jeu de l'icewalker.


Class description
=================

Une classe pour définir un type énuméré pour l'état du jeu.

La classe :class:`GameState`
----------------------------

.. autoclass:: IceWalke2.GameState

Les trois états possibles du jeu : gagnant (winning), perdant (losing), ou inachevé (unfinished) sont décrits par trois attributs de mêmes noms.
			   
La classe :class:`IceWalker`
------------------------------   

.. autoclass:: IceWalker2.IceWalker

Méthodes
~~~~~~~~

.. automethod:: IceWalker2.IceWalker.get_player_position

.. automethod:: IceWalker2.IceWalker.get_final_position

.. automethod:: IceWalker2.IceWalker.get_grid
								
.. automethod:: IceWalker2.IceWalker.get_str_grid

.. automethod:: IceWalker2.IceWalker.get_state

.. automethod:: IceWalker2.IceWalker.get_hauteur

.. automethod:: IceWalker2.IceWalker.get_largeur

.. automethod:: IceWalker2.IceWalker.get_cell

.. automethod:: IceWalker2.IceWalker.get_undo

.. automethod:: IceWalker2.IceWalker.get_redo

.. automethod:: IceWalker2.IceWalker.complete_grid

.. automethod:: IceWalker2.IceWalker.Str

.. automethod:: IceWalker2.IceWalker.move-top

.. automethod:: IceWalker2.IceWalker.set_top

.. automethod:: IceWalker2.IceWalker.move_bottom

.. automethod:: IceWalker2.IceWalker.set_bottom

.. automethod:: IceWalker2.IceWalker.move_right

.. automethod:: IceWalker2.IceWalker.set_right

.. automethod:: IceWalker2.IceWalker.move_left

.. automethod:: IceWalker2.IceWalker.set_left

.. automethod:: IceWalker2.IceWalker.is_solved

.. automethod:: IceWalker2.IceWalker.moves

.. automethod:: IceWalker2.IceWalker.solve

.. automethod:: IceWalker2.IceWalker.change_player_pos

.. automethod:: IceWalker2.IceWalker.undo

.. automethod:: IceWalker2.IceWalker.redo
								
Fonction auxiliaire
===================

