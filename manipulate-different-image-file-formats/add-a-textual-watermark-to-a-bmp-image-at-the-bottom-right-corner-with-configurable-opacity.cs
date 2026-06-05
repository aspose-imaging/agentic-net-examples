using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                BmpImage bmpImage = (BmpImage)image;
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(bmpImage);

                string watermarkText = "Sample Watermark";
                Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 24);
                float opacity = 0.5f;

                Aspose.Imaging.SizeF layoutArea = new Aspose.Imaging.SizeF(bmpImage.Width, bmpImage.Height);
                Aspose.Imaging.StringFormat format = new Aspose.Imaging.StringFormat();
                Aspose.Imaging.SizeF textSize = graphics.MeasureString(watermarkText, font, layoutArea, format);

                float margin = 10f;
                float x = bmpImage.Width - textSize.Width - margin;
                float y = bmpImage.Height - textSize.Height - margin;

                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.White;
                    brush.Opacity = opacity;
                    graphics.DrawString(watermarkText, font, brush, new Aspose.Imaging.PointF(x, y));
                }

                bmpImage.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to embed a semi‑transparent textual watermark in a BMP file for copyright protection before distributing the image.
 * 2. When an application must automatically add a brand name to scanned BMP documents at the bottom‑right corner with configurable opacity using C# and Aspose.Imaging.
 * 3. When a batch‑processing tool has to annotate product screenshots saved as BMP images with a light‑gray watermark that does not obscure the underlying content.
 * 4. When a Windows service generates BMP thumbnails and wants to include a “Confidential” label in the corner with adjustable transparency to comply with security policies.
 * 5. When a developer is building a reporting system that stamps the current date and time onto BMP charts, positioning the text at the lower‑right edge with a 50 % opacity brush.
 */