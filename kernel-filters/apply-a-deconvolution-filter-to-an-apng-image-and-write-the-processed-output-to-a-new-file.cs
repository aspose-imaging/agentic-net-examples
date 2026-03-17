using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access frames
            ApngImage apngImage = (ApngImage)image;

            // Apply a deconvolution filter to each frame
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Each page is a raster image (ApngFrame)
                var frame = (RasterImage)apngImage.Pages[i];

                // Apply Motion Wiener deconvolution filter
                frame.Filter(
                    frame.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));
            }

            // Save the processed APNG to a new file
            ApngOptions saveOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            apngImage.Save(outputPath, saveOptions);
        }
    }
}