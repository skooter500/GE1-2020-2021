# DT228/DT211/DT282/DT508 Games Engines 1 2020-2021

[![Video](http://img.youtube.com/vi/NMDupdv85FE/0.jpg)](http://www.youtube.com/watch?NMDupdv85FE)

## Resources
- [Class Facebook page](https://www.facebook.com/groups/407619519952058/)
- [Course Notes (out of date!)](https://drive.google.com/open?id=1CeMUWjCUa1Ere2fMmtLz5TCL4O136mxj)
- [Assignment](assignment.md)
- [Unity Tutorials](https://unity3d.com/learn/tutorials) 
- [GDC Vault](http://www.gdcvault.com/)
- [Game maths tutorials](http://www.wildbunny.co.uk/blog/vector-maths-a-primer-for-games-programmers/)

## Contact me
* Email: bryan.duggan@dit.ie
* Twitter: [@skooter500](http://twitter.com/skooter500)
* [My website & other ways to contact me](http://bryanduggan.org)


## Previous years courses
- 2019-2020
    - https://github.com/skooter500/GE1-2019-2020
    - https://github.com/skooter500/GE2-2019-2020
- 2018-2019
    - https://github.com/skooter500/GE1-2018-2019
    - https://github.com/skooter500/GE2-2018-2019
- 2017-2018
    - http://github.com/skooter500/GE2-2017-2018
- 2016-2017
	- http://github.com/skooter500/GAI-2017
	- https://github.com/skooter500/GE2-Supplemental-2017
	- https://github.com/skooter500/GE2-LabTest2-2017
	- https://github.com/skooter500/OrbitalRingsSolution
- 2015-2016
    - https://github.com/skooter500/gameengines2015
    - https://github.com/skooter500/BGE4Unity
- 2014-2015
    - https://github.com/skooter500/BGE
    - https://github.com/skooter500/UnitySteeringBehaviours 
- 2013-2014
    - https://github.com/skooter500/XNA-3D-Steering-Behaviours-for-Space-Ships
	
## Assessment Schedule	
- Week 5 - CA proposal & Git repo - 10%
- Week 13 - CA Submission & Demo - 40%

## Week 3 - Coroutines, colliders and triggers
## Lecture

Lets make this:

[![YouTube](http://img.youtube.com/vi/HJP7AO8pCyM/0.jpg)](http://www.youtube.com/watch?v=HJP7AO8pCyM)

Clone the repo for the course and make sure you start from the master branch. Create a branch for todays solution (call it lab4)

What is happening:

- The green tank is the player. The blue tanks are the "enemies"
- Enemies spawn at a rate of 1 enemy per second
- Enemies fall from the sky and land on the ground
- There are a maximum of 5 enemies at any time
- After 4 seconds, it sinks into the ground. You can disable the collider on the tank and set drag to be 1
- After seven seconds, it gets removed from the scene

Advanced!

- When the player hits an enemy it "explodes" (all the parts break apart)
- To implement this you will have to do a few things:
- Iterate over all the child transforms to get access to the turret using:

    ```foreach (Transform t in this.GetComponentsInChildren<Transform>())
    ```
- You could also use ```transform.getChild(0)```
- Add a rigidbody to the turret
- Set the useGravity and isKinematic fields on the rigidbody appropriately
- Add a random velocity 


## Lab

Your task today is to recreate this system from Infinite Forms:

[![YouTube](http://img.youtube.com/vi/wvu5DuJydKY/0.jpg)](http://www.youtube.com/watch?v=wvu5DuJydKY)

Clone the repo for the course and make sure you start from the master branch. Create a branch for todays solution (call it lab3)

Open up the lab2 scene. There is the coloured tank following it's circular path (solution from last week). We are going to add a control orb to the red tank so that the player can enter the orb and take control of the red tank.

- Use the dode and attach it at an appropriate position on the red tank
- Add the TankController script to the coloured tank and set it to be disabled
- Make a script called RotateMe that performs a local rotation and attach it to the orb so that the orb spins by itself
- Add a sphere collider to the orb and set the isTrigger flag to be true
- Add a script called OrbController to the orb and add methods for OnTriggerEnter and OnTriggerStay. OnTriggerEnter gets called on the script whenever the attached collider overlaps with another collider. OnTriggerStay gets called once per frame so long as the collider is still overlapping.
- In OnTriggerEnter you need to:
    - Check you are colliding with the player
    - If so, disable the FPS Controller on the player and enable the TankController script on the tank
    - Disable the EnemyTankController on the Enemy Tank
    - Disable the RotateMe script on the orb
- In OnTriggetStay you need to:    
    - Check you are colliding with the player
    - Lerp the camera position and slerp the camera rotation
    - Check for the space key, if pressed this frame:
        - Disable the TankController on the tank
        - Enable the EnemyTankController
        - Enable the Tank controller
        - Enable the RotateMe script

I may have left out some steps, but you can figure out the rest yourself

## Week 2 - Tank game, trigonometry & vectors
- [Slides](https://drive.google.com/file/d/14pWZNf2Z-FX096wCLHt9t6tLorS323-k/view?usp=sharing)
- [Trigonometry problem set](https://1.cdn.edl.io/IDqRlI8C9dRkoqehbbdHBrcGT6m87gkCQuMKTkp0U7JvHvuG.pdf)

## Lab
### Learning Outcomes
- Build a simple agent with perception
- Develop computation thinking
- Use trigonometry
- Use vectors
- Use the Unity API
- Practice C#

### Instructions

Today you will be making this:

[![YouTube](http://img.youtube.com/vi/kC_W1WBB7uY/0.jpg)](http://www.youtube.com/watch?v=kC_W1WBB7uY)

What is happening:
- The red tank has a script attached that has radius and numWaypoints fields that control the generation of waypoints in a circle around it. It draws sphere gizmos so you can see where the waypoints will be.
- The red tank will follow the waypoints starting at the 0th one and looping back when it reaches the last waypoint.
- The red tank prints the messages using the Unity GUI system to indicate:
    - Whether the blue tank is in front or behind
    - Whether the front tank is inside a 45 degree FOV
    - Use the [Unity reference](unityref.md) to figure out what API's to call!


## Week 1 - Introduction
## Lecture
- [Slides](https://drive.google.com/file/d/14pWZNf2Z-FX096wCLHt9t6tLorS323-k/view?usp=sharing)
- [Trigonometry Problem Set](https://1.cdn.edl.io/IDqRlI8C9dRkoqehbbdHBrcGT6m87gkCQuMKTkp0U7JvHvuG.pdf)

### Learning Outcomes
- Install Unity & git for Windows
- Sign up for the class Facebook page
- Find the Unity tutorials

### Instructions
- Sign up for the [class Facebook page](https://www.facebook.com/groups/2460751797558448)
- Install Unity
- Fork the repository for the course and clone it
- Check out the [Unity tutorial videos](https://unity3d.com/learn/tutorials)
