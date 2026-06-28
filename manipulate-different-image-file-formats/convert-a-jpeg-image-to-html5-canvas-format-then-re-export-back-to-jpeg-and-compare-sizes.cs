using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = @"C:\temp\input.jpg";
            string htmlPath = @"C:\temp\output.html";
            string outputJpegPath = @"C:\temp\reoutput.jpg";

            // Input validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(htmlPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputJpegPath));

            // Load the original JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Save as HTML5 Canvas
                var htmlOptions = new Html5CanvasOptions
                {
                    // Generate a full HTML page
                    FullHtmlPage = true,
                    // Required for vector rasterization when loading from vector sources
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };
                image.Save(htmlPath, htmlOptions);
            }

            // Load the generated HTML5 Canvas file
            using (Image canvasImage = Image.Load(htmlPath))
            {
                // Save back to JPEG
                var jpegOptions = new JpegOptions
                {
                    Quality = 100 // Preserve maximum quality
                };
                canvasImage.Save(outputJpegPath, jpegOptions);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long reexportedSize = new FileInfo(outputJpegPath).Length;

            Console.WriteLine($"Original JPEG size: {originalSize} bytes");
            Console.WriteLine($"Re‑exported JPEG size: {reexportedSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to embed a JPEG photo into a web page as an HTML5 Canvas element for dynamic manipulation while preserving the original quality.
 * 2. When a developer wants to create a reversible workflow that converts a JPEG to an HTML5 Canvas file and back to JPEG to verify that no significant size increase occurs after processing.
 * 3. When a developer is building an automated image pipeline that validates that converting images to HTML5 Canvas for client‑side rendering does not inflate storage requirements.
 * 4. When a developer must generate a self‑contained HTML page from a JPEG for offline viewing and later re‑export it to JPEG for archival purposes.
 * 5. When a developer is testing Aspose.Imaging’s support for loading and saving HTML5 Canvas files in a C# application by comparing the byte size of the original and re‑exported JPEG images.
 */