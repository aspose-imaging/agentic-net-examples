using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "InputImages";
        string outputDirectory = "OutputImages";

        try
        {
            // Validate input directory existence
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Check if the individual file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_cleaned.png");

                // Ensure the output directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image and apply the Telea watermark removal with an ellipse mask
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    // Create an ellipse mask covering the central area of the image
                    var mask = new GraphicsPath();
                    var figure = new Figure();

                    float x = image.Width * 0.25f;
                    float y = image.Height * 0.25f;
                    float w = image.Width * 0.5f;
                    float h = image.Height * 0.5f;

                    figure.AddShape(new EllipseShape(new RectangleF(x, y, w, h)));
                    mask.AddFigure(figure);

                    var options = new TeleaWatermarkOptions(mask);
                    RasterImage result = WatermarkRemover.PaintOver(raster, options);

                    // Save the processed image
                    result.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically clean watermarks from a large collection of PNG photos by applying the same elliptical mask and Telea inpainting algorithm to each file.
 * 2. When a .NET application must prepare a batch of product images for an e‑commerce site, removing logo overlays from the central region of every PNG using Aspose.Imaging’s Telea watermark removal.
 * 3. When a photo‑editing workflow requires processing dozens of scanned PNG documents to erase stamps that occupy the middle of each page with a consistent ellipse mask.
 * 4. When a game‑asset pipeline needs to strip placeholder graphics from PNG sprites in bulk, using the Telea algorithm to fill the masked area seamlessly.
 * 5. When an automated archival script has to sanitize confidential PNG screenshots by masking and inpainting a specific central area across all files in a folder.
 */