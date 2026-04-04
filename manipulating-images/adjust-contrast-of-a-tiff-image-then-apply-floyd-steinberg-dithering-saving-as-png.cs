using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access TIFF‑specific methods
            TiffImage tiffImage = (TiffImage)image;

            // Adjust contrast (value in range [-100, 100])
            tiffImage.AdjustContrast(30f);

            // Apply Floyd‑Steinberg dithering with a 1‑bit palette
            tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

            // Save the processed image as PNG
            tiffImage.Save(outputPath, new PngOptions());
        }
    }
}