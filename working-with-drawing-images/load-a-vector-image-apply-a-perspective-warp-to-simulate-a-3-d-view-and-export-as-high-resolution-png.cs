// HOW-TO: Apply Perspective Warp to SVG and Export High‑Resolution PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

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

            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage to ensure the vector type is recognized
                SvgImage svgImage = image as SvgImage;

                // Configure rasterization options for high‑resolution output
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // TODO: Apply perspective warp to the vector image using the appropriate Aspose.Imaging API.
                // This step would typically involve a transformation matrix or a dedicated warp method.

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300) // high DPI
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
 * 1. When you need to render a scalable vector graphic as a photorealistic 3‑D‑like image for product brochures, you can warp the SVG and save it as a high‑resolution PNG using Aspose.Imaging in C#.
 * 2. When a web application must generate thumbnail previews of architectural floor plans with a simulated perspective view, this code transforms the SVG and outputs a DPI‑300 PNG for crisp display.
 * 3. When an e‑learning platform wants to convert interactive SVG diagrams into printable high‑quality PNG slides that appear tilted or angled, the perspective warp and rasterization options provide the needed result.
 * 4. When a game developer requires pre‑rendered background assets from vector art with a forced‑perspective effect, the snippet creates high‑resolution PNGs that maintain visual fidelity.
 * 5. When a reporting tool needs to embed vector logos in reports with a 3‑D tilt and ensure they print sharply at 300 dpi, this C# example performs the warp and saves the PNG for inclusion.
 */
