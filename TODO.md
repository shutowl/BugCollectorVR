# Todo list

- [x] Add HDRI background

- [x] Serialize fields instead of GameObject.Find due to https://akbiggs.silvrback.com/please-stop-using-gameobject-find

- [x] write death function for bugs (so that it can be called from other places easier)

- [x] Add death animations to bugs

- [ ] Fix bug script (have to use gameobject.find??)

- [ ] add death sounds to bugs

- [x] Add Table and chair to scene

- [ ] Change Menu Fonts

- [ ] Make title screen

- [ ] add sounds to bugs

- [ ] new spawning system
  - [ ] bugs spawn in area around player, not just in specific points
    - [ ] just check for ground intersection and air above the bug
    - [ ]  bugs can spawn under rocks
    - [ ]  bugs can spawn in logs
  - [ ] probably have to change hit detection to be over a certain threshold of physics
  
- [ ] Scale bugs approximately, this should be a very slight speedup since the engine doesn't have to translate the vertices (re export?) 
  
- [x] add cloth physics to net

- [x] add sounds to net

- [ ] switch from SteamVR scripts to OpenXR (would allow building to different hardward targets)

- [ ] add meusem scene (displays are modeled, need to model room)

  