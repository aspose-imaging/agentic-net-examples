// HOW-TO: Convert OTG to PNG With Text Watermark Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.otg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();

                using (Aspose.Imaging.Image outputImage = Aspose.Imaging.Image.Create(options, image.Width, image.Height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(outputImage);
                    graphics.DrawImage(image, new Aspose.Imaging.Rectangle(0, 0, image.Width, image.Height));

                    Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 48);
                    SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.White);
                    graphics.DrawString("Watermark", font, brush, new Aspose.Imaging.Point(10, 10));

                    outputImage.Save(outputPath, options);
                }
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
 * 1. When you need to generate printable PNG previews of OTG vector drawings while branding each image with a company logo or text.
 * 2. When an e‑commerce platform must add a copyright watermark to product diagrams stored as OTG before serving them as PNG thumbnails.
 * 3. When a document management system converts uploaded OTG files to PNG for web display and requires a visible watermark for security.
 * 4. When a batch processing script has to automate conversion of OTG artwork to PNG and overlay custom text for client identification.
 * 5. When a reporting tool creates PNG charts from OTG sources and needs to embed a “Confidential” label directly onto the image.
 */
