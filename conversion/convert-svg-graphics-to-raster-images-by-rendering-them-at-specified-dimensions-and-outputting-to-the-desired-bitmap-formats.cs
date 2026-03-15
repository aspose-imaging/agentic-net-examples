using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public static class SvgRasterConverter
{
    /// <summary>
    /// Converts an SVG file to a raster image with the specified dimensions and format.
    /// </summary>
    /// <param name="inputSvgPath">Full path to the source SVG file.</param>
    /// <param name="outputPath">Full path for the rasterized output file (extension determines format).</param>
    /// <param name="targetWidth">Desired width of the output image in pixels.</param>
    /// <param name="targetHeight">Desired height of the output image in pixels.</param>
    public static void ConvertSvgToRaster(string inputSvgPath, string outputPath, int targetWidth, int targetHeight)
    {
        // Load the SVG image using the unified Image.Load method.
        using (Image image = Image.Load(inputSvgPath))
        {
            // Prepare rasterization options: set background, page size, and scaling.
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Background color for the rasterized image (optional, default is white).
                BackgroundColor = Color.White,
                // Define the output size. If one dimension is zero, aspect ratio is preserved.
                PageSize = new SizeF(targetWidth, targetHeight)
            };

            // Choose the appropriate raster image options based on the output file extension.
            ImageOptionsBase saveOptions;
            string ext = System.IO.Path.GetExtension(outputPath).ToLowerInvariant();

            if (ext == ".png")
            {
                var pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterizationOptions;
                saveOptions = pngOptions;
            }
            else if (ext == ".jpg" || ext == ".jpeg")
            {
                var jpegOptions = new JpegOptions();
                jpegOptions.VectorRasterizationOptions = rasterizationOptions;
                saveOptions = jpegOptions;
            }
            else if (ext == ".bmp")
            {
                var bmpOptions = new BmpOptions();
                bmpOptions.VectorRasterizationOptions = rasterizationOptions;
                saveOptions = bmpOptions;
            }
            else if (ext == ".gif")
            {
                var gifOptions = new GifOptions();
                gifOptions.VectorRasterizationOptions = rasterizationOptions;
                saveOptions = gifOptions;
            }
            else
            {
                throw new NotSupportedException($"Unsupported output format: {ext}");
            }

            // Save the rasterized image to the desired location.
            image.Save(outputPath, saveOptions);
        }
    }
}

// Example usage:
// SvgRasterConverter.ConvertSvgToRaster("C:\\Images\\example.svg", "C:\\Images\\output.png", 800, 600);