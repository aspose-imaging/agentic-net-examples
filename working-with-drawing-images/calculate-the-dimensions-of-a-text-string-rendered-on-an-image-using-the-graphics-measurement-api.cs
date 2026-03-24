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
        // Output image path
        string outputPath = "output\\text_image.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG image and bind to file stream
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            using (Image image = Image.Create(pngOptions, 500, 200))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Text to measure
                string text = "Sample Text";

                // Font definition
                Font font = new Font("Arial", 24);

                // Layout area for measurement
                SizeF layoutArea = new SizeF(500, 200);

                // String format (default)
                StringFormat format = new StringFormat();

                // Measure the string
                SizeF measuredSize = graphics.MeasureString(text, font, layoutArea, format);
                Console.WriteLine($"Measured size: Width = {measuredSize.Width}, Height = {measuredSize.Height}");

                // Optional: draw the measured string onto the image
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    graphics.DrawString(text, font, brush, new PointF(0, 0));
                }

                // Save the image (file is already bound to the stream)
                image.Save();
            }
        }
    }
}