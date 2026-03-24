using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.cdr";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR file
        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(cdr);

            // Draw a red rectangle
            graphics.DrawRectangle(
                new Pen(Color.Red, 5),
                new Rectangle(100, 100, 300, 200));

            // Draw a blue ellipse inside the rectangle
            graphics.DrawEllipse(
                new Pen(Color.Blue, 3),
                new Rectangle(110, 110, 280, 180));

            // Draw a string at the bottom
            graphics.DrawString(
                "Modified with Aspose.Imaging",
                new Font("Arial", 24, FontStyle.Bold),
                new SolidBrush(Color.Green),
                new Point(120, 300));

            // Save the modified CDR file
            cdr.Save(outputPath);
        }
    }
}