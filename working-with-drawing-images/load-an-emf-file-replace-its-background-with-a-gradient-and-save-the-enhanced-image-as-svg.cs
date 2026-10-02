// HOW-TO: Convert EMF to SVG with Custom Background Color in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.emf";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image emfImage = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(emfImage);

                // Gradient fill not supported; using solid color as fallback
                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillRectangle(brush, 0, 0, emfImage.Width, emfImage.Height);
                }

                SvgOptions svgOptions = new SvgOptions();
                emfImage.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a vector diagram from an EMF file into a web page and want to replace its default background with a solid color before converting it to SVG.
 * 2. When a reporting tool generates charts as EMF and you must produce SVG assets with a consistent background for cross‑platform rendering.
 * 3. When migrating legacy Windows Metafile assets to scalable SVG format while ensuring the images have a uniform light‑blue background for branding.
 * 4. When automating a batch process that reads EMF logos, applies a corporate color as the background, and saves them as SVG for use in responsive UI designs.
 * 5. When integrating Aspose.Imaging in a C# application to programmatically change the background of vector graphics and export them to SVG for further editing in design software.
 */
