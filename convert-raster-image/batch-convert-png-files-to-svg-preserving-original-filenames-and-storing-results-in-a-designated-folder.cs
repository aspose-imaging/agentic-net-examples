// HOW-TO: Batch Convert PNG Images to SVG Files in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists (will also handle subfolders)
            Directory.CreateDirectory(outputFolder);

            // Get all PNG files in the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output SVG path, preserving the original filename
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare rasterization options for SVG conversion
                    var vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Save the image as SVG using the prepared options
                    image.Save(outputPath, new SvgOptions
                    {
                        VectorRasterizationOptions = vectorRasterizationOptions
                    });
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
 * 1. When you need to automatically transform a collection of PNG graphics into scalable SVG vectors for web deployment while keeping the original file names.
 * 2. When a desktop application must generate SVG assets from user‑uploaded PNGs and store them in a specific output folder.
 * 3. When a build pipeline requires converting design assets from raster PNG format to vector SVG to reduce file size and enable resolution‑independent rendering.
 * 4. When you want to migrate legacy PNG icons to SVG for responsive UI components without manually renaming each file.
 * 5. When a server‑side service processes batches of PNG screenshots and saves them as SVGs for further vector‑based analysis or editing.
 */
