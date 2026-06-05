using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the vector image (SVG)
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Determine canvas size (use vector image dimensions)
                int canvasWidth = vectorImage.Width;
                int canvasHeight = vectorImage.Height;

                // Prepare PNG options with bound file source
                Source pngSource = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions { Source = pngSource };

                // Create a raster canvas bound to the output file
                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
                {
                    // Create a Graphics object for drawing
                    Graphics graphics = new Graphics(canvas);

                    // Define translation (e.g., move 100px right, 50px down) and rotation (e.g., 45 degrees)
                    float translateX = 100f;
                    float translateY = 50f;
                    float rotationAngle = 45f; // degrees

                    // Build transformation matrix: translate then rotate
                    Matrix transform = new Matrix();
                    transform.Translate(translateX, translateY);
                    transform.Rotate(rotationAngle);

                    // Apply the transformation to the graphics context
                    graphics.Transform = transform;

                    // Draw the vector image onto the canvas using the transformed graphics context
                    graphics.DrawImage(vectorImage, new Point(0, 0));

                    // Save the bound canvas (no need to specify path/options)
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
 * 1. When a developer needs to place an SVG company logo at a specific X/Y offset and rotate it by a given angle before rasterizing it to a PNG product label using Aspose.Imaging for .NET.
 * 2. When a developer wants to overlay a rotated SVG watermark onto a PNG‑rendered PDF page by applying translation and rotation transforms with a Matrix object.
 * 3. When a developer generates custom map markers by translating and rotating SVG icons, then saving the transformed graphics as PNG tiles for a web‑mapping application.
 * 4. When a developer creates dynamic UI badges where SVG icons are shifted and tilted based on user input, using the Graphics and Matrix classes to output the final PNG assets.
 * 5. When a developer prepares marketing banners that require SVG illustrations to be moved to a custom location and rotated to fit a predefined layout before exporting the result as a high‑quality PNG image.
 */