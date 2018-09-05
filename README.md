# IrisReco
This is an application  for iris recogintion using deeplearning. The project including two parts, which the program inferface
is writen by C# and the recognition algorithm is written by Python. More using details will be updated in the future.

## Recognition Algorithm
The whole iris verification process is shown below. Different from most of computer vision tasks using deep CNNs, the input samples of iris recognition undergo several image processing steps instead of using original images as input samples. One of the major reasons is that iris images contain much interference information, such as eyelashes, pupils, and eyelid, which cannot represent iris feature information without segmentation. The normalization of the iris region is done using Daugman's rubber-sheet model to reduce the impact of pupil contraction, which ensures the scale invariance of iris samples. Here the size of input sample is 360*60 by using Daugman's normalizaiton.
![flow_chart](IrisReco/readme_image/flowchart.jpg )
