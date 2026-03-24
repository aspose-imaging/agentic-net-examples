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
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics instance for drawing
            Graphics graphics = new Graphics(image);

            // Draw a red rectangle
            Pen rectPen = new Pen(Color.Red, 5);
            graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 200, 150));

            // Prepare brush and font for text
            using (SolidBrush textBrush = new SolidBrush(Color.Blue))
            {
                textBrush.Opacity = 255;

                Font textFont = new Font("Arial", 24);
                // Draw a string onto the image
                graphics.DrawString("Hello Aspose!", textFont, textBrush, new PointF(60, 120));
            }

            // Save the modified image as PNG
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}