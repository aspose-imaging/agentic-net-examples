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
            // Hard‑coded paths
            string inputPath = @"C:\Images\input.png";
            string resizedPngPath = @"C:\Images\output_resized.png";
            string outputSvgPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(resizedPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Lanczos resampling settings
                var resizeSettings = new ImageResizeSettings
                {
                    Mode = ResizeType.LanczosResample,
                    FilterType = ImageFilterType.SmallRectangular
                };

                // Desired dimensions (example: 800x600)
                int newWidth = 800;
                int newHeight = 600;

                // Resize using Lanczos
                image.Resize(newWidth, newHeight, resizeSettings);

                // Save the resized raster image as PNG
                image.Save(resizedPngPath, new PngOptions());

                // Prepare high‑quality SVG export options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAlias,
                        BackgroundColor = Color.White
                    }
                };

                // Export the image as SVG
                image.Save(outputSvgPath, svgOptions);
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
 * 1. When a web developer needs to generate a smaller, high‑quality PNG thumbnail for responsive design and then provide a scalable SVG fallback for retina displays.
 * 2. When an e‑commerce platform must batch‑process product photos, resizing them with Lanczos resampling to preserve detail while converting them to SVG for vector‑based marketing assets.
 * 3. When a mobile app creates user‑generated stickers, it resizes the original PNG to a fixed canvas size and exports an SVG version for unlimited scaling without pixelation.
 * 4. When a publishing system prepares print‑ready graphics, it reduces the PNG resolution using Lanczos and saves an SVG copy to embed crisp vector graphics in PDFs.
 * 5. When a GIS application needs to downscale large raster map tiles and then convert them to SVG for overlaying interactive vector layers in a web map viewer.
 */