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
        // Output file path (hardcoded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options and bind the output file
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
                brush.Color = Color.FromArgb(255, 128, 0, 128); // Custom purple color

                // Construct a pen from the brush's color
                Pen pen = new Pen(brush.Color, 5);

                // Draw a rectangle using the pen
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));
            }

            // Save the image (output path already bound)
            image.Save();
        }
    }
}