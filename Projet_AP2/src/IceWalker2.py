from cell import Cell
from enum import Enum
from queue import *
class GameState(Enum):
    """
    A class to define an enumerated type with three values :

    * ``winning``
    * ``losing``
    * ``unfinished``

    for the three state of minesweeper game.
    """
    winning = 1
    losing = 2
    unfinished = 3

class IceWalker():
    def __init__ (self,file='grid01.txt'):
        self.__player_position = []
        self.__final_position = []
        self.__grid = []
        self.__undo = []
        self.__redo = []
        self.__state = GameState.unfinished
        self.complete_grid(file)
        self.__str_grid = self.__repr__()
        
    def get_player_position(self):
        return self.__player_position
    
    def get_final_position(self):
        return self.__final_position
    
    def get_grid(self):
        return self.__grid
    
    def get_str_grid(self):
        return self.__str_grid
    
    def get_state(self):
        return self.__state
    
    def get_hauteur(self):
        grid = self.get_grid()
        return len(grid)
    
    def get_largeur(self):
        grid = self.get_grid()[0]
        return len(grid)
        
    def get_cell(self, x, y):
        return self.__grid[x][y]
    
    def get_undo (self):
        return self.__undo
    
    def get_redo(self):
        return self.__redo
    
    def complete_grid(self,file='grid01.txt'):
        fichier = open('../data/'+file,'r')
        lect = fichier.readline()
        grid=self.get_grid()
        player_position = self.get_player_position()
        final_position = self.get_final_position()
        while lect != '':
            if lect == '# dimensions\n':
                dim = fichier.readline()
                list_dim = dim[:-1].split(',')
                hauteur = int(list_dim[1])
                largeur = int(list_dim[0])
                for j in range (hauteur):
                    l = []
                    for i in range (largeur):
                        c = Cell()
                        l.append(c)
                    grid.append(l)
                lect = fichier.readline()
            elif lect =='# final cell\n':
                fin=fichier.readline()
                list_fin = fin[:-1].split(',')
                final_position.append((int(list_fin[0]),int(list_fin[1])))
                grid[int(list_fin[1])][int(list_fin[0])].set_final()
                lect=fichier.readline()
            elif lect == '# number of players\n':
                num = fichier.readline()
                list_num = int(num)
                lect = fichier.readline()
                lect = fichier.readline()
            elif lect =='# main player\n':
                main = fichier.readline()
                list_main = main[:-1].split(',')
                player_position.append((int(list_main[0]),int(list_main[1])))
                grid[int(list_main[1])][int(list_main[0])].set_player()
                lect=fichier.readline()
            elif lect == '# other players\n':
                for k in range (list_num-1):
                    player = fichier.readline()
                    list_player = player[:-1].split(',')
                    player_position.append((int(list_player[0]),int(list_player[1])))
                    grid[int(list_player[1])][int(list_player[0])].set_player()
                lect=fichier.readline()
            elif lect == '# walls\n':
                lect = fichier.readline()
                while lect != '':
                    list_wall = lect[:-1].split(',')
                    if list_wall[2] == 'E':
                        grid[int(list_wall[1])][int(list_wall[0])].set_east_wall()
                    else:
                        grid[int(list_wall[1])][int(list_wall[0])].set_south_wall()
                    lect = fichier.readline()
        fichier.close()
        
    def __str__(self):
        grid = self.get_str_grid()
        player_position = self.get_player_position()
        final_position = self.get_final_position()
        hauteur,largeur=self.get_hauteur(),self.get_largeur()
        bol = False
        ###BORDURE_NORD###
        s=""
        for i in range(largeur):
            s+="-"
            if i!=largeur-1:
                s+="+"
        print("+"+s+"+")
        ###LIGNES###
        for j in range(hauteur):
            s=""
            s2=""
            for i in range(largeur):
                if (i,j) in player_position:
                    s+=str(player_position.index((i,j)))
                elif (i,j) in final_position:
                    s+="X"
                else:
                    s+="."
                if i!= largeur-1:
                    if "|" in grid[j][i]:
                        s+="|"
                    else:
                        s+=" "
                ###INTER-LIGNES###
                if j != hauteur-1:
                    if i!=largeur-1 and "-" in grid[j][i] and ("-" in grid[j][i+1] or "|" in grid[j][i] or "|" in grid[j+1][i]):
                        s2+="-"
                        if i!=largeur-1:
                            s2+="+"
                    elif i!=largeur-1 and "-" in grid[j][i+1] and ("|" in grid[j+1][i] or "|" in grid[j][i]):
                        s2+=" "
                        if i!=largeur-1:
                            s2+="+"
                    elif "-" in grid[j][i]:
                        s2+="-"
                        if i!=largeur-1:
                            s2+=" "
                    elif "|" in grid[j+1][i] and "|" in grid[j][i]:
                        s2+=" "
                        if i!=largeur-1:
                            s2+="+"
                    else:
                        s2+=" "
                        if i!=largeur-1:
                            s2+=" "
                else:
                    bol = True
            print("|"+s+"|")
            if not bol:
                print("+"+s2+"+")
        ###BORDURE_SUD###   
        s=""
        for i in range(largeur):
            s+="-"
            if i!=largeur-1:
                s+="+"
        print("+"+s+"+")
        
    def __repr__(self):
        str_grid = []
        hauteur,largeur = self.get_hauteur(),self.get_largeur()
        for j in range (hauteur):
            l=[]
            for i in range (largeur):
                e=""
                if self.get_cell(j,i).is_south_wall():
                    e+="-"
                if self.get_cell(j,i).is_east_wall():
                    e+='|'
                else:
                    e+=' '
                l.append(e)
            str_grid.append(l)
        return str_grid
            
    def Str(self):
        return self.__str__()
    
    def move_top(self,joueur):
        joueur_position = self.get_player_position()[joueur]
        new_position = joueur_position
        if joueur!=0 and self.get_cell(new_position[1],new_position[0]).is_final() and not self.get_cell(new_position[1]-1,new_position[0]).is_south_wall() and new_position[1] > 0 and not self.get_cell(new_position[1]-1,new_position[0]).got_player():
            new_position = (new_position[0],new_position[1]-1)
        while not self.get_cell(new_position[1]-1,new_position[0]).is_south_wall() and new_position[1] > 0 and not self.get_cell(new_position[1]-1,new_position[0]).got_player():
            if self.get_cell(new_position[1],new_position[0]).is_final():
                break
            else:
                new_position = (new_position[0],new_position[1]-1)
        return(joueur_position,new_position)
    
    def set_top(self,joueur):
        last_pos = self.move_top(joueur)[0]
        new_pos = self.move_top(joueur)[1]
        undo_list = self.get_undo()
        self.get_cell(last_pos[1],last_pos[0]).unset_player()
        self.__player_position[joueur] = new_pos
        self.get_cell(new_pos[1],new_pos[0]).set_player()
        if last_pos != new_pos:
            undo_list.append((last_pos,joueur))

    def move_bottom(self,joueur):
        joueur_position = self.get_player_position()[joueur]
        hauteur = self.get_hauteur()
        new_position = joueur_position
        if joueur != 0 and self.get_cell(new_position[1],new_position[0]).is_final() and not self.get_cell(new_position[1],new_position[0]).is_south_wall() and new_position[1] < hauteur-1 and not self.get_cell(new_position[1]+1,new_position[0]).got_player():
            new_position = (new_position[0],new_position[1]+1)
        while not self.get_cell(new_position[1],new_position[0]).is_south_wall() and new_position[1] < hauteur-1 and not self.get_cell(new_position[1]+1,new_position[0]).got_player():
            if self.get_cell(new_position[1],new_position[0]).is_final():
                break
            else:
                new_position = (new_position[0],new_position[1]+1)
        return(joueur_position,new_position)
    
    def set_bottom(self,joueur):
        last_pos = self.move_bottom(joueur)[0]
        new_pos = self.move_bottom(joueur)[1]
        undo_list = self.get_undo()
        self.get_cell(last_pos[1],last_pos[0]).unset_player()
        self.__player_position[joueur] = new_pos
        self.get_cell(new_pos[1],new_pos[0]).set_player()
        if last_pos != new_pos:
            undo_list.append((last_pos,joueur))
        
    def move_right(self,joueur):
        joueur_position = self.get_player_position()[joueur]
        largeur = self.get_largeur()
        new_position = joueur_position
        if joueur != 0 and self.get_cell(new_position[1],new_position[0]).is_final() and not self.get_cell(new_position[1],new_position[0]).is_east_wall() and new_position[0] < largeur-1 and not self.get_cell(new_position[1],new_position[0]+1).got_player():
            new_position = (new_position[0]+1,new_position[1])
        while not self.get_cell(new_position[1],new_position[0]).is_east_wall() and new_position[0] < largeur-1 and not self.get_cell(new_position[1],new_position[0]+1).got_player():
            if self.get_cell(new_position[1],new_position[0]).is_final():
                break
            else:
                new_position = (new_position[0]+1,new_position[1])
        return(joueur_position,new_position)
    
    def set_right(self,joueur):
        last_pos = self.move_right(joueur)[0]
        new_pos = self.move_right(joueur)[1]
        undo_list = self.get_undo()
        self.get_cell(last_pos[1],last_pos[0]).unset_player()
        self.__player_position[joueur] = new_pos
        self.get_cell(new_pos[1],new_pos[0]).set_player()
        if last_pos != new_pos:
            undo_list.append((last_pos,joueur))
        
    def move_left(self,joueur):
        joueur_position = self.get_player_position()[joueur]
        new_position = joueur_position
        if joueur != 0 and self.get_cell(new_position[1],new_position[0]).is_final() and not self.get_cell(new_position[1],new_position[0]-1).is_east_wall() and new_position[0] > 0 and not self.get_cell(new_position[1],new_position[0]-1).got_player():
            new_position = (new_position[0]-1,new_position[1])
        while not self.get_cell(new_position[1],new_position[0]-1).is_east_wall() and new_position[0] > 0 and not self.get_cell(new_position[1],new_position[0]-1).got_player():
            if self.get_cell(new_position[1],new_position[0]).is_final():
                break
            else:
                new_position = (new_position[0]-1,new_position[1])
        return(joueur_position,new_position)
    
    def set_left(self,joueur):
        last_pos = self.move_left(joueur)[0]
        new_pos = self.move_left(joueur)[1]
        undo_list = self.get_undo()
        self.get_cell(last_pos[1],last_pos[0]).unset_player()
        self.__player_position[joueur] = new_pos
        self.get_cell(new_pos[1],new_pos[0]).set_player()
        if last_pos != new_pos:
            undo_list.append((last_pos,joueur))
        
    def is_solved(self,config):
        return self.get_cell(config[0][1],config[0][0]).is_final()

    def moves(self,p):
        l=[]
        for i in p:
            j=p.index(i)
            last_pos=self.get_player_position()[j]
            new_pos=i
            self.__player_position[j] = new_pos
            self.get_cell(new_pos[1],new_pos[0]).set_player()
            self.get_cell(last_pos[1],last_pos[0]).unset_player()
            l.append(p[:j]+[self.move_top(j)[1]]+p[j+1:])
            l.append(p[:j]+[self.move_bottom(j)[1]]+p[j+1:])
            l.append(p[:j]+[self.move_right(j)[1]]+p[j+1:])
            l.append(p[:j]+[self.move_left(j)[1]]+p[j+1:])
            self.__player_position[j] = last_pos
            self.get_cell(new_pos[1],new_pos[0]).unset_player()
            self.get_cell(last_pos[1],last_pos[0]).set_player()
        return l
    
    def solve(self,config):
        visited=dict()
        visited[str(config)]=None
        queue= Queue()
        queue.put(config)
        solved = False
        solution=None
        while not queue.empty() and not solved:
            s=queue.get()
            for elt in self.moves(s):
                for i in elt:
                    self.get_cell(i[1],i[0]).set_player()
                if not str(elt) in visited :
                    if self.is_solved(elt):
                        solve = True
                        solution = elt
                    for j in elt:
                        self.get_cell(j[1],j[0]).unset_player()
                    visited[str(elt)]=s
                    queue.put(elt)
        res = visited[str(solution)]
        l=[solution]
        while res != None:
            l.append(res)
            res = visited[str(res)]
        l.reverse()
        return l
    
    def change_player_pos(self,new_pos):
        joueur = new_pos[1]
        self.get_cell(self.get_player_position()[joueur][1],self.get_player_position()[joueur][0]).unset_player()
        self.__player_position[joueur] = new_pos[0]
        self.get_cell(self.get_player_position()[joueur][1],self.get_player_position()[joueur][0]).set_player()
        
    def undo (self):
        undo_list,redo_list,player_pos = self.get_undo(),self.get_redo(),self.get_player_position()
        if undo_list != []:
            latest_pos = undo_list.pop()
            redo_list.append((player_pos[latest_pos[1]],latest_pos[1]))
            self.change_player_pos(latest_pos)
    
    def redo (self):
        undo_list,redo_list = self.get_undo(),self.get_redo()
        if redo_list != []:
            new_pos = redo_list.pop()
            undo_list.append(new_pos)
            self.change_player_pos(new_pos)