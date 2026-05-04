using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputSvgPath = "input.svg";
            string overlayImagePath = "overlay.png";
            string outputPath = "output.png";

            // Validate input files
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }
            if (!File.Exists(overlayImagePath))
            {
                Console.Error.WriteLine($"File not found: {overlayImagePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary PNG path for rasterized SVG
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_svg.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Rasterize SVG to PNG (temporary file)
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized SVG and overlay image
            using (RasterImage baseImage = (RasterImage)Image.Load(tempPngPath))
            using (RasterImage overlayImage = (RasterImage)Image.Load(overlayImagePath))
            {
                // Prepare output source and options
                Source outputSource = new FileCreateSource(outputPath, false);
                var outputOptions = new PngOptions { Source = outputSource };

                // Create canvas bound to output file
                using (RasterImage canvas = (RasterImage)Image.Create(outputOptions, baseImage.Width, baseImage.Height))
                {
                    // Copy base image onto canvas
                    canvas.SaveArgb32Pixels(
                        new Rectangle(0, 0, baseImage.Width, baseImage.Height),
                        baseImage.LoadArgb32Pixels(baseImage.Bounds));

                    // Define overlay position
                    int overlayX = 50;
                    int overlayY = 50;

                    // Overlay second image
                    canvas.SaveArgb32Pixels(
                        new Rectangle(overlayX, overlayY, overlayImage.Width, overlayImage.Height),
                        overlayImage.LoadArgb32Pixels(overlayImage.Bounds));

                    // Save final image
                    canvas.Save();
                }
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}