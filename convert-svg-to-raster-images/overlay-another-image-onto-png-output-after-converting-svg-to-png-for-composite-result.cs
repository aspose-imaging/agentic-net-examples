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
            // Hardcoded input and output paths
            string svgPath = "input.svg";
            string overlayPath = "overlay.png";
            string outputPath = "output.png";
            string tempPngPath = "temp_output.png";

            // Validate input files
            if (!File.Exists(svgPath))
            {
                Console.Error.WriteLine($"File not found: {svgPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");

            // Convert SVG to a temporary PNG file
            using (Image svgImage = Image.Load(svgPath))
            {
                PngOptions pngOptions = new PngOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized SVG and the overlay image
            using (RasterImage baseImg = (RasterImage)Image.Load(tempPngPath))
            using (RasterImage overlayImg = (RasterImage)Image.Load(overlayPath))
            {
                // Create the final PNG canvas bound to the output file
                Source outSource = new FileCreateSource(outputPath, false);
                PngOptions outOptions = new PngOptions { Source = outSource };
                using (RasterImage canvas = (RasterImage)Image.Create(outOptions, baseImg.Width, baseImg.Height))
                {
                    // Copy base image pixels onto the canvas
                    canvas.SaveArgb32Pixels(
                        new Rectangle(0, 0, baseImg.Width, baseImg.Height),
                        baseImg.LoadArgb32Pixels(baseImg.Bounds));

                    // Overlay the second image at position (0,0)
                    canvas.SaveArgb32Pixels(
                        new Rectangle(0, 0, overlayImg.Width, overlayImg.Height),
                        overlayImg.LoadArgb32Pixels(overlayImg.Bounds));

                    // Save the bound image
                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}