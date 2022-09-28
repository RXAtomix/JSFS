from IceWalker2 import *
from graphical_main import *
grids = ['1','2','3','4','5','6']
def main():
    ask1 = input('Choississez une map à charger (1,2,3,4,5,6)')
    if ask1 in grids:
        game = IceWalker('grid0'+ask1+'.txt')
        repl_play(game)
    else:
        main()
        
main()
