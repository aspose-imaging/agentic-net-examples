using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base, input and output directories relative to current directory
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists; create if missing and exit
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var filePath in files)
            {
                // Process only SVG files
                if (!filePath.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Verify the input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Build output BMP file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(filePath))
                {
                    // Configure BMP options for 24-bit color depth
                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        bmpOptions.BitsPerPixel = 24;
                        // Save the image as BMP
                        image.Save(outputPath, bmpOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate 24‑bit BMP thumbnails from a collection of vector SVG icons for legacy Windows applications.
 * 2. When an e‑commerce platform must convert vendor‑supplied SVG product illustrations into BMP assets for email newsletters that only support raster images.
 * 3. When a GIS system requires batch conversion of SVG map overlays into BMP files with consistent color depth for integration with older mapping software.
 * 4. When a game studio automates the creation of BMP sprites from SVG artwork to meet the texture format requirements of a legacy game engine.
 * 5. When a document management solution needs to archive SVG diagrams as BMP files with 24‑bit color to ensure compatibility with PDF generators that embed raster images.
 */