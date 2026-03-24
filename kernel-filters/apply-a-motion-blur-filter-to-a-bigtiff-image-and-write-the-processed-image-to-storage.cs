using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bigtiff";
        string outputPath = @"C:\Images\output.bigtiff";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BigTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to BigTiffImage to access TIFF-specific methods
            var bigTiff = (BigTiffImage)image;

            // Apply a motion Wiener filter to the entire image
            // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
            bigTiff.Filter(bigTiff.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image
            bigTiff.Save(outputPath);
        }
    }
}