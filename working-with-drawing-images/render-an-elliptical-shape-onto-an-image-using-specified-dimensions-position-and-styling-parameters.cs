using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the existing image
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Define ellipse position and size
            float x = 100f;      // X-coordinate of upper‑left corner
            float y = 80f;       // Y-coordinate of upper‑left corner
            float width = 300f;  // Width of the bounding rectangle
            float height = 200f; // Height of the bounding rectangle
            RectangleF ellipseRect = new RectangleF(x, y, width, height);

            // Create a pen for the ellipse outline
            Pen outlinePen = new Pen(Aspose.Imaging.Color.Blue, 5);

            // Create a solid brush for filling the ellipse
            SolidBrush fillBrush = new SolidBrush
            {
                Color = Aspose.Imaging.Color.Red,
                Opacity = 100 // Fully opaque (0‑100)
            };

            // Fill the interior of the ellipse
            graphics.FillEllipse(fillBrush, ellipseRect);

            // Draw the ellipse outline
            graphics.DrawEllipse(outlinePen, ellipseRect);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the modified image
            image.Save(outputPath);
        }
    }
}