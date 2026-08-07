using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

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
                SvgImage svgImage = (SvgImage)image;

                // Set high-resolution rasterization options
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    // Increase scale for higher resolution (e.g., 2x)
                    ScaleX = 2.0f,
                    ScaleY = 2.0f
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert an SVG logo or icon into a high‑resolution PNG for print‑ready marketing materials, this C# code using Aspose.Imaging can rasterize the vector at 2× scale and preserve anti‑aliasing.
 * 2. When a web application must generate sharp PNG thumbnails from user‑uploaded SVG files on the fly, the example shows how to load the SVG, set rasterization options, and save the result efficiently.
 * 3. When a desktop utility has to batch‑process vector drawings into PNG assets with a white background for UI design, the code demonstrates the required file‑format handling and scaling in .NET.
 * 4. When an e‑learning platform wants to embed scalable SVG diagrams as high‑quality PNG images in PDF reports, this snippet illustrates how to control page size, background color, and resolution during conversion.
 * 5. When a CI/CD pipeline needs to verify that SVG assets render correctly as PNGs at double resolution before deployment, the example provides a repeatable C# workflow using Aspose.Imaging’s rasterization options.
 */