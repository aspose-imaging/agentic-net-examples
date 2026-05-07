using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the vector image (SVG)
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Define canvas size
                int canvasWidth = 800;
                int canvasHeight = 600;

                // Create a blank PNG canvas
                PngOptions pngOptions = new PngOptions();
                using (Image canvas = Image.Create(pngOptions, canvasWidth, canvasHeight))
                {
                    // Obtain a Graphics object for drawing
                    Graphics graphics = new Graphics(canvas);

                    // Clear the canvas with white background
                    graphics.Clear(Color.White);

                    // Apply translation and rotation transforms
                    graphics.TranslateTransform(200, 150); // move origin to (200,150)
                    graphics.RotateTransform(30);          // rotate 30 degrees around new origin

                    // Draw the vector image at the transformed origin
                    graphics.DrawImage(vectorImage, 0, 0);

                    // Save the resulting image
                    canvas.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}