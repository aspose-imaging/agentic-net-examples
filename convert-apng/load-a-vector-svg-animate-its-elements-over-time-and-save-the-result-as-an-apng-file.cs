using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary rasterized PNG path
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");

            // Load SVG and rasterize to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG as a RasterImage
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                // Create APNG options
                var apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // 100 ms per frame
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create APNG image canvas
                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, raster.Width, raster.Height))
                {
                    apng.RemoveAllFrames();

                    int frameCount = 10;
                    for (int i = 0; i < frameCount; i++)
                    {
                        // Add the base raster frame
                        apng.AddFrame(raster);

                        // Adjust gamma to create a simple fade animation
                        ApngFrame lastFrame = (ApngFrame)apng.Pages[apng.PageCount - 1];
                        float gamma = (float)i / (frameCount - 1);
                        lastFrame.AdjustGamma(gamma);
                    }

                    // Save the APNG file
                    apng.Save();
                }
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}