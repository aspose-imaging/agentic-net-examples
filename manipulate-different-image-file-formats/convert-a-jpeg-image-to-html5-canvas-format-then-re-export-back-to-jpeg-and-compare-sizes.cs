using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = "input.jpg";
        string canvasPath = "canvas.html";
        string outputJpegPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist (handles cases with no directory part)
        Directory.CreateDirectory(Path.GetDirectoryName(canvasPath) ?? ".");
        Directory.CreateDirectory(Path.GetDirectoryName(outputJpegPath) ?? ".");

        // Load the original JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Save as HTML5 Canvas
            var canvasOptions = new Html5CanvasOptions
            {
                // Export a full HTML page; adjust as needed
                FullHtmlPage = true,
                // Required for vector rasterization; using default SVG options
                VectorRasterizationOptions = new SvgRasterizationOptions()
            };
            image.Save(canvasPath, canvasOptions);
        }

        // Load the generated Canvas HTML file
        using (Image canvasImage = Image.Load(canvasPath))
        {
            // Prepare JPEG save options
            var jpegOptions = new JpegOptions
            {
                Quality = 100 // Maximum quality for comparison
            };

            // Save back to JPEG
            canvasImage.Save(outputJpegPath, jpegOptions);
        }

        // Compare file sizes
        long originalSize = new FileInfo(inputPath).Length;
        long reexportedSize = new FileInfo(outputJpegPath).Length;

        Console.WriteLine($"Original JPEG size: {originalSize} bytes");
        Console.WriteLine($"Re‑exported JPEG size: {reexportedSize} bytes");
    }
}