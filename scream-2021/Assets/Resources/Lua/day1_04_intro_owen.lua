if getSwitch('day1_04_intro_owen') then
    speak("Owen", "If you two could leave now, I'm getting tired.", 'd1_owen0')
    return
end

speak("Owen", "Oh. Tess. I was hoping I'd run into you. We need to - ", 'd1_owen0')
speak("Owen", "Who's this?", 'd1_owen0')
speak("Tess", "This is Lia. She'll be my new roommate.", 'd1_owen0')
speak("Lia", "H-hello.", 'lia_bot')
speak("Owen", "Owen. Great to meet you. I'm thrilled. Just stoked.", 'd1_owen0')
speak("Tess", "Don't be mean.")
speak("Owen", "If you've got a new roommate, that means they're giving up on Cecily.", 'd1_owen0')
speak("Tess", "Not necessarily. She could still come back from... wherever she went.")
speak("Owen", "But the doctors don't think it's likely. And it's clear they're not telling us the whole truth about her.", 'd1_owen0')
faceTo('lia_bot')
speak("Tess", "Sorry, Lia. Cecily was my old roommate.")
speak("Lia", "Then she um... She died?", 'lia_bot')
speak("Owen", "She was only 18. N9 shouldn't have been fatal to her for another few years.", 'd1_owen0')
speak("Owen", "Cecily has to be alive, but no one will tell us exactly where she's gone.", 'd1_owen0')
speak("Owen", "...I should apologize, Lia. You obviously don't care, but it's all I can think about.", 'd1_owen0')
speak("Lia", "It's fine.", 'lia_bot')
speak("Owen", "Well, welcome to Ward #6.", 'd1_owen0')
speak("Owen", "I'm sincerely saddened that you had to come here, but none of us have any choice.", 'd1_owen0')
speak("Owen", "If you want some advice, keep your ears open, and don't take everything the doctors say at face value.", 'd1_owen0')
speak("Owen", "I've been here a while now, so if you've got any questions, you know where to find me.", 'd1_owen0')
speak("Lia", "Um, could I ask a question?", 'lia_bot')
speak("Owen", "If it's one I can answer.", 'd1_owen0')
speak("Lia", "You play the piano?", 'lia_bot')
speak("Owen", "I won the Ettole Internationale at 14, and I was runner-up for the Brahms prize the year before that.", 'd1_owen0')
speak("Lia", "I love music. Maybe some time I could listen - ", 'lia_bot')
speak("Owen", "Not happening.", 'd1_owen0')
speak("Owen", "If you two could leave now, I'm getting tired.", 'd1_owen0')
speak("Lia", "S-sorry...", 'lia_bot')

wait(.5)
teleport('HallA', 'd1_target2')
face('hero', 'WEST')
spawnFollower('lia_bot', 'd1_target3')
face('lia_bot', 'EAST')
wait(.5)

speak("Tess", "Don't worry about Owen. He can be a bit touchy but he's an okay guy.")
speak("Lia", "I hope I didn't make him mad?", 'lia_bot')
speak("Tess", "He's a huge nerd for classical music, but don't bring up his playing.")
speak("Tess", "It isn't what it used to be.")
speak("Lia", "N9?", 'lia_bot')
speak("Tess", "N9.")

setSwitch('day1_04_intro_owen', true)
play('day1_intro')
