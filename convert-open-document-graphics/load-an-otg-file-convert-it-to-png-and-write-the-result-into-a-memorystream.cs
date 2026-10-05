// HOW-TO: Convert OTG Image To PNG And Store In MemoryStream Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OtgToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    // Convert to PNG and write to MemoryStream
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, new PngOptions());
                        // Optionally, you can use the memoryStream here.
                        // For demonstration, we reset the position.
                        memoryStream.Position = 0;
                        Console.WriteLine($"Conversion to PNG completed. MemoryStream length: {memoryStream.Length} bytes.");
                    }

                    // Also save to file (optional, satisfies output path handling)
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
 * 1. When you need to read an OTG vector graphic from disk and convert it to a PNG for web display without writing intermediate files.
 * 2. When a web API must return a PNG image generated from an OTG source directly from memory to avoid disk I/O.
 * 3. When you are processing batch image conversions in a background service and want to keep the PNG data in a MemoryStream for further manipulation.
 * 4. When integrating Aspose.Imaging into a Windows application that loads user‑provided OTG files and shows a preview as PNG in a UI control.
 * 5. When you need to validate the size of a converted PNG before saving it, using the MemoryStream length to enforce size limits.
 */
