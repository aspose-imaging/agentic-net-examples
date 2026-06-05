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
            // Hardcoded paths
            string inputJpegPath = @"C:\Images\input.jpg";
            string canvasHtmlPath = @"C:\Images\output.html";
            string outputJpegPath = @"C:\Images\reconverted.jpg";

            // Verify input file exists
            if (!File.Exists(inputJpegPath))
            {
                Console.Error.WriteLine($"File not found: {inputJpegPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(canvasHtmlPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputJpegPath));

            // Load the JPEG image
            using (Image jpegImage = Image.Load(inputJpegPath))
            {
                // Save as HTML5 Canvas
                var canvasOptions = new Html5CanvasOptions
                {
                    // Export a full HTML page; adjust as needed
                    FullHtmlPage = true,
                    // No vector source needed for raster JPEG
                };
                jpegImage.Save(canvasHtmlPath, canvasOptions);
            }

            // Load the generated HTML5 Canvas file
            using (Image canvasImage = Image.Load(canvasHtmlPath))
            {
                // Save back to JPEG
                var jpegOptions = new JpegOptions
                {
                    Quality = 100 // Preserve maximum quality for size comparison
                };
                canvasImage.Save(outputJpegPath, jpegOptions);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputJpegPath).Length;
            long reconvertedSize = new FileInfo(outputJpegPath).Length;

            Console.WriteLine($"Original JPEG size: {originalSize} bytes");
            Console.WriteLine($"Re‑converted JPEG size: {reconvertedSize} bytes");
            Console.WriteLine($"Size difference: {reconvertedSize - originalSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer wants to embed a JPEG photo into an HTML5 Canvas element for client‑side manipulation and later needs to re‑export it as a JPEG while verifying that the file size has not increased unexpectedly.
 * 2. When an e‑commerce platform generates product thumbnails as JPEGs, converts them to HTML5 Canvas to apply dynamic overlays in the browser, and then reconverts them to JPEG for storage, comparing sizes to ensure storage efficiency.
 * 3. When a digital asset management system needs to preview JPEG images in a web UI using HTML5 Canvas, then batch‑process them back to JPEG and check size differences to detect any quality loss.
 * 4. When a content‑creation tool allows users to edit uploaded JPEG photos on an HTML5 Canvas, then saves the edited version as JPEG and compares the original and edited file sizes to inform users about potential bandwidth impact.
 * 5. When a mobile‑first website optimizes images by converting JPEGs to HTML5 Canvas for on‑the‑fly resizing, then re‑exports them to JPEG and measures size changes to validate that the optimization pipeline maintains acceptable image weight.
 */