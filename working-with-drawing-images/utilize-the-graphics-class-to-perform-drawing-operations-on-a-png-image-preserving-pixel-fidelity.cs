using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Optional: clear the canvas with white background
            graphics.Clear(Color.White);

            // Draw a red line
            graphics.DrawLine(new Pen(Color.Red, 3), new Point(50, 50), new Point(450, 50));

            // Draw a blue rectangle
            graphics.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle(100, 100, 300, 200));

            // Draw a green ellipse
            graphics.DrawEllipse(new Pen(Color.Green, 2), new Rectangle(150, 150, 200, 100));

            // Fill a rectangle with a solid yellow brush
            using (SolidBrush fillBrush = new SolidBrush(Color.Yellow))
            {
                graphics.FillRectangle(fillBrush, new Rectangle(120, 120, 100, 80));
            }

            // Draw a text string using a black brush and Arial font
            Font font = new Font("Arial", 24);
            using (SolidBrush textBrush = new SolidBrush(Color.Black))
            {
                graphics.DrawString("Aspose.Imaging", font, textBrush, new PointF(200, 350));
            }

            // Save the modified image preserving pixel fidelity
            image.Save(outputPath, new PngOptions());
        }
    }
}