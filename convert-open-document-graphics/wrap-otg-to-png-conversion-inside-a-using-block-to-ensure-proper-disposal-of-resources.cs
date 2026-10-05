// HOW-TO: Convert OTG Image to PNG with Proper Resource Disposal in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OTGToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output/output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert legacy OTG design files to web‑friendly PNGs in a .NET batch process while ensuring memory is released promptly.
 * 2. When building an automated image pipeline that reads OTG assets from a folder and outputs PNG thumbnails without leaking unmanaged resources.
 * 3. When integrating Aspose.Imaging into a C# service that receives OTG uploads and must store them as PNGs for downstream reporting.
 * 4. When migrating a desktop application to .NET Core and want to safely handle large OTG files by wrapping the Image object in a using statement.
 * 5. When creating a command‑line utility that validates the existence of an OTG file, creates the output directory, and saves a PNG while handling exceptions gracefully.
 */
