using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample.AdjustContrast.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // If the loaded image is a raster image, adjust its contrast directly
            if (image is RasterImage rasterImage)
            {
                // Contrast value must be in the range [-100, 100]
                rasterImage.AdjustContrast(50f);
                rasterImage.Save(outputPath);
            }
            else
            {
                // For non‑raster formats, apply a generic save with PNG options
                image.Save(outputPath, new PngOptions());
            }
        }
    }
}