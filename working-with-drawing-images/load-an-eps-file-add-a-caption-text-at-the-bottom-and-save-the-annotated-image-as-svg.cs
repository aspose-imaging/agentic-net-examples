// HOW-TO: Add Caption to EPS and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output/output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                Font font = new Font("Arial", 24);
                int margin = 10;
                float x = (image.Width) / 2f;

                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    graphics.DrawString("Caption Text", font, brush, new PointF(x, image.Height - margin - font.Size));
                }

                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to annotate vector artwork from an EPS file with a descriptive label before converting it to SVG for web display.
 * 2. When generating printable PDFs from EPS sources and you want to embed a footer note that persists after converting to SVG.
 * 3. When creating a batch process that adds company branding text to multiple EPS logos and saves them as scalable SVG files for responsive UI.
 * 4. When preparing technical diagrams in EPS format and you must add a caption indicating version or date before exporting to SVG for documentation.
 * 5. When a design tool exports EPS files and you require a C# script to programmatically add a watermark text at the bottom and output SVG for further editing.
 */
