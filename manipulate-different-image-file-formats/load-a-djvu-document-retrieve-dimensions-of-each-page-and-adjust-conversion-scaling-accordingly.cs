// HOW-TO: Resize DjVu Pages to Fixed Width and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Target width for scaling each page
                int targetWidth = 1240;

                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Retrieve original dimensions
                    int originalWidth = page.Width;
                    int originalHeight = page.Height;

                    // Calculate scaling factor and target height while preserving aspect ratio
                    double scale = (double)targetWidth / originalWidth;
                    int targetHeight = (int)(originalHeight * scale);

                    // Resize the page
                    page.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

                    // Prepare output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the resized page as PNG
                    page.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert each page of a multi‑page DjVu document into uniformly sized PNG images for web thumbnails.
 * 2. When you must preserve the original aspect ratio while scaling DjVu pages to a specific pixel width for consistent layout in a mobile app.
 * 3. When processing scanned books stored as DjVu, you want to extract pages, resize them, and store them in a folder structure for further OCR processing.
 * 4. When generating preview images from large DjVu files, you need to read the document, determine each page’s dimensions, and produce scaled‑down PNGs to reduce bandwidth.
 * 5. When automating a batch job that reads DjVu files from a directory, resizes pages to a target width, and saves the results as PNGs for archival or publishing pipelines.
 */
