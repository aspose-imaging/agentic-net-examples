using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Apng; // for ApngImage and ApngFrame

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.apng";
        string outputPath = @"C:\Images\output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access frames
            ApngImage apngImage = (ApngImage)image;

            // Iterate over each frame and apply the motion Wiener filter
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Each page is an ApngFrame which derives from RasterImage
                var frame = (RasterImage)apngImage.Pages[i];

                // Apply motion Wiener filter to the whole frame
                frame.Filter(
                    frame.Bounds,
                    new MotionWienerFilterOptions(
                        size: 10,      // kernel size
                        sigma: 1.0,    // sigma value
                        angle: 90.0)); // angle in degrees
            }

            // Save the processed APNG using ApngOptions
            apngImage.Save(outputPath, new ApngOptions());
        }
    }
}