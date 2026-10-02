// HOW-TO: Load PNG Image From Templates Folder Using Aspose Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

namespace ImageLoader
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "templates/input.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    Console.WriteLine($"Image loaded: {inputPath}");
                    Console.WriteLine($"Width: {image.Width}, Height: {image.Height}");
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
 * 1. When you need to verify that a PNG template exists and read its dimensions before generating a report.
 * 2. When you want to load a user‑provided PNG logo from a predefined templates directory to overlay on other images.
 * 3. When you are building a batch process that checks each template PNG’s size to ensure consistency across assets.
 * 4. When you need to catch missing or corrupted PNG files early by attempting to load them with Aspose.Imaging.
 * 5. When you are creating a console utility that displays basic metadata of a PNG stored in a templates folder.
 */
