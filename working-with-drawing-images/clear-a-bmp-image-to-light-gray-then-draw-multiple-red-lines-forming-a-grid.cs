using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the BMP image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Create graphics object for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Clear the image to light gray
            graphics.Clear(Aspose.Imaging.Color.LightGray);

            // Define grid spacing
            int spacing = 50;

            // Draw vertical red lines
            for (int x = 0; x <= image.Width; x += spacing)
            {
                graphics.DrawLine(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 1),
                    new Aspose.Imaging.Point(x, 0),
                    new Aspose.Imaging.Point(x, image.Height));
            }

            // Draw horizontal red lines
            for (int y = 0; y <= image.Height; y += spacing)
            {
                graphics.DrawLine(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 1),
                    new Aspose.Imaging.Point(0, y),
                    new Aspose.Imaging.Point(image.Width, y));
            }

            // Save the modified image as BMP
            var bmpOptions = new BmpOptions();
            image.Save(outputPath, bmpOptions);
        }
    }
}