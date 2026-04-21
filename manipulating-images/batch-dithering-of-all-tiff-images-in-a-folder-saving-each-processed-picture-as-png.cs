using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Ensure the output base directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all TIFF files (both .tif and .tiff extensions)
            var tiffFiles = Directory.GetFiles(inputFolder, "*.tif")
                .Concat(Directory.GetFiles(inputFolder, "*.tiff"));

            foreach (var inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to TiffImage to access the Dither method
                    TiffImage tiffImage = (TiffImage)image;

                    // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                    tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                    // Build the output PNG path
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                    // Ensure the output directory exists (handles subfolders if any)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image as PNG
                    tiffImage.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}