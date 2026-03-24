using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Graphics;
using Aspose.Imaging.Fonts;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a PNG image with desired size
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options
            PngOptions pngOptions = new PngOptions
            {
                Source = new StreamSource(stream)
            };

            // Configure vector rasterization options to improve text quality
            VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
            {
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
            };
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Create the image (800x200 pixels)
            using (Image image = Image.Create(pngOptions, 800, 200))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Prepare brush for text
                SolidBrush brush = new SolidBrush
                {
                    Color = Aspose.Imaging.Color.Black,
                    Opacity = 100
                };

                // Define font
                Font font = new Font("Arial", 48);

                // Draw the text string at the desired location
                graphics.DrawString("Hello Aspose!", font, brush, new PointF(50, 70));

                // Save the image
                image.Save();
            }
        }
    }
}