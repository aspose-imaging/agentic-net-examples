using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.tiff";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image (Aspose.Imaging supports CDR as a raster image)
        using (Image image = Image.Load(inputPath))
        {
            // Work with the raster representation
            RasterImage raster = image as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("Loaded image is not a raster image.");
                return;
            }

            // Deskew the image by normalizing its angle
            raster.NormalizeAngle();

            // Apply Gaussian blur to the entire image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as TIFF
            raster.Save(outputPath);
        }
    }
}