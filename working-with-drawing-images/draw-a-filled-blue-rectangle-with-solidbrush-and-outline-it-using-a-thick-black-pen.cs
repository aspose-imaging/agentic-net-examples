using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a PNG image canvas
            PngOptions pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Fill a blue rectangle
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    graphics.FillRectangle(brush, new Rectangle(20, 20, 160, 160));
                }

                // Outline the rectangle with a thick black pen
                Pen pen = new Pen(Aspose.Imaging.Color.Black, 5);
                graphics.DrawRectangle(pen, new Rectangle(20, 20, 160, 160));

                // Save the image to the specified path
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}