using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.svg";
            string tempRasterPath = "temp.png";
            string outputPath = "output.apng";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath) ?? ".");

            // Load SVG vector image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    }
                };
                svgImage.Save(tempRasterPath, pngOptions);
            }

            // Load rasterized PNG as source frame
            using (RasterImage sourceImage = (RasterImage)Image.Load(tempRasterPath))
            {
                // Create APNG options with output binding
                var createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 200, // 200 ms per frame
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create APNG image canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
                {
                    // Remove default frame
                    apngImage.RemoveAllFrames();

                    // Define number of frames
                    int frameCount = 5;

                    // Add frames (same image for simplicity)
                    for (int i = 0; i < frameCount; i++)
                    {
                        apngImage.AddFrame(sourceImage);
                    }

                    // Save the APNG (output already bound via FileCreateSource)
                    apngImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}