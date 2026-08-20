// HOW-TO: Convert SVG to BMP with White Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options with a white background
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = svgImage.Size // preserve original size
                };

                // Set BMP save options and attach rasterization options
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as BMP
                svgImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate a BMP thumbnail of an SVG logo and ensure the image has a solid white background for consistent display in Windows applications.
 * 2. When converting vector graphics to raster format for printing on devices that only support BMP and require a non‑transparent background.
 * 3. When preparing SVG assets for legacy systems that cannot handle transparency, so you rasterize them to BMP with a white canvas.
 * 4. When automating batch processing of SVG icons to BMP files for inclusion in a game’s texture atlas, guaranteeing a uniform white backdrop.
 * 5. When creating documentation screenshots from SVG diagrams and need the output BMP to have a white background to match the surrounding page layout.
 */
