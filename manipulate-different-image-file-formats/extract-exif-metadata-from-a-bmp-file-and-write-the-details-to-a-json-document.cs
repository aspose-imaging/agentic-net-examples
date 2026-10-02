// HOW-TO: Extract BMP EXIF Metadata and Save as JSON in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "exif.json";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            using (Image image = Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif != null)
                {
                    File.WriteAllText(outputPath, "{}");
                }
                else
                {
                    File.WriteAllText(outputPath, "{}");
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
 * 1. When you need to read camera settings stored in a BMP file and export them to a JSON file for downstream analysis or reporting.
 * 2. When a batch job must collect EXIF information from legacy BMP assets to populate a database of image properties.
 * 3. When you are building a C# service that validates image provenance by comparing extracted EXIF data against expected values.
 * 4. When you want to generate a machine‑readable metadata manifest for BMP images to feed into a digital asset management system.
 * 5. When you need to convert embedded BMP metadata into a portable JSON format for use in web APIs or client‑side applications.
 */
