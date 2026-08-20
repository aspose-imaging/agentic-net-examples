// HOW-TO: Batch Convert SVG Icons to Monochrome PNGs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories relative to the current directory
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists
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

            // Get all SVG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up rasterization options for SVG
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        // Use white background; the resulting PNG will be monochrome (grayscale)
                        BackgroundColor = Color.White,
                        // Preserve original size
                        PageSize = image.Size
                    };

                    // Configure PNG options for grayscale output
                    using (PngOptions pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.Grayscale,
                        VectorRasterizationOptions = rasterOptions
                    })
                    {
                        // Save the rasterized PNG
                        image.Save(outputPath, pngOptions);
                    }
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
 * 1. When you need to generate black‑and‑white PNG versions of a library of SVG icons for a dark‑mode UI, this code automates the batch conversion in C#.
 * 2. When a build pipeline must convert newly added SVG assets into monochrome PNGs for mobile apps that only support raster images, the script processes all files in a folder.
 * 3. When you want to prepare SVG logos for email newsletters that require PNG format with a single color to ensure consistent rendering across clients, this example handles the conversion automatically.
 * 4. When a design system requires a set of SVG symbols to be exported as PNGs with a fixed color palette for accessibility testing, the code iterates through the directory and saves the results.
 * 5. When you are integrating Aspose.Imaging into a C# tool that needs to create dark‑theme ready icons from vector sources without manual editing, this batch process provides a quick solution.
 */
