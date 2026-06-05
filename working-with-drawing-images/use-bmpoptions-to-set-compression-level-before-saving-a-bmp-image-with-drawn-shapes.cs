using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\shapes.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options with desired compression
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Compression = BitmapCompression.Rgb; // No compression
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Draw a red rectangle
                Pen redPen = new Pen(Color.Red, 3);
                graphics.DrawRectangle(redPen, new Rectangle(50, 50, 200, 150));

                // Draw a blue ellipse
                Pen bluePen = new Pen(Color.Blue, 2);
                graphics.DrawEllipse(bluePen, new Rectangle(300, 100, 150, 100));

                // Draw a green line
                Pen greenPen = new Pen(Color.Green, 4);
                graphics.DrawLine(greenPen, new Point(100, 400), new Point(400, 400));

                // Fill a solid yellow rectangle
                using (SolidBrush yellowBrush = new SolidBrush())
                {
                    yellowBrush.Color = Color.Yellow;
                    yellowBrush.Opacity = 100;
                    graphics.FillRectangle(yellowBrush, new Rectangle(250, 250, 100, 100));
                }

                // Save the image (output path already bound by FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a BMP report thumbnail with custom shapes and control the compression level for optimal file size using Aspose.Imaging BmpOptions in C#.
 * 2. When an engineering application must export a schematic diagram as a 24‑bit BMP image with no compression to preserve pixel accuracy while drawing rectangles, ellipses, and lines programmatically.
 * 3. When a desktop utility creates printable BMP assets for legacy hardware and requires explicit BmpOptions settings such as BitsPerPixel and BitmapCompression before saving the image.
 * 4. When a medical imaging system needs to annotate a BMP scan with colored shapes and ensure the output file uses the RGB compression mode for compatibility with older DICOM viewers.
 * 5. When a game development tool generates level‑design overlays as BMP files, drawing shapes with Aspose.Imaging graphics and setting compression to Rgb to maintain visual fidelity across different platforms.
 */