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
            string htmlPath = @"C:\Images\output.html";
            string outputJpegPath = @"C:\Images\reconverted.jpg";

            // Verify input JPEG exists
            if (!File.Exists(inputJpegPath))
            {
                Console.Error.WriteLine($"File not found: {inputJpegPath}");
                return;
            }

            // Load the JPEG image
            using (Image image = Image.Load(inputJpegPath))
            {
                // Ensure directory for HTML output exists
                Directory.CreateDirectory(Path.GetDirectoryName(htmlPath));

                // Save as HTML5 Canvas
                var htmlOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = true,
                    CanvasTagId = "canvas1"
                };
                image.Save(htmlPath, htmlOptions);
            }

            // Verify HTML file exists before loading
            if (!File.Exists(htmlPath))
            {
                Console.Error.WriteLine($"File not found: {htmlPath}");
                return;
            }

            // Load the HTML5 Canvas file back as an image
            using (Image canvasImage = Image.Load(htmlPath))
            {
                // Ensure directory for JPEG output exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputJpegPath));

                // Save back to JPEG
                var jpegOptions = new JpegOptions
                {
                    Quality = 100
                };
                canvasImage.Save(outputJpegPath, jpegOptions);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputJpegPath).Length;
            long reconvertedSize = new FileInfo(outputJpegPath).Length;
            Console.WriteLine($"Original JPEG size: {originalSize} bytes");
            Console.WriteLine($"Reconverted JPEG size: {reconvertedSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}