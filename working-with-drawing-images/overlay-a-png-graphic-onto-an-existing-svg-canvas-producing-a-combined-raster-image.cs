using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string svgPath = "input.svg";
        string pngPath = "overlay.png";
        string outputPath = "output.png";

        // Verify input files exist
        if (!File.Exists(svgPath))
        {
            Console.Error.WriteLine($"File not found: {svgPath}");
            return;
        }
        if (!File.Exists(pngPath))
        {
            Console.Error.WriteLine($"File not found: {pngPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG to obtain its dimensions
        using (SvgImage svgImage = (SvgImage)Image.Load(svgPath))
        {
            int canvasWidth = svgImage.Width;
            int canvasHeight = svgImage.Height;

            // Prepare output source and options
            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outSource };

            // Create a raster canvas with the size of the SVG
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Load the PNG overlay
                using (RasterImage overlay = (RasterImage)Image.Load(pngPath))
                {
                    // Define the region where the PNG will be placed (top-left corner)
                    Rectangle overlayRegion = new Rectangle(0, 0, overlay.Width, overlay.Height);

                    // Copy PNG pixels onto the canvas
                    canvas.SaveArgb32Pixels(overlayRegion, overlay.LoadArgb32Pixels(overlay.Bounds));
                }

                // Save the combined raster image
                canvas.Save();
            }
        }
    }
}