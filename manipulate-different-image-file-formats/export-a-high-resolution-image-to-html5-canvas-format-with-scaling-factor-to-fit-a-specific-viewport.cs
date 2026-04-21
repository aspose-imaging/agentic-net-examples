using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\highres.svg";
        string outputPath = @"C:\Images\canvas.html";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if missing)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image (vector format such as SVG)
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options with scaling to fit the target viewport
            var rasterOptions = new SvgRasterizationOptions
            {
                // Example scaling factor; adjust as needed for your viewport
                ScaleX = 0.5f,
                ScaleY = 0.5f,
                // Optional: preserve original size as page size
                PageSize = ((SvgImage)image).Size,
                // Optional: set background color if needed
                BackgroundColor = Color.White
            };

            // Set up HTML5 Canvas export options
            var canvasOptions = new Html5CanvasOptions
            {
                // Export a full HTML page (set to false to embed only the <canvas> tag)
                FullHtmlPage = true,
                // Assign the rasterization options defined above
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as an HTML5 Canvas file
            image.Save(outputPath, canvasOptions);
        }
    }
}