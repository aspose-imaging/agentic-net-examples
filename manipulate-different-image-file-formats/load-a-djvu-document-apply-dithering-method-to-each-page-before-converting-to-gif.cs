using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input DjVu file and output directory
        string inputPath = "sample.djvu";
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

            // Load DjVu document
            using (Image image = Image.Load(inputPath))
            {
                DjvuImage djvuImage = (DjvuImage)image;

                // Iterate through each page
                for (int i = 0; i < djvuImage.PageCount; i++)
                {
                    // Access page
                    DjvuPage page = (DjvuPage)djvuImage.Pages[i];

                    // Apply Floyd‑Steinberg dithering with 1‑bit palette
                    page.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1, null);

                    // Prepare output path for this page
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.gif");

                    // Ensure directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the dithered page as GIF
                    page.Save(outputPath, new GifOptions());
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
 * 1. When a developer needs to convert each page of a multi‑page DjVu document into a lightweight 1‑bit GIF for web preview, they can use this code to apply Floyd‑Steinberg dithering and save the results.
 * 2. When an archival system requires black‑and‑white thumbnails of scanned DjVu files for quick indexing, the snippet demonstrates how to dither each page and export it as a GIF.
 * 3. When building an e‑learning platform that serves animated GIF slides extracted from DjVu lecture notes, this example shows how to process every page with C# and Aspose.Imaging.
 * 4. When a document‑management workflow must generate printable GIF images from DjVu pages while preserving visual detail through dithering, the code provides a ready‑to‑use solution.
 * 5. When a mobile app needs to display DjVu content on devices that only support GIF, developers can use this routine to dither each page and create compatible GIF files on the fly.
 */