using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "c:\\temp\\sample.tif";
            string outputPath = "c:\\temp\\sample.FloydSteinbergDithering1.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access Dither method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the dithered image as PNG
                tiffImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}