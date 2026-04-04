using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories (relative to current directory)
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all TIFF files in the input directory
        var tiffFiles = Directory.GetFiles(inputDirectory)
            .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                        f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase));

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
                // Cast to TiffImage to access Dither method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                // Prepare output PNG path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image as PNG
                tiffImage.Save(outputPath, new PngOptions());
            }
        }
    }
}