// HOW-TO: Convert DjVu Document Pages to Animated GIFs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Iterate through each page and save as GIF
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page{djvuPage.PageNumber}.gif");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save page as GIF with default options
                    djvuPage.Save(outputPath, new GifOptions());
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
 * 1. When you need to extract each page of a DjVu file and create separate GIF images for web preview.
 * 2. When you want to generate animated GIFs from a multi‑page DjVu document for inclusion in a slideshow.
 * 3. When a batch process must convert scanned DjVu archives into lightweight GIF files for mobile devices.
 * 4. When an application must programmatically read a DjVu stream and save each page as a GIF without manual intervention.
 * 5. When you are building a document‑conversion service that supports DjVu input and GIF output using Aspose.Imaging in C#.
 */
