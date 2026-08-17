// HOW-TO: How to Add a Progress Bar While Converting PNG Files in C# (Aspose.Imaging for .NET)
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
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDir, "*.png");

            int total = pngFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string inputPath = pngFiles[i];
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_processed.png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Save with progressive PNG options
                    var pngOptions = new PngOptions
                    {
                        Progressive = true
                    };
                    image.Save(outputPath, pngOptions);
                }

                // Update simple progress bar
                Console.Write($"\rProcessed {i + 1}/{total} images");
            }

            // Move to next line after processing
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to process thousands of PNG images and show real‑time progress in a console application.
 * 2. When you want to convert standard PNGs to progressive PNGs for faster web loading using Aspose.Imaging in C#.
 * 3. When you must ensure output folders exist before saving processed images in an automated batch workflow.
 * 4. When you require a simple console feedback loop that reports the number of images processed out of the total.
 * 5. When you are building a command‑line tool that validates input files, applies image options, and writes the results to a separate directory.
 */
