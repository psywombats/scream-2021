faceOther('lia_bot', 'd1_connie2')
speak("Lia", "Connie!", 'lia_bot')
faceOther('lia_bot', 'hero')
speak("Lia", "Look Tess! There she is!", 'lia_bot')
faceTo('lia_bot')
speak("Tess", "Good work.")
faceOther('lia_bot', 'd1_connie2')
faceTo('d1_connie2')
speak("Lia", "Hee, Connie. Here girl.", 'lia_bot')
wait(.7)
speak("Lia", "Aw, she looks so scared.", 'lia_bot')
faceTo('lia_bot')
faceOther('lia_bot', 'hero')
speak("Tess", "Why don't you scoop her up and bring her back to Joey? I'm sure he'll be thrilled.")
speak("Lia", "I will! I'm so glad we found her.", 'lia_bot')

fade('black')
wait(1)
fadeOutBGM(1)
wait(1)
setSwitch('day1_13_search_connie', true)
setSwitch('spawn_lia', false)
intertitle("THOUGH THE MOON MAY RISE\n\nTHE HAMMER\nHAS YET TO FALL\n\n\nNIGHT_1")
setSwitch('night', true)
setSwitch('d1_clear', true)
teleport('RoomYours', 'start')
