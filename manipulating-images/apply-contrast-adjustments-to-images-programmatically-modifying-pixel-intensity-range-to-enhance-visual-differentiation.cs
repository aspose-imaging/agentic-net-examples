using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample.AdjustContrast.png";

        // Verify that the input file exists; report and exit if not
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, adjust contrast, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Most raster‑based formats derive from RasterImage, which provides AdjustContrast
            var rasterImage = image as RasterImage;
            if (rasterImage != null)
            {
                // Contrast value in the range [-100, 100]; 50 increases contrast
                rasterImage.AdjustContrast(50f);
                rasterImage.Save(outputPath);
            }
            else
            {
                // If the image type does not support AdjustContrast, inform the user
                Console.Error.WriteLine("The loaded image type does not support contrast adjustment.");
            }
        }
    }
}