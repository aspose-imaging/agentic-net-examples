using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Cast to RasterImage for raster processing
            RasterImage rasterImage = sourceImage as RasterImage;
            if (rasterImage == null)
            {
                Console.Error.WriteLine("The loaded image is not a raster image.");
                return;
            }

            // Convert the RasterImage to a BMP image
            using (BmpImage bmpImage = new BmpImage(rasterImage))
            {
                // Save the BMP image to the output path
                bmpImage.Save(outputPath);
            }
        }
    }
}