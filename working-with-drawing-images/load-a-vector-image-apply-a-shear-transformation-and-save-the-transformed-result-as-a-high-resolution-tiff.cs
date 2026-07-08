using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG vector image
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (MemoryStream pngStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = vectorImage.Size
                        }
                    };
                    vectorImage.Save(pngStream, pngOptions);
                    pngStream.Position = 0;

                    // Load the rasterized PNG
                    using (RasterImage raster = (RasterImage)Image.Load(pngStream))
                    {
                        // Prepare TIFF save options with high resolution
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            ResolutionSettings = new ResolutionSetting(300, 300)
                        };

                        // Create a TIFF canvas
                        using (Image tiffCanvas = Image.Create(tiffOptions, raster.Width, raster.Height))
                        {
                            // Apply shear transformation using a matrix
                            var shearMatrix = new Matrix(1, 0.5f, 0, 1, 0, 0); // shearY = 0.5
                            var graphics = new Graphics(tiffCanvas);
                            graphics.Transform = shearMatrix;

                            // Draw the raster image onto the canvas
                            graphics.DrawImage(raster, new Point(0, 0));

                            // Save the transformed image as TIFF
                            tiffCanvas.Save(outputPath, tiffOptions);
                        }
                    }
                }
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
 * 1. When a developer needs to convert an SVG logo into a print‑ready 300 dpi TIFF while applying a shear distortion to simulate a perspective effect for marketing materials.
 * 2. When an engineering application must transform vector schematics (SVG) with a shear matrix and export them as high‑resolution TIFF files for inclusion in technical documentation.
 * 3. When a GIS system requires rasterizing and shearing vector map overlays before saving them as TIFF images with precise resolution settings for satellite image analysis.
 * 4. When an e‑learning platform wants to generate skewed, high‑quality TIFF screenshots from SVG diagrams for use in printable course handouts.
 * 5. When a digital archiving tool needs to preserve vector artwork by applying a shear transformation and storing the result as a lossless, high‑resolution TIFF for long‑term storage.
 */