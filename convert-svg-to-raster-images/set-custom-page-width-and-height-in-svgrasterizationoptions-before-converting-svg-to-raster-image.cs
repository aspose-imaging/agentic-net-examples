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
            string inputPath = "input.svg";
            string outputPath = "output.png";

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
                // Configure rasterization options with custom page size
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Set custom width and height (in pixels)
                    PageWidth = 800f,
                    PageHeight = 600f,
                    // Optional: set background color
                    BackgroundColor = Color.White
                };

                // Prepare PNG save options and attach rasterization options
                PngOptions saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image
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
 * 1. When generating thumbnail previews of user‑uploaded SVG logos for a web portal, a developer can set PageWidth and PageHeight in SvgRasterizationOptions to produce consistent 800×600 PNG thumbnails.
 * 2. When creating printable product catalogs where SVG diagrams must fit a specific page layout, a developer uses custom page dimensions in SvgRasterizationOptions to rasterize the SVG to a PNG of the exact size required by the layout engine.
 * 3. When integrating SVG assets into a Windows desktop application that expects bitmap resources of a fixed resolution, a developer sets the rasterization options’ PageWidth and PageHeight to match the target bitmap size before saving as PNG.
 * 4. When automating batch conversion of SVG icons to high‑resolution PNG sprites for a mobile app, a developer defines custom page width and height in SvgRasterizationOptions to ensure each sprite meets the required pixel dimensions.
 * 5. When performing server‑side image processing that overlays SVG graphics onto photographs, a developer controls the rasterized SVG size by configuring PageWidth and PageHeight in SvgRasterizationOptions so the overlay aligns correctly with the background image.
 */