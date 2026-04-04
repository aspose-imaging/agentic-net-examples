using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output\\grid.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Create graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the image to light gray
            graphics.Clear(Aspose.Imaging.Color.LightGray);

            // Define grid spacing and pen
            int spacing = 50;
            Pen redPen = new Pen(Aspose.Imaging.Color.Red, 1);

            // Draw vertical lines
            for (int x = 0; x <= image.Width; x += spacing)
            {
                graphics.DrawLine(redPen, new Point(x, 0), new Point(x, image.Height));
            }

            // Draw horizontal lines
            for (int y = 0; y <= image.Height; y += spacing)
            {
                graphics.DrawLine(redPen, new Point(0, y), new Point(image.Width, y));
            }

            // Save the modified image as BMP
            image.Save(outputPath, new BmpOptions());
        }
    }
}