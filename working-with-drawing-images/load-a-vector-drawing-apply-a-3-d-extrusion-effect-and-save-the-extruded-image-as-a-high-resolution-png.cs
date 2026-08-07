using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output/output.png";

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
                var pngOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = 1000,
                        PageHeight = 1000,
                        BackgroundColor = Color.White
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
 * 1. When a developer needs to convert an SVG logo into a 300 dpi PNG for high‑quality print collateral, they can use this code to rasterize the vector at a specified page size and background color.
 * 2. When an e‑commerce platform must generate product thumbnails with a consistent white background from scalable SVG illustrations, the snippet loads the SVG, rasterizes it at 1000 × 1000 pixels, and saves a high‑resolution PNG.
 * 3. When a reporting tool requires embedding a detailed SVG diagram into a PDF as a raster image, the code provides a C# way to load the SVG, set resolution settings, and export a PNG that retains sharpness at 300 dpi.
 * 4. When a mobile app needs to pre‑process user‑uploaded SVG icons into PNG assets for faster rendering on devices, this example shows how to programmatically load the vector, define rasterization options, and save the result with proper resolution.
 * 5. When a CI/CD pipeline automates the creation of marketing assets, the script can be used to batch‑convert SVG assets to high‑resolution PNG files, ensuring consistent dimensions and color handling across builds.
 */