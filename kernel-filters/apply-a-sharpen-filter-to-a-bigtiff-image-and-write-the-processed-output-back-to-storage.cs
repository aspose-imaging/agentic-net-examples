using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BigTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to BigTiffImage
            BigTiffImage bigTiff = image as BigTiffImage;
            if (bigTiff == null)
            {
                Console.Error.WriteLine("Loaded image is not a BigTIFF image.");
                return;
            }

            // Apply sharpen filter to the whole image
            bigTiff.Filter(bigTiff.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image
            bigTiff.Save(outputPath);
        }
    }
}