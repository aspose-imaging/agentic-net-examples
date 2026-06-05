using System;
using System.IO;
using System.Collections.Generic;
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
            string inputSvgPath = "input.svg";
            string outputApngPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputApngPath) ?? ".");

            // Define rasterization sizes for each frame
            var frameSizes = new List<(int width, int height)>
            {
                (200, 200),
                (400, 400),
                (600, 600)
            };

            // Load the SVG vector image
            using (Image vectorImage = Image.Load(inputSvgPath))
            {
                // Prepare APNG creation options
                var apngCreateOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputApngPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 100 // default frame duration in ms
                };

                // Create APNG canvas using the size of the first frame
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    apngCreateOptions,
                    frameSizes[0].width,
                    frameSizes[0].height))
                {
                    // Remove the default initial frame
                    apngImage.RemoveAllFrames();

                    // Generate each frame at its specified resolution
                    foreach (var size in frameSizes)
                    {
                        // Configure PNG save options with SVG rasterization settings
                        var pngOptions = new PngOptions();
                        var rasterOptions = new SvgRasterizationOptions
                        {
                            PageWidth = size.width,
                            PageHeight = size.height
                        };
                        pngOptions.VectorRasterizationOptions = rasterOptions;

                        // Rasterize SVG to PNG in memory
                        using (var ms = new MemoryStream())
                        {
                            vectorImage.Save(ms, pngOptions);
                            ms.Position = 0;

                            // Load rasterized PNG as a RasterImage frame
                            using (RasterImage rasterFrame = (RasterImage)Image.Load(ms))
                            {
                                apngImage.AddFrame(rasterFrame);
                            }
                        }
                    }

                    // Save the compiled APNG
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