using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Apply deconvolution filter to each frame
            foreach (var page in apng.Pages)
            {
                // Each page is an ApngFrame, which can be treated as a RasterImage
                RasterImage frame = (RasterImage)page;
                // Motion Wiener deconvolution filter: length=10, smooth=1.0, angle=90.0
                frame.Filter(frame.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));
            }

            // Save the processed APNG to the output file
            apng.Save(outputPath, new ApngOptions());
        }
    }
}