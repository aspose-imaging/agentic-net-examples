using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
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

            // Apply a horizontal motion blur using MotionWienerFilterOptions
            // Length = 10, Smooth = 1.0, Angle = 0 (horizontal)
            var motionOptions = new MotionWienerFilterOptions(10, 1.0, 0.0);
            tiffImage.Filter(tiffImage.Bounds, motionOptions);

            // Save the result as PNG
            tiffImage.Save(outputPath, new PngOptions());
        }
    }
}