// HOW-TO: Batch Convert CorelDRAW CDR Files to PNG with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchCdrToPng
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = @"C:\InputCdr";
                string outputDirectory = @"C:\OutputPng";

                // Ensure the base output directory exists
                Directory.CreateDirectory(outputDirectory);

                string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr", SearchOption.TopDirectoryOnly);
                foreach (string inputPath in cdrFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        var options = new PngOptions();
                        image.Save(outputPath, options);
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
}

/*
 * Real-World Use Cases:
 * 1. When a designer needs to generate web‑ready PNG previews for dozens of CorelDRAW (.cdr) assets stored in a folder.
 * 2. When an automated build pipeline must convert newly added CDR files to PNG for inclusion in documentation or reports.
 * 3. When a migration script has to replace legacy CDR graphics with PNG images across a legacy file system without manual intervention.
 * 4. When a server‑side service processes user‑uploaded CDR files and returns PNG thumbnails for display in a web gallery.
 * 5. When a batch job must archive a collection of CDR drawings as lossless PNGs while preserving the original filenames.
 */
