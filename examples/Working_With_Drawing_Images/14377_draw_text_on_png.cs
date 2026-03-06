using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output PNG file path (can be passed as first argument)
        string outputPath = args.Length > 0 ? args[0] : "output.png";

        // Create a file stream for the PNG image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a blank PNG image of desired size (e.g., 400x200)
            using (Image image = Image.Create(pngOptions, 400, 200))
            {
                // Initialize Graphics for drawing on the image
                Graphics graphics = new Graphics(image);

                // Optional: clear background with a solid color
                graphics.Clear(Color.White);

                // Prepare a solid brush for text rendering
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    // Define the font to use
                    Font font = new Font("Arial", 24);

                    // Draw the text at the specified location
                    graphics.DrawString("Hello Aspose.Imaging!", font, brush, new PointF(50, 80));
                }

                // Save the image (the stream is already bound, so just call Save)
                image.Save();
            }
        }
    }
}