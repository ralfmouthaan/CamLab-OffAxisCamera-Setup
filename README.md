# CamLab-OffAxisCamera-Setup

Program to assist with setting up a camera for off-axis holographic imaging. Allows:
- Three different cameras to be set up
- Camera parameters such as exposure and triggering to be set up
- Off-axis holography regions to be set up. i.e., the region of interest in real space and the region of interest in inverse space
- Images to be displayed of the raw captured image, the inverse space image, and the final complex fields. Single and continuous capture is available for each type of captured image
- Camera parameters to be saved to a txt file so that the set up camera can be used by other CamLab programs. An example of such a text file is included. CamLab programs need to point to all point to the same text file.

Tip 1: To set a region of interest, click-and-drag on the image.

Tip 2: If FFTW.NET throws an error, uninstall it and reinstall it using the NuGet package manager.

Tip 3: You may want to display a hologram on the SLM using CamLab-SLM-Manual-Alignment while setting up the camera.
