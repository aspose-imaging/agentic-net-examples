using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\hatch.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // BMP creation options
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        const int width = 400;
        const int height = 400;

        // Create a new BMP image
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics object
            Graphics graphics = new Graphics(image);

            // Clear the canvas with Ivory color
            graphics.Clear(Color.FromArgb(255, 255, 255, 240)); // Ivory

            // Pen for drawing hatch lines
            Pen pen = new Pen(Color.Black, 1);

            // Draw forward diagonal lines (top‑left to bottom‑right)
            for (int i = 0; i <= width; i += 20)
            {
                graphics.DrawLine(pen, i, 0, 0, i);
                graphics.DrawLine(pen, width - i, height, width, height - i);
            }

            // Draw backward diagonal lines (top‑right to bottom‑left)
            for (int i = 0; i <= width; i += 20)
            {
                graphics.DrawLine(pen, width - i, 0, width, i);
                graphics.DrawLine(pen, i, height, 0, height - i);
            }

            // Save the image (writes to the path specified in FileCreateSource)
            image.Save();
        }
    }
}