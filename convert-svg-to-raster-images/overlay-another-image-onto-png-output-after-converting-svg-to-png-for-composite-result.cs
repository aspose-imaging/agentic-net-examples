using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputSvgPath = "input.svg";
        string overlayImagePath = "overlay.png";
        string tempPngPath = "temp.png";
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

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Convert SVG to PNG (temporary file)
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
            var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
            svgImage.Save(tempPngPath, pngOptions);
        }

        // Load base PNG (converted from SVG) and overlay image
        using (RasterImage baseImage = (RasterImage)Image.Load(tempPngPath))
        using (RasterImage overlayImage = (RasterImage)Image.Load(overlayImagePath))
        {
            // Create output canvas bound to the output file
            Source outputSource = new FileCreateSource(outputPath, false);
            var outOptions = new PngOptions { Source = outputSource };
            using (RasterImage canvas = (RasterImage)Image.Create(outOptions, baseImage.Width, baseImage.Height))
            {
                // Copy base image onto canvas
                var baseBounds = new Rectangle(0, 0, baseImage.Width, baseImage.Height);
                canvas.SaveArgb32Pixels(baseBounds, baseImage.LoadArgb32Pixels(baseImage.Bounds));

                // Overlay the second image at (0,0)
                var overlayBounds = new Rectangle(0, 0, overlayImage.Width, overlayImage.Height);
                canvas.SaveArgb32Pixels(overlayBounds, overlayImage.LoadArgb32Pixels(overlayImage.Bounds));

                // Save the final composite image
                canvas.Save();
            }
        }
    }
}