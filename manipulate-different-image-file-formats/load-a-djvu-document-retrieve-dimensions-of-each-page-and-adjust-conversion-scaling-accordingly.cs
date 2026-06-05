using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (Directory.CreateDirectory handles null safely)
            Directory.CreateDirectory(outputDirectory);

            // Load the DjVu document from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Define maximum dimensions for scaling
                const int maxWidth = 1000;
                const int maxHeight = 1000;

                // Iterate through each page
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Retrieve original dimensions
                    int originalWidth = page.Width;
                    int originalHeight = page.Height;

                    // Compute scaling factor to fit within max dimensions while preserving aspect ratio
                    double widthScale = (double)maxWidth / originalWidth;
                    double heightScale = (double)maxHeight / originalHeight;
                    double scale = Math.Min(1.0, Math.Min(widthScale, heightScale)); // Do not upscale

                    // Determine target size
                    int targetWidth = (int)Math.Round(originalWidth * scale);
                    int targetHeight = (int)Math.Round(originalHeight * scale);

                    // Resize if scaling is needed
                    if (scale < 1.0)
                    {
                        page.Resize(targetWidth, targetHeight);
                    }

                    // Prepare output file path
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the (potentially resized) page as PNG
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
 * 1. When a developer needs to batch‑convert multi‑page DjVu documents to smaller PNG or JPEG images for web preview while preserving each page’s aspect ratio.
 * 2. When an application must generate thumbnails of each page in a DjVu file to fit within a fixed UI component size (e.g., 1000 × 1000 pixels) without upscaling small pages.
 * 3. When a document‑management system has to enforce maximum image dimensions before storing DjVu pages as separate image files to reduce storage costs.
 * 4. When a digital‑archive tool needs to read the original width and height of every DjVu page to calculate an optimal scaling factor for downstream OCR processing.
 * 5. When a C# service processes user‑uploaded DjVu files and must dynamically adjust the conversion scale so that large pages are resized to fit within email attachment size limits.
 */