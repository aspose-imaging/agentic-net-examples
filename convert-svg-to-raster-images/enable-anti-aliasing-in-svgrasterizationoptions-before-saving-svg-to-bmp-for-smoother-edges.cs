// HOW-TO: How To Enable Anti-Aliasing When Converting Svg To Bmp In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using System.Drawing.Drawing2D;

namespace SvgToBmpConverter
{
    class Program
    {
        static void Main()
        {
            const string inputPath = "input.svg";
            const string outputPath = "output/output.bmp";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.AntiAlias
                    };

                    var bmpOptions = new BmpOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    image.Save(outputPath, bmpOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate high‑quality bitmap thumbnails from vector SVG icons, enabling anti‑aliasing ensures smooth edges in the BMP output.
 * 2. When exporting SVG diagrams to BMP for inclusion in legacy Windows reports, applying SmoothingMode.AntiAlias prevents jagged lines and improves readability.
 * 3. When a desktop tool converts user‑uploaded SVG logos to BMP for printing, anti‑aliasing provides a professional‑grade appearance without manual editing.
 * 4. When automating batch processing of SVG assets to BMP for a game’s texture pipeline, enabling anti‑aliasing maintains visual fidelity across different screen resolutions.
 * 5. When integrating Aspose.Imaging into a C# service that renders SVG charts as BMP images for email attachments, setting anti‑aliasing guarantees crisp visual presentation.
 */
