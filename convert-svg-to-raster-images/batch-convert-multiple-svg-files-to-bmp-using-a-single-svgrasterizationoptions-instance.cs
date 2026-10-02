// HOW-TO: Batch Convert Multiple SVG Files to BMP with Shared Rasterization Options in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "InputSvgs";
            string outputDirectory = "OutputBmps";

            // Create a single SvgRasterizationOptions instance
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Example settings; adjust as needed
                PageWidth = 800,
                PageHeight = 600,
                BackgroundColor = Color.White
            };

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output BMP path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".bmp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG and save as BMP using the shared rasterization options
                using (Image image = Image.Load(inputPath))
                {
                    var bmpOptions = new BmpOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    image.Save(outputPath, bmpOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to generate bitmap thumbnails for a large collection of SVG icons in a C# application.
 * 2. When you want to prepare high‑resolution BMP assets from SVG designs for legacy Windows software that only supports BMP.
 * 3. When you must apply the same page size and background color to every SVG before converting them to BMP for consistent printing output.
 * 4. When an automated build pipeline has to convert all SVG diagrams in a folder to BMP files for documentation generation.
 * 5. When you are optimizing a server‑side service that processes many SVG uploads and stores them as BMP images using a single rasterization configuration.
 */
