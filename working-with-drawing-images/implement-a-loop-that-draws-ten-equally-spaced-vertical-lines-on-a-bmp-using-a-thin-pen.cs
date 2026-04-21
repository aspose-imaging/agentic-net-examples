using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output BMP file path (hardcoded)
        string outputPath = @"C:\temp\vertical_lines.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        int width = 500;
        int height = 500;
        int lineCount = 10;

        // Set BMP options with a file create source bound to the output path
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Pen for thin black lines
            Pen pen = new Pen(Color.Black, 1);

            // Draw equally spaced vertical lines
            for (int i = 0; i < lineCount; i++)
            {
                int x = (i + 1) * width / (lineCount + 1);
                graphics.DrawLine(pen, x, 0, x, height);
            }

            // Save the image (output path already bound)
            image.Save();
        }
    }
}