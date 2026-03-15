using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.ImageFilters.FilterOptions;

class MotionBlurExample
{
    static void Main()
    {
        // Path to the folder containing the image
        string dataDir = @"c:\temp\";

        // Load the source image
        using (Image image = Image.Load(dataDir + "input.png"))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Define motion blur parameters
            int kernelSize = 9;          // Size of the kernel (must be odd)
            double angleDegrees = 45.0; // Direction of the blur in degrees

            // Obtain the motion blur kernel matrix
            double[] motionKernel = ConvolutionFilter.GetBlurMotion(kernelSize, angleDegrees);

            // Create convolution filter options using the kernel
            var filterOptions = new ConvolutionFilterOptions(motionKernel);

            // Apply the motion blur filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, filterOptions);

            // Save the processed image
            rasterImage.Save(dataDir + "output.MotionBlur.png");
        }
    }
}