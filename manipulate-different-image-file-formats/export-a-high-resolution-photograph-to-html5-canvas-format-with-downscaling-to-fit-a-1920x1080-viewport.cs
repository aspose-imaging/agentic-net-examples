using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\HighResPhoto.jpg";
            string outputPath = @"C:\Images\ExportedCanvas.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the high‑resolution photograph
            using (Image image = Image.Load(inputPath))
            {
                // Determine scaling factor to fit within 1920x1080 while preserving aspect ratio
                const int maxWidth = 1920;
                const int maxHeight = 1080;

                double widthScale = (double)maxWidth / image.Width;
                double heightScale = (double)maxHeight / image.Height;
                double scale = Math.Min(1.0, Math.Min(widthScale, heightScale)); // Do not upscale

                if (scale < 1.0)
                {
                    int newWidth = (int)(image.Width * scale);
                    int newHeight = (int)(image.Height * scale);
                    // Resize using high‑quality resampling
                    image.Resize(newWidth, newHeight, ResizeType.HighQualityResample);
                }

                // Prepare HTML5 Canvas export options
                var canvasOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = true // generate a complete HTML page
                };

                // Save the image as an HTML5 Canvas file
                image.Save(outputPath, canvasOptions);
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
 * 1. When building a web gallery that must display high‑resolution photos on standard 1080p screens without slowing down the browser, a developer can use this code to downscale the image and export it as an HTML5 Canvas page.
 * 2. When creating an online product catalog where each product image needs to be embedded directly into an HTML page for fast rendering, this snippet resizes the original JPEG and saves it as a self‑contained Canvas HTML file.
 * 3. When developing a responsive e‑learning platform that shows large lecture slides on any device, the code ensures the slides are resized to fit a 1920×1080 viewport and delivered via HTML5 Canvas for smooth zoom and pan.
 * 4. When integrating high‑resolution photography into a digital signage system that runs in a browser at 1080p resolution, the routine prepares the image by scaling it down and converting it to a Canvas HTML page to eliminate extra image requests.
 * 5. When automating the generation of printable web‑based reports that embed full‑color photos, this program resizes the source picture to the target viewport and exports it as an HTML5 Canvas document for consistent cross‑browser display.
 */