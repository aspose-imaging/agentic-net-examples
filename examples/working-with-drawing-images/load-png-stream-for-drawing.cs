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
        // Input PNG file path (replace with actual path)
        string inputPath = "input.png";
        // Output PNG file path
        string outputPath = "output.png";

        // Load the PNG file into a memory stream
        using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                // Load PNG image from the stream
                using (PngImage pngImage = new PngImage(memoryStream))
                {
                    // Create a Graphics instance for drawing
                    Graphics graphics = new Graphics(pngImage);

                    // Draw a semi‑transparent red rectangle
                    using (SolidBrush brush = new SolidBrush())
                    {
                        brush.Color = Color.Red;
                        brush.Opacity = 50; // 0‑100 range
                        graphics.FillRectangle(brush, new Rectangle(50, 50, 200, 150));
                    }

                    // Draw a black border around the rectangle
                    Pen pen = new Pen(Color.Black, 3);
                    graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));

                    // Save the modified image
                    pngImage.Save(outputPath);
                }
            }
        }
    }
}