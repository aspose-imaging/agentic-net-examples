using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_no_bg.cdr";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the CDR file as a vector image
            using (VectorImage vectorImage = Image.Load(inputPath) as VectorImage)
            {
                if (vectorImage == null)
                {
                    Console.Error.WriteLine("Failed to load the CDR file as a vector image.");
                    return;
                }

                // Remove the background (default settings)
                vectorImage.RemoveBackground();

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the result
                vectorImage.Save(outputPath);
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
 * 1. When a designer needs to automatically strip the solid background from a CorelDRAW (CDR) illustration so the remaining foreground objects can be placed on a different canvas without manual editing.
 * 2. When an e‑commerce platform wants to generate product thumbnails from CDR files where the product color matches the original background, requiring programmatic background removal using Aspose.Imaging for .NET.
 * 3. When a marketing automation script must batch‑process client‑provided CDR logos that share the same color as the page background, and save them as background‑free files for use in promotional materials.
 * 4. When a document conversion service needs to prepare CDR artwork for PDF or PNG export by first removing the background layer to avoid unwanted color artifacts.
 * 5. When a desktop application integrates C# image processing to clean up scanned vector graphics stored as CDR files, ensuring that foreground elements remain intact even when they are the same hue as the background.
 */