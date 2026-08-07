// HOW-TO: Batch Convert JPG Images to PNG in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.jpg");

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    var options = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    image.Save(outputPath, options);
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
 * 1. When you need to convert a large collection of JPEG photos to lossless PNG format for archival or further editing.
 * 2. When an automated pipeline must read JPG files from a directory, apply Aspose.Imaging processing, and output PNGs for web‑compatible transparency support.
 * 3. When a desktop application has to batch‑process user‑uploaded JPEGs and store them as PNGs to preserve image quality before applying filters.
 * 4. When migrating legacy image assets stored as JPG into a PNG‑based asset library without manual intervention.
 * 5. When generating PNG thumbnails from a folder of JPEG images as part of a reporting or documentation workflow.
 */
