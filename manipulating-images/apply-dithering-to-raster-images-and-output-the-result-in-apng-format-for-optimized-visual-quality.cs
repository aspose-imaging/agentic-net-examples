using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample_dithered.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access Dither method
            RasterImage rasterImage = (RasterImage)image;

            // Apply Floyd‑Steinberg dithering with a 4‑bit palette
            rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 4);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the dithered image as an APNG file
            rasterImage.Save(outputPath, new ApngOptions());
        }
    }
}