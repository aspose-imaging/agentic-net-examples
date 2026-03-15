using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class ApplyFilterToApng
{
    static void Main()
    {
        // Paths to the source APNG and the result file
        string sourcePath = "input.apng";
        string resultPath = "output.apng";

        // Load the APNG image
        using (Image image = Image.Load(sourcePath))
        {
            // Cast to ApngImage to access animation frames
            ApngImage apng = (ApngImage)image;

            // Define the filter you want to apply (example: Gaussian blur)
            var filterOptions = new GaussianBlurFilterOptions(5, 4.0);

            // Apply the filter to every frame in the animation
            foreach (ApngFrame frame in apng.Pages)
            {
                // Apply filter to the whole frame rectangle
                frame.Filter(frame.Bounds, filterOptions);
            }

            // Save the modified APNG (using default APNG options)
            apng.Save(resultPath, new ApngOptions());
        }
    }
}