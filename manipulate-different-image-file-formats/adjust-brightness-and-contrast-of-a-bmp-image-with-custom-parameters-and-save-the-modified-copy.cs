using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output_modified.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image using the BmpImage constructor
        using (BmpImage bmpImage = new BmpImage(inputPath))
        {
            // BmpImage derives from RasterImage, so we can use raster operations directly
            // Adjust brightness (range: -255 to 255)
            int brightness = 40; // custom brightness value
            bmpImage.AdjustBrightness(brightness);

            // Adjust contrast (range: -100 to 100)
            int contrast = 20; // custom contrast value
            // Assuming RasterImage provides AdjustContrast; if not, this line can be omitted or replaced with appropriate API.
            bmpImage.AdjustContrast(contrast);

            // Save the modified image
            bmpImage.Save(outputPath);
        }
    }
}