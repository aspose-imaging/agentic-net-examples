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
            // Hardcoded input and output paths
            string inputSvgPath = "input.svg";
            string outputApngPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputApngPath));

            // Load SVG as a raster image (Aspose.Imaging can rasterize SVG on load)
            using (RasterImage svgRaster = (RasterImage)Image.Load(inputSvgPath))
            {
                int width = svgRaster.Width;
                int height = svgRaster.Height;

                // Create APNG options
                Source fileSource = new FileCreateSource(outputApngPath, false);
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = fileSource,
                    DefaultFrameTime = 200, // 200 ms per frame
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create APNG canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    // Remove default frame
                    apngImage.RemoveAllFrames();

                    // Add multiple frames (same SVG raster for simplicity)
                    int frameCount = 5;
                    for (int i = 0; i < frameCount; i++)
                    {
                        apngImage.AddFrame(svgRaster);
                    }

                    // Save the animated APNG
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