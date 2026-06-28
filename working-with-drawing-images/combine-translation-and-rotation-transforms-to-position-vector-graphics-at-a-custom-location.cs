using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputSvgPath = "input.svg";
            string outputPngPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));

            // Load the SVG vector image
            using (SvgImage vectorImage = (SvgImage)Image.Load(inputSvgPath))
            {
                // Determine canvas size (using the vector image dimensions)
                int canvasWidth = vectorImage.Width;
                int canvasHeight = vectorImage.Height;

                // Create a file source for the output PNG
                Source fileSource = new FileCreateSource(outputPngPath, false);

                // Configure PNG options with the file source
                PngOptions pngOptions = new PngOptions { Source = fileSource };

                // Create the raster canvas bound to the output file
                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
                {
                    // Create a Graphics instance for drawing
                    Graphics graphics = new Graphics(canvas);

                    // Apply translation (move) and rotation transforms
                    graphics.TranslateTransform(100, 50); // move 100px right, 50px down
                    graphics.RotateTransform(45);        // rotate 45 degrees clockwise

                    // Draw the vector image onto the transformed canvas
                    graphics.DrawImage(vectorImage, new Rectangle(0, 0, vectorImage.Width, vectorImage.Height));

                    // Save the bound image (no need to pass path/options)
                    canvas.Save();
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
 * 1. When generating product catalog thumbnails where an SVG logo must be placed at a specific offset and rotated to match the product angle before exporting to PNG.
 * 2. When creating dynamic map tiles that require positioning and rotating a vector road symbol at precise coordinates on a raster background.
 * 3. When designing custom UI icons that need to be shifted and angled within a fixed-size PNG button image for consistent layout across devices.
 * 4. When automating the production of printable certificates that overlay a rotated SVG seal at a designated spot on a PNG template.
 * 5. When building a batch process that adds a translated and rotated SVG watermark to a series of PNG images for brand protection.
 */