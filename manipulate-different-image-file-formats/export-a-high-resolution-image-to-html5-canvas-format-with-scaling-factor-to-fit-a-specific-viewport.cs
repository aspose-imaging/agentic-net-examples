using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.svg";
            string outputPath = @"C:\Images\canvas.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (vector format recommended for scaling)
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with scaling factors
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Example: double the size to fit a larger viewport
                    ScaleX = 2.0f,
                    ScaleY = 2.0f,
                    // Optional: set background color for the canvas
                    BackgroundColor = Color.White
                };

                // Set up HTML5 Canvas export options
                var canvasOptions = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    FullHtmlPage = true,          // Generate a full HTML page
                    CanvasTagId = "myCanvas"      // Identifier for the canvas element
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