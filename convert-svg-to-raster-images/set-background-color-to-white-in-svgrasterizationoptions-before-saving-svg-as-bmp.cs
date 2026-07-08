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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Set up rasterization options with a white background
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = svgImage.Size // preserve original dimensions
                };

                // Configure BMP save options and attach the rasterization options
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the SVG as a BMP file
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
 * 1. When converting an SVG logo with transparent regions to a BMP thumbnail for a Windows desktop application, a developer can set the background color to white to avoid a black default background.
 * 2. When generating printable BMP assets from SVG icons for a legacy reporting system that does not support alpha channels, the code ensures the images have a solid white background.
 * 3. When batch‑processing SVG diagrams to BMP files for inclusion in a PDF document, a developer uses this snippet to guarantee consistent white backgrounds across all pages.
 * 4. When creating BMP previews of user‑uploaded SVG drawings in a web service, the code provides a white canvas so the preview looks correct on light‑themed pages.
 * 5. When migrating SVG assets to BMP format for an embedded device that only renders BMP images, setting the background color to white prevents visual artifacts caused by transparent SVG layers.
 */