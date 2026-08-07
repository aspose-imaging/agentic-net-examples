using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

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
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to generate a dark‑mode version of an SVG icon by rotating its hue 180° and serving it as a PNG for browsers that do not support SVG.
 * 2. When an e‑commerce platform wants to automatically recolor product vector illustrations (e.g., change brand colors) by applying a 180‑degree hue shift before embedding them as PNG thumbnails in email newsletters.
 * 3. When a reporting tool must convert SVG charts into PNG images with a complementary color scheme, using a 180° hue rotation to improve contrast on printed reports.
 * 4. When a mobile game developer needs to create alternate‑color sprite sheets from SVG assets by shifting hues and exporting them as PNG files for faster loading on devices.
 * 5. When a document generation service processes user‑uploaded SVG logos, applies a 180° hue rotation to match a corporate color palette, and saves the result as PNG for inclusion in PDF invoices.
 */