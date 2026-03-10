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

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image with desired dimensions
            using (Image image = Image.Create(pngOptions, 400, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.LightGray);

                // Create a solid brush for the text
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    // Define the font
                    Font font = new Font("Arial", 24);

                    // Draw the text string at specified location
                    graphics.DrawString("Hello Aspose!", font, brush, new PointF(50, 80));
                }

                // Save changes to the image
                image.Save();
            }
        }
    }
}