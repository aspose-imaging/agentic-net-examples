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

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all PNG files in the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output SVG path preserving the original filename
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure vector rasterization options
                    var vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Save as SVG using the configured options
                    image.Save(outputPath, new SvgOptions
                    {
                        VectorRasterizationOptions = vectorRasterizationOptions
                    });
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
 * 1. When a developer needs to batch convert a folder of PNG icons into SVG vectors for responsive web design while keeping the original filenames, this C# Aspose.Imaging code automates the process.
 * 2. When a software team wants to migrate legacy PNG assets to scalable SVG format for high‑resolution displays in a Windows desktop application, the code provides a quick way to convert all files in a directory.
 * 3. When an e‑commerce platform must generate SEO‑friendly SVG product images from existing PNG photos for faster page load times, the script processes the entire catalog folder and saves the results with matching names.
 * 4. When a CI/CD pipeline requires automated conversion of PNG UI mockups to SVG for inclusion in documentation or design systems, the code can be invoked as a build step to produce the vector files in a designated output folder.
 * 5. When a developer is creating a batch image processing tool that needs to preserve original filenames while converting PNG files to SVG for printing or laser cutting, this example shows how to handle file I/O and rasterization options with Aspose.Imaging for .NET.
 */