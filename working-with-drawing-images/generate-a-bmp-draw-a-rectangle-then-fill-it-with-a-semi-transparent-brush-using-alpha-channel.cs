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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 32; // Use 32 bits to support alpha channel
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Define rectangle bounds
            Rectangle rect = new Rectangle(100, 100, 300, 200);

            // Draw rectangle outline
            graphics.DrawRectangle(new Pen(Color.Black, 2), rect);

            // Create a semi‑transparent brush
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.Blue;
                brush.Opacity = 0.5f; // 0 = fully visible, 1 = fully opaque

                // Fill the rectangle with the semi‑transparent brush
                graphics.FillRectangle(brush, rect);
            }

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}