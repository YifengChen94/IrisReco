# IrisReco
This is an application  for iris recogintion using deeplearning. The project including two parts, which the program inferface
is writen by C# and the recognition algorithm is written by Python. More using details will be updated in the future.

## Recognition Algorithm
The whole iris verification process is shown below. Different from most of computer vision tasks using deep CNNs, the input samples of iris recognition undergo several image processing steps instead of using original images as input samples. One of the major reasons is that iris images contain much interference information, such as eyelashes, pupils, and eyelid, which cannot represent iris feature information without segmentation. The normalization of the iris region is done using Daugman's rubber-sheet model to reduce the impact of pupil contraction, which ensures the scale invariance of iris samples. Here the size of input sample is 360*60 by using Daugman's normalizaiton.
![flow_chart](https://github.com/YifengChen94/IrisReco/blob/master/readme_image/flowchart.jpg)

### Image Processing
As it can be shown in Figure \ref{image}, the image processing contains the following major steps: (1) Remove the reflection points in iris image by using Fast Matching Algorithm (FMM) inpainting. (2) Detect the inner and outer edges of the iris based on the Hough operator. (3) The annular region of the iris is transformed to rectangular iris images, which is called iris normalization. 
![image](https://github.com/YifengChen94/IrisReco/blob/master/readme_image/image.jpg)

### Experiments results
Here are some result images during recognition. I chose CASIA-IrisV4 as the training set of the model and randomly generated positive pairs (same class) and negative pairs (different classes) for testing.
![vector](https://github.com/YifengChen94/IrisReco/blob/master/readme_image/vector.jpg)
Examples of the learned 128-dimensional DeepID. The left column shows three test pairs in CASIA. The first two pairs are of the same identity, the third one is of different identities. The corresponding features extracted from each patch are shown in the right. The features are in one dimension. We rearrange them as 4*32 for the convenience of illustration. The brighter areas indicate higher values.

![hist](https://github.com/YifengChen94/IrisReco/blob/master/readme_image/hist.jpg)
The second image shows the cosine similarity distributions of both positive pairs and negative pairs. As the results show, the recognition algorithm used in the program can minimize intra-class variance and maximize inter-class variance, which achieve significant performance on the benchmark experiments.
