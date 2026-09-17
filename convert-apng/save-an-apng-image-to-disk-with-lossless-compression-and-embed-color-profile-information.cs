// HOW-TO: Save APNG Image With Lossless Compression And Color Profile In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.apng";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var options = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, options);
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
 * 1. When you need to preserve the original animation frames and exact colors while converting or re‑saving an APNG for web delivery using C#.
 * 2. When a graphics pipeline must embed an ICC color profile into an APNG to ensure consistent color rendering across browsers and devices.
 * 3. When automating a batch process that reads existing APNG files, applies lossless compression, and writes them to a new location without quality loss.
 * 4. When integrating Aspose.Imaging into a .NET application to validate that an uploaded APNG meets lossless and color‑profile requirements before storage.
 * 5. When creating a server‑side service that receives APNG uploads, re‑encodes them with lossless settings, and saves them to a file system for later use.
 */
