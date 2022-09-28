==================
:mod:`cell` module
==================


Ce module définit une classe pour représenter les cellules (ou cases) d'un plateau de
jeu d'ice walker.

Une cellule peut être

*finale
*contenir un mur à l'ouest
*contenir un mur au sud
*contenir un joueur



Class description
-----------------

.. autoclass:: cell.Cell

Methods
-------

.. automethod:: cell.Cell.is_final

.. automethod:: cell.Cell.set_final

.. automethod:: cell.Cell.is_east_wall

.. automethod:: cell.Cell.set_east_wall

.. automethod:: cell.Cell.is_south_wall

.. automethod:: cell.Cell.set_south_wall
								
.. automethod:: cell.Cell.got_player_

.. automethod:: cell.Cell.set_player
								
.. automethod:: cell.Cell.unset_player
	
			   
Special method
--------------

Only two special methods for this class.

.. automethod:: cell.Cell.__init__
