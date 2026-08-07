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

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            // Load the DjVu document
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Retrieve original dimensions
                    int originalWidth = page.Width;
                    int originalHeight = page.Height;

                    // Define target width for scaling (example: 1024 pixels)
                    const int targetWidth = 1024;
                    // Calculate scaling factor while preserving aspect ratio
                    float scale = (float)targetWidth / originalWidth;
                    int targetHeight = (int)(originalHeight * scale);

                    // Resize the page to the new dimensions
                    page.Resize(targetWidth, targetHeight);

                    // Prepare output file path
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                    // Ensure the directory for the output file exists (already created above)
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
 * 1. When a developer needs to convert multi‑page DjVu documents into web‑ready PNG images with a consistent width, they can use this code to read each page, calculate the scaling factor, resize while preserving aspect ratio, and save the results.
 * 2. When an archival system must generate thumbnail previews of DjVu files for a document management portal, the code can load the DjVu, obtain each page’s dimensions, scale them to a target width, and output PNG thumbnails.
 * 3. When a printing workflow requires down‑sampling high‑resolution DjVu pages to a fixed pixel width before rasterizing to PNG for faster preview rendering, this snippet provides the necessary page‑by‑page resizing logic.
 * 4. When a mobile app needs to display DjVu content on devices with limited screen width, developers can employ this example to read the DjVu, compute the appropriate scale for each page, resize, and store the images as PNG for efficient loading.
 * 5. When a batch processing script must standardize the size of scanned DjVu pages for machine‑learning image analysis, the code can iterate through pages, determine original dimensions, apply a uniform target width, and save the scaled PNG files for downstream processing.
 */