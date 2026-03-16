using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output JPEG file path
        string outputPath = "text_dimensions.jpg";

        // Define image canvas size
        int canvasWidth = 800;
        int canvasHeight = 200;

        // Create JPEG options with file source
        JpegOptions jpegOptions = new JpegOptions();
        jpegOptions.Source = new FileCreateSource(outputPath, false);
        jpegOptions.Quality = 90;

        // Create JPEG image canvas
        using (Image image = Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Define text, font and formatting
            string text = "Sample text for measurement";
            Font font = new Font("Arial", 36);
            StringFormat format = new StringFormat();

            // Measure the text size
            SizeF textSize = graphics.MeasureString(text, font, new SizeF(float.MaxValue, float.MaxValue), format);

            // Output measured dimensions
            Console.WriteLine($"Measured Width: {textSize.Width}");
            Console.WriteLine($"Measured Height: {textSize.Height}");

            // Draw the measured text onto the image
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                graphics.DrawString(text, font, brush, 10, 10);
            }

            // Save the image (file is already bound to the source)
            image.Save();
        }
    }
}