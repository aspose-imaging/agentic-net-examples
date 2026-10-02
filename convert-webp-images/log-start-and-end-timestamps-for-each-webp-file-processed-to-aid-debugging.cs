// HOW-TO: Log Processing Times for WebP Images While Converting in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            string[] webpFiles = Directory.GetFiles(inputFolder, "*.webp");
            foreach (string inputPath in webpFiles)
            {
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName);

                Console.WriteLine($"Processing {fileName} started at {DateTime.Now:O}");

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath);
                }

                Console.WriteLine($"Processing {fileName} finished at {DateTime.Now:O}");
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
 * 1. When you need to audit how long each WebP file takes to load and save during a batch conversion using Aspose.Imaging in a .NET console app.
 * 2. When debugging performance bottlenecks in an image processing pipeline that handles multiple WebP files and you want start‑and‑end timestamps for each operation.
 * 3. When you want a simple console log that records the exact timestamp of when each WebP image processing begins and finishes to verify processing order.
 * 4. When integrating Aspose.Imaging into a scheduled server job and you must record timestamps for compliance or monitoring of WebP image handling.
 * 5. When creating a script to copy WebP images to another folder while tracking the processing duration of each file for reporting or optimization purposes.
 */
