using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.ico";
        string outputPath = "output.ico";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing ICO image
        using (Image icoImage = Image.Load(inputPath))
        {
            // Create a Graphics instance for drawing
            Graphics graphics = new Graphics(icoImage);

            // Optional: clear the surface (transparent background)
            graphics.Clear(Color.Transparent);

            // Draw a red rectangle
            graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(10, 10, 64, 64));

            // Draw a blue ellipse
            graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(80, 10, 64, 64));

            // Save the modified ICO image
            icoImage.Save(outputPath);
        }
    }
}