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
        string inputPath = @"C:\Images\highres.png";
        string outputPath = @"C:\Images\canvas.html";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output directory
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the high‑resolution image
            using (Image image = Image.Load(inputPath))
            {
                // Define scaling factor to fit the desired viewport (e.g., 0.5 = 50%)
                float scaleFactor = 0.5f;

                // Configure HTML5 Canvas export options
                var canvasOptions = new Html5CanvasOptions
                {
                    // Generate a full HTML page (set to false to export only the <canvas> tag)
                    FullHtmlPage = true,

                    // Set vector rasterization options with scaling
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        ScaleX = scaleFactor,
                        ScaleY = scaleFactor
                    }
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