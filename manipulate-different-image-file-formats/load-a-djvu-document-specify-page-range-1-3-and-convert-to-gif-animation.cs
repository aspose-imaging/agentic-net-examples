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
            string inputPath = @"C:\Images\sample.djvu";
            string outputPath = @"C:\Images\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Prepare GIF save options with page range 1‑3 (zero‑based indexes 0,1,2)
                    var gifOptions = new GifOptions
                    {
                        MultiPageOptions = new DjvuMultiPageOptions(new int[] { 0, 1, 2 })
                    };

                    // Save as animated GIF
                    djvuImage.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract the first three pages of a multi‑page DjVu document and create an animated GIF for preview on a website using Aspose.Imaging for .NET.
 * 2. When an application must convert scanned DjVu files into a lightweight GIF animation to embed in email newsletters or social media posts.
 * 3. When a digital archive system wants to generate a quick visual summary of a DjVu book by converting pages 1‑3 into a looping GIF for user‑friendly browsing.
 * 4. When a Windows desktop tool automates batch processing of DjVu manuals, converting selected pages into GIFs for inclusion in help documentation or tutorials.
 * 5. When a C# service processes user‑uploaded DjVu files and needs to produce a GIF animation of the initial pages for thumbnail generation or preview generation.
 */