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
    static void Main()
    {
        // Hardcoded input SVG and output APNG paths
        string svgPath = "input.svg";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(svgPath))
        {
            Console.Error.WriteLine($"File not found: {svgPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define desired rasterization resolutions (width, height)
        var resolutions = new List<(int width, int height)>
        {
            (200, 200),
            (400, 400),
            (600, 600)
        };

        // Load the SVG image once
        using (Image svgImage = Image.Load(svgPath))
        {
            // Create APNG options with the output source
            var source = new FileCreateSource(outputPath, false);
            var apngOptions = new ApngOptions
            {
                Source = source,
                DefaultFrameTime = 100 // 100 ms per frame
            };

            // Use the first resolution as canvas size for the APNG
            int canvasWidth = resolutions[0].width;
            int canvasHeight = resolutions[0].height;

            // Create the APNG canvas
            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, canvasWidth, canvasHeight))
            {
                // Remove the default empty frame
                apng.RemoveAllFrames();

                // Generate a frame for each resolution
                foreach (var res in resolutions)
                {
                    // Set up rasterization options for the current resolution
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = new Size(res.width, res.height)
                    };
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Rasterize SVG to a PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load the rasterized PNG as a RasterImage
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Ensure the frame matches the canvas size
                            if (raster.Width != canvasWidth || raster.Height != canvasHeight)
                            {
                                raster.Resize(canvasWidth, canvasHeight, ResizeType.NearestNeighbourResample);
                            }

                            // Add the raster image as a new frame
                            apng.AddFrame(raster);
                        }
                    }
                }

                // Save the compiled APNG
                apng.Save();
            }
        }
    }
}