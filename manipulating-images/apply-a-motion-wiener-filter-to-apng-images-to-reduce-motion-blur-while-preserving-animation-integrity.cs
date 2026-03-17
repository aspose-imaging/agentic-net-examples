using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using System.Drawing;

class MotionWienerApngProcessor
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Parameters for the motion Wiener filter
        int length = 10;          // Length of the motion blur kernel
        double sigma = 1.0;       // Smoothing factor
        double angle = 90.0;      // Angle of motion blur in degrees

        // Load the APNG image using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access APNG-specific functionality
            ApngImage apng = (ApngImage)image;

            // Apply the motion Wiener filter to the entire image bounds
            // The Filter method is inherited from RasterImage and works per-frame,
            // preserving the animation frames and their timing.
            apng.Filter(apng.Bounds, new MotionWienerFilterOptions(length, sigma, angle));

            // Save the processed APNG while keeping the animation intact
            apng.Save(outputPath);
        }
    }
}