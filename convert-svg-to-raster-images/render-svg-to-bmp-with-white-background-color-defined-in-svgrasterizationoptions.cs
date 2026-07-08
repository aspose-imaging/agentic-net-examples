using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Configure rasterization options with a white background
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = svgImage.Size // preserve original size
                };

                // Set up BMP save options and attach rasterization options
                BmpOptions saveOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image as BMP
                svgImage.Save(outputPath, saveOptions);
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG logos as BMP files with a solid white background for compatibility with legacy Windows applications.
 * 2. When an automated reporting tool must convert vector diagrams stored in SVG format into BMP images to embed them in PDF reports that only support raster graphics.
 * 3. When a desktop utility processes a batch of SVG icons and saves them as BMP files with a white background to ensure consistent appearance on devices that do not support transparency.
 * 4. When a game development pipeline requires rasterizing SVG assets to BMP textures with a predefined background color for use in older DirectX rendering engines.
 * 5. When a document management system archives SVG drawings as BMP files with a white background to guarantee that the images render correctly in environments lacking SVG support.
 */