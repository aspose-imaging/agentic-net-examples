using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hardcoded)
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set PNG options with the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 500x500 PNG image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw first line (red, thickness 5)
                graphics.DrawLine(new Pen(Color.Red, 5), new Point(50, 50), new Point(450, 50));

                // Draw second line (green, thickness 3)
                graphics.DrawLine(new Pen(Color.Green, 3), new Point(50, 100), new Point(450, 300));

                // Draw third line (blue, thickness 2)
                graphics.DrawLine(new Pen(Color.Blue, 2), new Point(50, 150), new Point(450, 450));

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}