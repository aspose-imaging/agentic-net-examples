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
        string inputPath = @"C:\Images\input.jpg";
        string htmlPath = @"C:\Images\canvas.html";
        string outputJpegPath = @"C:\Images\output.jpg";

        // Verify input file exists
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
                // Generate a full HTML page (optional)
                FullHtmlPage = true,
                // Required for vector rasterization when source is vector; for raster images it can be null
                VectorRasterizationOptions = null
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
}