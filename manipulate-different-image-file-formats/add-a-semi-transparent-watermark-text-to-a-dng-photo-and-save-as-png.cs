using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dng";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                // Create graphics object for drawing
                Graphics graphics = new Graphics(dng);

                // Define semi‑transparent white brush
                SolidBrush brush = new SolidBrush();
                brush.Color = Color.FromArgb(128, 255, 255, 255); // 50% opacity

                // Define font for watermark text
                Font font = new Font("Arial", 48);

                // Draw watermark text at desired position
                graphics.DrawString("Watermark", font, brush, new PointF(10, 10));

                // Save the result as PNG
                PngOptions pngOptions = new PngOptions();
                dng.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}