from IceWalker2 import *
def repl_play (game):
    state,player_pos,final_case,compt= game.get_state(),game.get_player_position(),game.get_final_position(),0
    while state == GameState.unfinished:
        game.Str()
        ask_action = input ("Voulez vous bouger un joueur (move), quitter le jeu? (quit), undo (undo), redo(redo) ou solve(solve)")
        if ask_action == "move":
            ask_player = input ("Indiquez votre mouvement (num,drection)")
            ask_player_list = ask_player.split(',')
            if len (ask_player_list) == 2:
                if int(ask_player_list[0]) < len(player_pos):
                    if ask_player_list[-1] == 'W' or ask_player_list[-1] == 'w':
                        game.set_left(int(ask_player_list[0]))
                        compt+=1
                    elif ask_player_list[-1] == 'E' or ask_player_list[-1] == 'e':
                        game.set_right(int(ask_player_list[0]))
                        compt+=1
                    elif ask_player_list[-1] == 'N' or ask_player_list[-1] == 'n':
                        game.set_top(int(ask_player_list[0]))
                        compt+=1
                    elif ask_player_list[-1] == 'S' or ask_player_list[-1] == 's':
                        game.set_bottom(int(ask_player_list[0]))
                        compt+=1
            if player_pos[0] == final_case[0]:
                state = GameState.winning
        elif ask_action == "quit":
            state = GameState.losing
        elif ask_action == "undo":
            game.undo()
            compt-=1
        elif ask_action == "redo":
            game.redo()
            compt+=1
        elif ask_action == "solve":
            print(game.solve(game.get_player_position()))
            state = GameState.losing
    if state == GameState.losing:
        print ("You lose...")
    else:
        game.Str()
        print ("You win in "+str(compt)+" !")