using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert legacy EPS artwork into scalable SVG files for responsive web pages using Aspose.Imaging in C#.
 * 2. When an automated build pipeline must transform vector EPS logos into SVG format to embed in HTML emails without losing quality.
 * 3. When a desktop application processes user‑uploaded EPS designs and saves them as SVG for further client‑side manipulation or editing.
 * 4. When a reporting tool generates charts in EPS and then converts them to SVG to ensure lossless scaling in PDF or web reports.
 * 5. When a content management system batch‑processes EPS files and stores the resulting SVGs for fast browser rendering and SEO optimization.
 */