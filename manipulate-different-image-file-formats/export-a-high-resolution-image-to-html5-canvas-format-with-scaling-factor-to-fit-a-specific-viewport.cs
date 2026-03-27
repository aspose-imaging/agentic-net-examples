using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.html";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image (vector format recommended for HTML5 Canvas)
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options with scaling factors
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Example scaling to fit a specific viewport (50% of original size)
                ScaleX = 0.5f,
                ScaleY = 0.5f
            };

            // Set up HTML5 Canvas export options
            var canvasOptions = new Html5CanvasOptions
            {
                // Generate a full HTML page; set to false to embed only the canvas tag
                FullHtmlPage = true,
                // Apply the rasterization options defined above
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the image as an HTML5 Canvas file
            image.Save(outputPath, canvasOptions);
        }
    }
}