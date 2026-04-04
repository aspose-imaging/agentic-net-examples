using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.tif";
        string outputPath = @"c:\temp\sample.FloydSteinbergDithering1.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image, apply Floyd‑Steinberg dithering, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            TiffImage tiffImage = (TiffImage)image;
            tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);
            tiffImage.Save(outputPath, new PngOptions());
        }
    }
}