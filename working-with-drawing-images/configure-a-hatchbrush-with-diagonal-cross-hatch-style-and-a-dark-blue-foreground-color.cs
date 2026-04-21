using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\hatchbrush_demo.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure the HatchBrush with diagonal cross style and dark blue foreground
        HatchBrush brush = new HatchBrush
        {
            HatchStyle = HatchStyle.DiagonalCross,
            ForegroundColor = Color.DarkBlue,
            BackgroundColor = Color.White
        };

        // Set up BMP options for image creation
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new image (200x200 pixels)
        using (Image image = Image.Create(bmpOptions, 200, 200))
        {
            // Initialize graphics object
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Create a pen using the configured HatchBrush
            Pen pen = new Pen(brush, 5f);

            // Draw a rectangle using the hatch brush pen
            graphics.DrawRectangle(pen, new Rectangle(20, 20, 160, 160));

            // Save the image
            image.Save();
        }
    }
}