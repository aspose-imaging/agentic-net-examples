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

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Retrieve original dimensions
                    int originalWidth = page.Width;
                    int originalHeight = page.Height;

                    // Determine scaling factor (e.g., max dimension 1000 pixels)
                    const int maxDimension = 1000;
                    double scale = Math.Min(1.0, (double)maxDimension / Math.Max(originalWidth, originalHeight));
                    int targetWidth = (int)(originalWidth * scale);
                    int targetHeight = (int)(originalHeight * scale);

                    // Resize if scaling is needed
                    if (scale < 1.0)
                    {
                        page.Resize(targetWidth, targetHeight);
                    }

                    // Build output file path
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                    // Ensure directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
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
 * 1. When a developer needs to convert multi‑page DjVu documents into web‑friendly PNG images while ensuring each page does not exceed a maximum pixel dimension.
 * 2. When an application must generate thumbnail previews of DjVu pages for a document management system, automatically resizing large pages to fit within a 1000‑pixel limit.
 * 3. When a batch‑processing tool has to extract each page of a scanned DjVu file, preserve aspect ratio, and save the pages as PNG files for further OCR processing.
 * 4. When a digital archive requires standardizing the size of DjVu page images before uploading them to a cloud storage service, using C# and Aspose.Imaging to resize and export them.
 * 5. When a reporting service needs to display DjVu content on mobile devices, it must load the DjVu file, calculate page dimensions, downscale oversized pages, and output PNGs for responsive rendering.
 */