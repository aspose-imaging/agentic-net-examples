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
            string inputJpegPath = @"C:\temp\input.jpg";
            string canvasHtmlPath = @"C:\temp\output.html";
            string reexportJpegPath = @"C:\temp\reexport.jpg";

            // Input file existence check
            if (!File.Exists(inputJpegPath))
            {
                Console.Error.WriteLine($"File not found: {inputJpegPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(canvasHtmlPath));
            Directory.CreateDirectory(Path.GetDirectoryName(reexportJpegPath));

            // Load the original JPEG image
            using (Image jpegImage = Image.Load(inputJpegPath))
            {
                // Save as HTML5 Canvas
                var canvasOptions = new Html5CanvasOptions
                {
                    // Export a full HTML page; adjust as needed
                    FullHtmlPage = true,
                    // Required for vector rasterization (even if source is raster)
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };
                jpegImage.Save(canvasHtmlPath, canvasOptions);
            }

            // Load the generated HTML5 Canvas file
            using (Image canvasImage = Image.Load(canvasHtmlPath))
            {
                // Save back to JPEG
                var jpegOptions = new JpegOptions
                {
                    Quality = 100 // Preserve maximum quality
                };
                canvasImage.Save(reexportJpegPath, jpegOptions);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputJpegPath).Length;
            long reexportSize = new FileInfo(reexportJpegPath).Length;

            Console.WriteLine($"Original JPEG size: {originalSize} bytes");
            Console.WriteLine($"Re‑exported JPEG size: {reexportSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}