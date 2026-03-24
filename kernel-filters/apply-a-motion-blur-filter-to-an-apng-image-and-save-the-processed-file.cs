using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

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
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage for frame access
            ApngImage apng = (ApngImage)image;

            // Apply motion Wiener filter to each frame
            foreach (var page in apng.Pages)
            {
                // Each page is an ApngFrame, which can be treated as RasterImage
                var frame = (RasterImage)page;
                frame.Filter(frame.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));
            }

            // Save the processed APNG
            apng.Save(outputPath, new ApngOptions());
        }
    }
}