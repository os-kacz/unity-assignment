# unity-assignment

## Specification Breakdown:
### Deliverables:
 - A completed scene to client specification
 - Automated camera system
 - Systems allowing player interaction with the environment
 - Include specified particle and physics systems as gameplay features

### Movement:
 - WASD Keys (W forward, S back, A turn left, D turn right)
 - E for interaction
 - Use (1) to turn on wheel, (2) to turn off wheel
 - (3) to pivot left, (4) to pivot right

### Cameras:
 - Cameras follow and provide a good view of the actions player is required to do
 - Range of control cameras needed due to size of vehicle
 - Camera system is automated to provide user with appropriate views
 - Camera views provided give the player no direct control when changing perspective

## Passing Criteria:
### Character and Asset Control
 - Implemented a control system for an avatar used in the labs (simple rotation, forward and backward anims)
### Camera Control
 - Created a series of camera behaviours that are used to provide appropriate views throughout the level
 - Switching between cameras is automated using the motion of the avatar and player interaction
### Particles and Physics
 - One particle system has been created for the level and ttilises multiple components
 - Hierarchies are set up to allow the avatar to ride on the excavator

## Excelling Criteria:
### Character and Asset Control
 - Imported your Maya excavator with animations and appropriate controls
 - Additional animations to the avatar to provide convincing interactions and developed control systems to accomodate these
 - Move beyond simple importing of animations for assets. Other convincing behaviours are implemented because of player interactions
### Camera Control
 - Occlusion will be avoided when close to walls or passing objects
 - Appropriate transitions between cameras. Panning shots rather than jump cuts. Include variety of cinematic techniques
 - Provide cutscenes to draw player's attention to significant elements in the level
### Particles and Physics
 - A second complex, multi-component, emitter system is implemented with clear purpose
 - One of the emitter systems interacts with the environment e.g. Hitting the ground and creating another effect
 - Both particle effects are built to a high standard. Utilised a series of emitters as well as textures to creating convincing effects. Physics added to have visible and believable consequences when destroying things