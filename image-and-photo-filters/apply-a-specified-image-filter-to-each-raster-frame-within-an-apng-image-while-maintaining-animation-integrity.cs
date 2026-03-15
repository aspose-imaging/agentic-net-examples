using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the existing APNG image
        using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
        {
            // Iterate through each frame and apply a Gaussian blur filter
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                ApngFrame frame = (ApngFrame)apngImage.Pages[i];

                // Create filter options (Gaussian blur with radius 5 and sigma 4.0)
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0);

                // Apply the filter to the entire frame
                frame.Filter(frame.Bounds, filterOptions);
            }

            // Save the modified APNG image preserving animation
            apngImage.Save(outputPath, new ApngOptions());
        }
    }
}