setSwitch('searching_nadine_appears', true)
playSFX('door')
wait(.1)
pathEvent('d2_nadine3', 'target_nadine1')
face('hero', 'WEST')
pathEvent('d2_nadine3', 'target_nadine2', false)
speak("Nadine", "Tess! Did you find her?", 'd2_nadine3')
face('d2_nadine3', 'EAST')
speak("Nadine", "I've been looking around here for ages but I didn't see anything. How'd you know right where to - ", 'd2_nadine3')
face('hero', 'EAST')
speak("Nadine", "Connie?", 'd2_nadine3')
card('dead_rabbit')
speak("Nadine", "Nnngh... Connie!!", 'd2_nadine3')
face('hero', 'WEST')
speak("Tess", "You have to keep it together. For Joey.")
speak("Nadine", "But... ", 'd2_nadine3')
speak("Nadine", "Nn.. the poor thing. What happened to her?", 'd2_nadine3')
speak("Tess", "I have no idea. She doesn't look like she has any broken bones or wounds or things like that.")
speak("Tess", "Except for her eyes.")
speak("Nadine", "Except for the eyes...", 'd2_nadine3')
speak("Tess", "We can't let Joey see her like this. Maybe there's a way to clean the blood off.")
speak("Nadine", "Should we find one of the doctors?", 'd2_nadine3')
speak("Tess", "I don't know. There's not much we can do on our own.")
speak("Nadine", "Poor Connie...", 'd2_nadine3')

setSwitch('day2_05_connie', true)
