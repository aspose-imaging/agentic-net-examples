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
        // Output file path
        string outputPath = "output.png";

        // Define image dimensions
        int width = 800;
        int height = 200;

        // Create PNG options and bind to a file stream
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create the image canvas
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.White);

                // Prepare brush and font for text
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.DarkBlue;
                    brush.Opacity = 100;

                    Font font = new Font("Arial", 48);

                    // Draw the specified text
                    string text = "Sample Text Rendered with Aspose.Imaging";
                    graphics.DrawString(text, font, brush, new PointF(20, 80));
                }

                // Save changes (stream is already bound)
                image.Save();
            }
        }
    }
}