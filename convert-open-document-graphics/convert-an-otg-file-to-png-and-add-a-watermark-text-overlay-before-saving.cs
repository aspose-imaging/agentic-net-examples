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
            // Hardcoded input and output paths
            string inputPath = "input.otg";
            string outputPath = "output\\converted.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with OTG rasterization
                PngOptions pngOptions = new PngOptions();
                OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterizationOptions;

                // Draw watermark text onto the image
                Graphics graphics = new Graphics(image);
                Font font = new Font("Arial", 48);
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.White;
                    brush.Opacity = 50; // semi‑transparent

                    // Position the watermark near the bottom‑right corner
                    float x = image.Width - 300;
                    float y = image.Height - 60;
                    graphics.DrawString("Watermark", font, brush, new PointF(x, y));
                }

                // Save the final PNG image
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}