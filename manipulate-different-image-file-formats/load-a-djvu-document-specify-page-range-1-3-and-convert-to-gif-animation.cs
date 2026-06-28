using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.djvu";
            string outputPath = @"C:\Temp\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure GIF options to export pages 1‑3 (zero‑based indexes 0,1,2)
                var gifOptions = new GifOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(new int[] { 0, 1, 2 })
                };

                // Save as animated GIF
                djvuImage.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract the first three pages of a DjVu document and embed them as an animated GIF for a web‑page preview using Aspose.Imaging in C#.
 * 2. When an application must convert a multi‑page DjVu file into a lightweight GIF animation to attach to an email or instant‑message without requiring a DjVu viewer.
 * 3. When a digital archive system wants to generate a quick animated thumbnail of pages 1‑3 of a DjVu manuscript for catalog browsing in a .NET environment.
 * 4. When a mobile app requires converting selected DjVu slides into an animated GIF so users can view them offline on devices that only support GIF playback.
 * 5. When a reporting tool needs to transform pages 1‑3 of a scanned DjVu report into an animated GIF for inclusion in a PDF or PowerPoint presentation.
 */