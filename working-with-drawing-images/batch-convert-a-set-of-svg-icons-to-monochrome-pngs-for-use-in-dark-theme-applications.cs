using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Icons\Svg";
            string outputDir = @"C:\Icons\Png";

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .png extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare rasterization options for SVG -> PNG conversion
                    SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                    {
                        // Render on a black background for dark theme
                        BackgroundColor = Color.Black,
                        // Use a size equal to the original SVG dimensions
                        PageSize = image.Size
                    };

                    // Prepare PNG save options with grayscale (monochrome) color type
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions,
                        // Force grayscale output
                        ColorType = PngColorType.Grayscale
                    };

                    // Save the rasterized PNG
                    image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate monochrome PNG assets from a library of SVG icons for a dark‑theme UI, they can batch‑convert the files using Aspose.Imaging’s SVG rasterization and PNG options in C#.
 * 2. When an automated build pipeline must produce black‑background, grayscale PNGs from SVG source files to ensure consistent branding across Windows desktop applications, this code can be integrated to run during CI.
 * 3. When a mobile app requires lightweight, single‑color PNG icons derived from scalable SVG vectors to reduce memory usage on low‑end devices, the snippet provides a fast C# solution.
 * 4. When a content management system needs to export user‑uploaded SVG logos as dark‑theme ready PNG thumbnails for preview thumbnails, the example shows how to process a folder of images in one pass.
 * 5. When a game developer wants to pre‑process SVG UI elements into black‑background, monochrome PNG sprites for faster rendering in Unity, the code demonstrates the necessary file‑system and image‑format handling.
 */