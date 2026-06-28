using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputDir = @"C:\Icons\Svg";
            string outputDir = @"C:\Icons\MonochromePng";

            // List of SVG files to process
            string[] svgFiles = new[]
            {
                "icon1.svg",
                "icon2.svg",
                "icon3.svg"
            };

            foreach (string fileName in svgFiles)
            {
                // Build full paths
                string inputPath = Path.Combine(inputDir, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDir, Path.ChangeExtension(fileName, ".png"));
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Rasterization options for SVG → PNG conversion
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size,
                        BackgroundColor = Color.Black // dark background for dark theme
                    };

                    // PNG save options with the rasterization settings
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the rasterized PNG
                    svgImage.Save(outputPath, pngOptions);
                }

                // Re‑open the PNG to convert it to grayscale (monochrome)
                using (PngImage png = (PngImage)Image.Load(outputPath))
                {
                    png.Grayscale();               // Convert to grayscale
                    png.Save(outputPath);          // Overwrite with the monochrome version
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
 * 1. When a developer needs to batch‑convert a collection of SVG icons into monochrome PNG files for a dark‑theme UI, this code automates the rasterization and saves the images with a black background.
 * 2. When building a cross‑platform mobile app that requires lightweight PNG assets derived from vector SVG logos, the snippet quickly generates dark‑mode ready PNGs using Aspose.Imaging in C#.
 * 3. When a CI/CD pipeline must produce production‑ready icon sets for a web dashboard that only supports PNG, the example shows how to script the conversion of multiple SVG files to black‑and‑white PNGs.
 * 4. When an accessibility tool needs to replace colorful SVG symbols with high‑contrast monochrome PNGs for visually impaired users, the code demonstrates the necessary file‑system handling and rasterization options.
 * 5. When a game developer wants to pre‑process SVG UI elements into dark‑theme compatible PNG sprites for faster loading, this sample provides a straightforward way to load, rasterize, and save the assets in bulk.
 */