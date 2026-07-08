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
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                // Configure rasterization options for high‑resolution output
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
                };

                // PNG export options with desired DPI
                PngOptions pngOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = rasterOptions
                };

                // Perspective warp is not directly supported by Aspose.Imaging.
                // If needed, custom processing should be implemented here.

                vectorImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert an SVG logo into a print‑ready 300 DPI PNG for marketing brochures, they can use this code to rasterize the vector at high resolution.
 * 2. When a web application must generate thumbnail previews of user‑uploaded SVG diagrams as PNG files with anti‑aliased rendering, this snippet provides the necessary C# workflow.
 * 3. When an e‑learning platform wants to display 2‑D icons from SVG assets on high‑density screens, the code enables loading the vector, applying optional custom perspective transformations, and exporting a crisp PNG.
 * 4. When a desktop publishing tool requires batch processing of SVG illustrations into PNG assets while preserving original dimensions and applying smoothing and text rendering hints, this example shows how to automate it with Aspose.Imaging.
 * 5. When a developer is building a reporting service that embeds vector charts as PNG images in PDF reports and needs to ensure the output matches the original size and resolution, this code demonstrates the required rasterization and DPI settings.
 */