using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputApngs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as APNG with default frame delay
                    image.Save(outputPath, new ApngOptions());
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
 * 1. When a developer needs to generate animated PNGs from a collection of vector icons stored as SVG files for use in web UI animations, they can use this code to batch‑convert them with Aspose.Imaging for .NET.
 * 2. When an e‑learning platform wants to replace static SVG diagrams with lightweight APNG animations that preserve transparency, the snippet provides a quick C# solution to process all files in a folder.
 * 3. When a game developer requires pre‑rendered APNG sprites from SVG assets to improve loading speed on mobile devices, this batch conversion script automates the task using Aspose’s ApngOptions.
 * 4. When a marketing team needs to create a set of animated product badges from designer‑provided SVG files without manually setting frame delays, the code handles the conversion in one pass.
 * 5. When an automated build pipeline must convert newly added SVG assets into APNG format for continuous integration testing of image rendering, the example demonstrates how to integrate the process into a C# workflow.
 */