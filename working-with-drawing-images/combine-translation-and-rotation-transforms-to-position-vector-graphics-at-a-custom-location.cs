using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

        // Load the vector image (SVG) to be drawn
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Create a PNG canvas bound to the output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);
            using (Image canvas = Image.Create(pngOptions, 800, 600))
            {
                // Initialize graphics for the canvas
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Apply translation and rotation transforms
                graphics.TranslateTransform(200, 150); // move origin to (200,150)
                graphics.RotateTransform(45);          // rotate 45 degrees around the new origin

                // Draw the vector image at the transformed origin
                graphics.DrawImage(vectorImage, 0, 0);

                // Save the canvas (output file is already bound)
                canvas.Save();
            }
        }
    }
}