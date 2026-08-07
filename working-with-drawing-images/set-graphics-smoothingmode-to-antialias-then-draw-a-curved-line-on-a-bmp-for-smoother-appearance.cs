using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.bmp";   // not used in this example but shown for rule compliance
        string outputPath = @"C:\Temp\output.bmp";

        try
        {
            // Input file existence check (rule compliance)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (rule compliance)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new BMP image (500x500)
            using (Image image = Image.Create(new BmpOptions(), 500, 500))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Set smoothing mode to AntiAlias for smoother curves
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Define points for the curved line
                Point[] curvePoints = new Point[]
                {
                    new Point(50, 400),
                    new Point(150, 100),
                    new Point(250, 300),
                    new Point(350, 150),
                    new Point(450, 400)
                };

                // Draw the curved line using a black pen of width 2
                graphics.DrawCurve(new Pen(Color.Black, 2), curvePoints);

                // Save the image to the specified output path
                image.Save(outputPath);
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
 * 1. When generating a BMP diagram that includes smooth curved lines, such as a flowchart or schematic, a developer can set Graphics.SmoothingMode to AntiAlias and use DrawCurve to improve visual quality.
 * 2. When creating thumbnail previews of vector‑like drawings in a .NET application, using Aspose.Imaging to render the curves with anti‑aliasing ensures the output BMP looks crisp on low‑resolution displays.
 * 3. When exporting custom signature or handwriting strokes to a BMP file, enabling AntiAlias smoothing prevents jagged edges and produces a professional‑grade image.
 * 4. When building a game asset pipeline that converts procedural curve data into BMP textures, applying SmoothingMode.AntiAlias before drawing the curve reduces pixelation.
 * 5. When automating the generation of printable charts or graphs in C# and saving them as BMP files, setting the smoothing mode to AntiAlias guarantees smoother lines for high‑quality print output.
 */