using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage to ensure correct type handling
                OdgImage odgImage = (OdgImage)image;

                using (var svgOptions = new SvgOptions())
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = odgImage.Size
                    };
                    svgOptions.VectorRasterizationOptions = rasterOptions;

                    odgImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to import an OpenDocument Graphics (ODG) illustration into a web application and serve it as scalable SVG without losing vector fidelity.
 * 2. When a C# backend service must batch‑convert design assets stored as ODG files into SVG for responsive UI rendering.
 * 3. When an automated reporting tool has to embed vector diagrams from ODG into PDF or HTML reports by first converting them to SVG.
 * 4. When a desktop application processes user‑uploaded ODG drawings and saves them as SVG to enable editing in browser‑based vector editors.
 * 5. When a migration script moves legacy ODG assets to an SVG‑based asset pipeline while preserving exact page size and background color using Aspose.Imaging.
 */