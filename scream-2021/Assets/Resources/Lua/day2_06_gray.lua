speak("Dr. Gray", "Hello Tess.", 'd2_gray3')
pathTo('d2_target2')
face('hero', 'SOUTH')
speak("Dr. Gray", "I believe you found the rabbit.", 'd2_gray3')
speak("Tess", "I did.")
speak("Tess", "But, she's dead.")
walk('d2_gray3', 1, 'NORTH')
speak("Dr. Gray", "Then please hand over the corpse.", 'd2_gray3')
speak("Tess", "She's in room 605.")
speak("Dr. Gray", "I suppose the rabbit's death was inevitable, but that doesn't make the cleanup any more enviable.", 'd2_gray3')
speak("Tess", "Connie was fine yesterday. I don't get it.")
speak("Dr. Gray", "That is the thing about animals. Their lives are often pointless and... short.", 'd2_gray3')
wait(.7)
speak("Tess", "Sorry, Dr. Gray. I wanted to ask...")
wait(.3)
speak("Tess", "Do you remember us searching for Connie yesterday?")
face('d2_gray3', 'WEST')
speak("Dr. Gray", "...", 'd2_gray3')
face('d2_gray3', 'NORTH')
speak("Dr. Gray", "I'll dispose of the body. Please try not to upset the others.", 'd2_gray3')

face('hero', 'EAST')
walk('d2_gray3', 1, 'EAST')
face('hero', 'NORTH')
pathEvent('d2_gray3', 'room_empty')
setSwitch('day2_06_gray', true)
fade('fade_long')
teleport('CommonRoom', 'd2_target2')
setSwitch('searching_nadine_appears', false)
