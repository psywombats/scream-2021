if getSwitch('day1_06_intro_joey') then
    speak("Joey", "But if you're ever scared or sad, you can come find Connie. She'll be right here.", 'd1_joey0')
end

speak("Tess", "Hi Joey.")
speak("Joey", "Oh, hi Tess. Did you come to play with Connie?", 'd1_joey0')
speak("Tess", "Actually I have someone I want you to meet. This is Lia. She's new.")
speak("Joey", "Oh erm, hi.", 'd1_joey0')
speak("Tess", "You should tell Lia your name.")
speak("Joey", "It's Joey.", 'd1_joey0')
speak("Lia", "Hi Joey. It's nice to meet you.", 'lia_bot')
speak("Joey", "Do you want to meet Connie? She lives here too.", 'd1_joey0')
speak("Lia", "Sure.", 'lia_bot')
face('d1_joey0', 'WEST')
speak("Joey", "Connie, say hi.", 'd1_joey0')
walk('d1_connie0', 1, 'WEST')
wait(.5)
face('d1_connie0', 'EAST')
wait(.7)
face('d1_joey0', 'EAST')
speak("Joey", "..She's not good with strangers.", 'd1_joey0')
speak("Lia", "She's a... shy rabbit?", 'lia_bot')
speak("Joey", "Sure but she's friendly when she gets to know you. She's my best friend in the world.", 'd1_joey0')
speak("Joey", "You're number two Tess. Don't worry. Or maybe Nadine is. It switches. But it definitely isn't Owen.", 'd1_joey0')
speak("Joey", "Owen doesn't like Connie so he's not my friend either. Watch out for him.", 'd1_joey0')
speak("Lia", "O-okay.", 'lia_bot')
speak("Joey", "So what happened to your face?", 'd1_joey0')
speak("Tess", "Don't be rude, Joey.")
speak("Lia", "It's alright...", 'lia_bot')
speak("Lia", "Everyone knows the disease spread through eye contact, so uhm, someone attacked me.", 'lia_bot')
speak("Lia", "They found out I had Neural-9 and uhm, tried to blind me with acid. So I couldn't spread it.", 'lia_bot')
speak("Joey", "Did it work?", 'd1_joey0')
speak("Lia", "My right eye doesn't work, but, I'm used to being blindfolded. I don't mind.", 'lia_bot')
speak("Lia", "But after the attack... It was decided I'd have to come to Ward #6.", 'lia_bot')
speak("Joey", "Oh. I'm new here too.", 'd1_joey0') 
speak("Joey", "If you're ever scared or sad, you can come find Connie. She'll be right here.", 'd1_joey0')
speak("Lia", "Thanks.", 'lia_bot')

setSwitch('day1_06_intro_joey', true)
play('day1_intro')