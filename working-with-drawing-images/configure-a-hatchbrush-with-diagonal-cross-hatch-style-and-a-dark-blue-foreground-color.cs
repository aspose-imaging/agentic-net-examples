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
        // Define output path (hard‑coded literal)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options for a new image
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            // Use FileCreateSource to specify where the image will be saved
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new 500x500 image
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Configure HatchBrush with diagonal cross style and dark blue foreground
            HatchBrush hatchBrush = new HatchBrush
            {
                HatchStyle = HatchStyle.DiagonalCross,   // crossing forward and backward diagonals
                ForegroundColor = Color.DarkBlue,        // dark blue lines
                BackgroundColor = Color.Transparent      // optional: transparent background
            };

            // Create a pen that uses the configured HatchBrush
            Pen hatchPen = new Pen(hatchBrush, 5f);

            // Draw a rectangle using the hatch pen
            graphics.DrawRectangle(hatchPen, new Rectangle(new Point(100, 100), new Size(300, 300)));

            // Save the image (the FileCreateSource already points to outputPath)
            image.Save();
        }
    }
}