using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a solid brush with a custom color
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.FromArgb(255, 0, 128, 255); // Custom light blue color

                // Construct a pen from the solid brush with a specific width
                Pen pen = new Pen(brush, 5f);

                // Draw a rectangle using the pen
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));
            }

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}