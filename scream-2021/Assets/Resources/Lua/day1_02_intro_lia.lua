if getSwitch('day1_02_intro_lia') then
    speak("Tess", "Follow me to the hall.")
    return
end

speak("Tess", "Hi. I'm Tess. Patient #2876.")
speak("Lia", "I-I'm Lia.", 'd1_lia0')
speak("Tess", "Are you doing alright?")
speak("Lia", "Just a bit nervous.", 'd1_lia0')
speak("Tess", "That's alright. You're doing fine.")
speak("Tess", "Here's your half of the room there.")
face('hero', 'EAST')
wait(.3)
face('d1_lia0', 'EAST')
wait(1)
faceTo('d1_lia0')
faceOther('d1_lia0', 'hero')
speak("Tess", "I'll clear out my old roommate's things later, sorry about that.")
speak("Lia", "So uhm, do you have a cold? Is that why you can't talk?", 'd1_lia0')
speak("Tess", "No. I'm physically able. But my brain's forgotten how.")
speak("Lia", "Is... Is that because of Neural-9?", 'd1_lia0')
speak("Tess", "N9. Yeah.")
speak("Tess", "It affects everyone differently. If you're here, you must've tested positive too, right?")
speak("Lia", "I've been N9 positive a long time, but... I don't really get the details.", 'd1_lia0')
speak("Tess", "It's not well understood how it works.")
speak("Tess", "A rare disease that degrades conscious and unconscious memory.")
speak("Tess", "Eventually fatal. No cure. Spreads via eye contact.")
speak("Lia", "I'm used to being blindfolded. Is it alright to go around here without one?", 'd1_lia0')
speak("Tess", "Ward #6 is a dedicated N9 ward.")
speak("Tess", "All patients are positive, so we can uncover our eyes here, and the doctors wear protection.")
speak("Tess", "Maybe when the researchers here find a cure, we can go free in the outside world again.")
speak("Tess", "But until then, don't expect to be able to leave the ward.")
speak("Lia", "A-alright...", 'd1_lia0')
speak("Tess", "Do you have symptoms? Forgetting things?")
speak("Lia", "No. Not yet, I guess.", 'd1_lia0')
speak("Tess", "It happens to everyone slightly differently.")
speak("Tess", "But don't worry. Everyone here is about our age, and going through the same thing. We have to stick together.")
speak("Lia", "Y-yeah...", 'd1_lia0')
speak("Tess", "Here, follow me and I can introduce you to everyone.")

setSwitch('day1_02_intro_lia', true)
setSwitch('spawn_lia', true)
play('day1_intro')
