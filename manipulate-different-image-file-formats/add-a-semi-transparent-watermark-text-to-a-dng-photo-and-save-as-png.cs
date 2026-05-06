using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dng";
            string outputPath = "output\\watermarked.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DngImage dng = (DngImage)image;

                // Create graphics for drawing
                Graphics graphics = new Graphics(dng);

                // Semi‑transparent white brush (50% opacity)
                SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 255, 255));

                // Font for the watermark text
                Font font = new Font("Arial", 48);

                // Position the watermark near the bottom‑right corner
                PointF position = new PointF(dng.Width - 300, dng.Height - 60);

                // Draw the watermark text
                graphics.DrawString("Watermark", font, brush, position);

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