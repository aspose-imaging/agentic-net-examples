using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\Images\\photo.dng";
        string outputPath = "C:\\Images\\photo_watermarked.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DNG image
        using (var dngImage = (DngImage)Image.Load(inputPath))
        {
            // Create graphics object for drawing
            Graphics graphics = new Graphics(dngImage);

            // Semi-transparent white brush (50% opacity)
            SolidBrush brush = new SolidBrush();
            brush.Color = Color.FromArgb(128, 255, 255, 255);

            // Font for watermark text
            Font font = new Font("Arial", 48);

            // Position watermark near bottom-right corner
            int margin = 20;
            float x = dngImage.Width - 300; // adjust as needed for text width
            float y = dngImage.Height - 60; // adjust as needed for text height

            // Draw watermark text
            graphics.DrawString("Sample Watermark", font, brush, new PointF(x, y));

            // Save the result as PNG
            dngImage.Save(outputPath, new PngOptions());
        }
    }
}