using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\result.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            File.Copy(inputPath, outputPath, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to verify that a source JPEG image exists before copying it to a designated output folder as part of an automated image preparation workflow.
 * 2. When building a C# console utility that creates the necessary output directory structure and safely copies raster files to ensure downstream processing steps have the required assets.
 * 3. When implementing error‑resilient file handling in a batch image conversion pipeline, so missing input files are reported and the process continues without crashing.
 * 4. When setting up a simple pre‑processing step that duplicates original photos into a separate folder for backup before applying further transformations such as resizing or filtering.
 * 5. When integrating Aspose.Imaging into a larger application and needing a quick way to move sample images into the project’s output directory for testing or demonstration purposes.
 */