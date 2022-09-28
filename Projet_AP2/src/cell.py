"""
:mod:`cell` module

:author: LE GUEN Romain GELLES Julien LECONTE Louis 

:date: 04/10/2019


"""
class Cell ():
    
    def __init__(self):
        self.__final = False
        self.__east_wall = False
        self.__south_wall = False
        self.__got_player = False
        
    def is_final (self):
        """
        Dit si la cellule est finale
        """
        return self.__final
    
    def set_final (self):
        self.__final = True
        
    def is_east_wall (self):
        return self.__east_wall
    
    def set_east_wall (self):
        self.__east_wall = True
        
    def is_south_wall (self):
        return self.__south_wall
    
    def set_south_wall (self):
        self.__south_wall = True
        
    def got_player (self):
        return self.__got_player
    
    def set_player (self):
        self.__got_player = True
    
    def unset_player (self):
        self.__got_player = False