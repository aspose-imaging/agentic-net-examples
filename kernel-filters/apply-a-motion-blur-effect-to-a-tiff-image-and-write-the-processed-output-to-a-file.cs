using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output_motionblur.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access the Filter method
            TiffImage tiffImage = (TiffImage)image;

            // Apply a motion blur (using MotionWiener filter as an example)
            // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
            tiffImage.Filter(tiffImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image
            tiffImage.Save(outputPath);
        }
    }
}