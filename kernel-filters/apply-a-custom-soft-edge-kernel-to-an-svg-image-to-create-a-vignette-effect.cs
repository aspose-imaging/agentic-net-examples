using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Filters;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image from file
        using (var svgImage = new Aspose.Imaging.FileFormats.Svg.SvgImage(inputPath))
        {
            // Configure rasterization options – use the SVG's intrinsic size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = svgImage.Width,
                PageHeight = svgImage.Height,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Set PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize the SVG into a memory stream (PNG format)
            using (var ms = new MemoryStream())
            {
                svgImage.Save(ms, pngOptions);
                ms.Position = 0; // Reset stream for reading

                // Load the rasterized PNG as a RasterImage
                using (var rasterImage = (RasterImage)Image.Load(ms))
                {
                    // Create a soft‑edge vignette filter
                    var vignette = new VignetteFilter
                    {
                        // Radius (0‑1) defines how far the effect reaches from the centre
                        Radius = 0.5f,
                        // Amount (0‑1) defines the strength of the darkening
                        Amount = 0.8f,
                        // Colour of the vignette (typically black)
                        Color = Aspose.Imaging.Color.Black
                    };

                    // Apply the vignette filter to the raster image
                    ImageProcessor.Apply(rasterImage, vignette);

                    // Save the final image to the output path
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}