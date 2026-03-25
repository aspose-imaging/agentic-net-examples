using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image svgImage = Image.Load(inputPath))
        {
            // Rasterize the SVG to a PNG stored in memory
            using (MemoryStream pngStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    // Enable vector rasterization so the SVG is rendered to raster pixels
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    }
                };
                svgImage.Save(pngStream, pngOptions);
                pngStream.Position = 0;

                // Load the rasterized PNG as a RasterImage (used as a frame source)
                using (RasterImage rasterSource = (RasterImage)Image.Load(pngStream))
                {
                    // APNG creation options
                    var apngCreateOptions = new ApngOptions
                    {
                        DefaultFrameTime = 100, // 100 ms per frame
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    // Create an empty APNG image with the same dimensions as the raster source
                    using (ApngImage apng = (ApngImage)Image.Create(apngCreateOptions, rasterSource.Width, rasterSource.Height))
                    {
                        // Remove the default single frame
                        apng.RemoveAllFrames();

                        const int totalFrames = 10;

                        // Add frames, adjusting gamma to illustrate animation changes
                        for (int i = 0; i < totalFrames; i++)
                        {
                            apng.AddFrame(rasterSource);
                            ApngFrame lastFrame = (ApngFrame)apng.Pages[apng.PageCount - 1];
                            // Simple animation effect: gradually change gamma
                            lastFrame.AdjustGamma(i);
                        }

                        // Save the animated PNG
                        apng.Save(outputPath);
                    }
                }
            }
        }
    }
}