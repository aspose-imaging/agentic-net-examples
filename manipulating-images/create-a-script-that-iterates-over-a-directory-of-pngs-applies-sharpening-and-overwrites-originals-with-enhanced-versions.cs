using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded directory containing PNG files
        string inputDirectory = "C:\\Images";

        // Ensure the directory exists (creates if missing)
        Directory.CreateDirectory(inputDirectory);

        // Get all PNG files in the directory
        string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png", SearchOption.TopDirectoryOnly);

        foreach (string inputPath in pngFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (same as input directory)
            Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

            // Load the image, apply sharpening, and overwrite the original
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Apply sharpen filter with kernel size 5 and sigma 4.0
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save back to the original file
                raster.Save(inputPath);
            }
        }
    }
}