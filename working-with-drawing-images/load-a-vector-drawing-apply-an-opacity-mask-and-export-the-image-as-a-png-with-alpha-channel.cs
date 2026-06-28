using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Export options for PNG with alpha channel
            PngOptions exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Create a manual mask (example: an ellipse covering part of the image)
            GraphicsPath manualMask = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(0, 0, 200, 200)));
            manualMask.AddFigure(figure);

            ManualMaskingArgs maskArgs = new ManualMaskingArgs
            {
                Mask = manualMask
            };

            // Configure masking options
            MaskingOptions maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.Manual,
                Decompose = false,
                Args = maskArgs,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Load the vector drawing as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Perform masking
                using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
                {
                    // Retrieve the masked image (foreground)
                    using (RasterImage resultImage = (RasterImage)maskingResult[1].GetImage())
                    {
                        // Save the result as PNG with alpha channel
                        resultImage.Save(outputPath, exportOptions);
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
 * 1. When generating product thumbnails where only a circular portion of an SVG logo should be visible over a transparent background, a developer can load the SVG, apply an elliptical opacity mask, and save it as a PNG with an alpha channel.
 * 2. When creating custom map overlays that require masking out water bodies from a vector map before compositing onto a web map, the code can load the SVG, apply a manual mask, and export a PNG with transparency.
 * 3. When preparing UI icons that need a soft‑edge fade effect, a developer can load the vector icon, define an opacity mask shape, and output a PNG with truecolor and alpha for high‑DPI displays.
 * 4. When building a reporting tool that embeds company logos with a rounded‑corner mask into PDF reports, the code can rasterize the SVG, apply the mask, and produce a PNG with transparent corners.
 * 5. When automating the generation of watermark‑ready images where a logo must appear only within a specific elliptical region, the developer can use this code to mask the SVG and export a PNG that preserves the alpha channel for later compositing.
 */