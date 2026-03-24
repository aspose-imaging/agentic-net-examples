using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPathThreshold = @"c:\temp\sample.ThresholdDithering4.png";
        string outputPathFloyd = @"c:\temp\sample.FloydSteinbergDithering1.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Perform Threshold Dithering with 4-bit palette
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access Dither method
            RasterImage rasterImage = (RasterImage)image;

            // Apply threshold dithering (4 bits = 16 colors)
            rasterImage.Dither(DitheringMethod.ThresholdDithering, 4);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathThreshold));

            // Save the result
            rasterImage.Save(outputPathThreshold);
        }

        // Verify input file again (optional, same file)
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Perform Floyd‑Steinberg Dithering with 1-bit palette (black & white)
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Apply Floyd‑Steinberg dithering (1 bit = 2 colors)
            rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 1);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathFloyd));

            // Save the result
            rasterImage.Save(outputPathFloyd);
        }
    }
}