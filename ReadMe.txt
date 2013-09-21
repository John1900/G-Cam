G-CAM is a web application to build CNC GCodes for grinding a CAM 
to be used in model engines.

The user enters values for the cam geometry defining the base circle, 
flank radius and lift.  Also values for the CNC mill axis, precision,
roughing and final passes etc.  These values can be saved and restored 
from the local computer.

A cam shaft is first turned with disks slightly larger than the desired 
cams.  This is then mounted in a rotary table on a CNC mill.  
A grinding wheel (or ball nose end mill) is arranged to move towards or
away from the cam blank as it is rotated.  

The program computes various metrics and charts 
including:

- Computation of nose radius and minimum lifter diameter

- Plots lift, velocity and acceleration graphs

- Produces the GCode for download

The application is web based and browser neutral (at least I hope so!)

Developed using Visual Studio express for Web 2012 edition (free) in C#.

Run the program from the resources menu of http://tsme.ca

Toronto Society of Model Engineers.

NON-PROGRAMERS should just download CompGeometry.cs in the classes 
directory. This can be opened with Notepad and contains all the critical 
calculations.
