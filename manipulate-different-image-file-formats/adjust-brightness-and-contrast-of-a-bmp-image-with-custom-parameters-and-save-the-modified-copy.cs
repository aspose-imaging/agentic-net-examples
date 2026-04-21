using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image using the BmpImage constructor (lifecycle rule)
        using (BmpImage bmpImage = new BmpImage(inputPath))
        {
            // Cast to RasterImage to access brightness/contrast adjustment methods
            RasterImage raster = (RasterImage)bmpImage;

            // Custom adjustment values (within allowed ranges)
            int brightness = 50; // -255 .. 255
            int contrast = 30;   // -100 .. 100

            // Apply brightness and contrast adjustments
            raster.AdjustBrightness(brightness);
            raster.AdjustContrast(contrast);

            // Save the modified image to the output path (lifecycle rule)
            bmpImage.Save(outputPath);
        }
    }
}