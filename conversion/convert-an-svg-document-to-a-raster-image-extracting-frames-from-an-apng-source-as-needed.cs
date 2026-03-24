using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string svgInputPath = @"C:\Images\sample.svg";
        string svgOutputPath = @"C:\Images\sample_converted.png";

        string apngInputPath = @"C:\Images\animation.apng";
        string apngFramesOutputDir = @"C:\Images\ApngFrames";

        // Validate SVG input file
        if (!File.Exists(svgInputPath))
        {
            Console.Error.WriteLine($"File not found: {svgInputPath}");
            return;
        }

        // Validate APNG input file
        if (!File.Exists(apngInputPath))
        {
            Console.Error.WriteLine($"File not found: {apngInputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));
        Directory.CreateDirectory(apngFramesOutputDir);

        // -------------------------------------------------
        // Convert SVG to raster PNG
        // -------------------------------------------------
        using (Image svgImage = Image.Load(svgInputPath))
        {
            // Prepare rasterization options for SVG
            var rasterOptions = new SvgRasterizationOptions
            {
                // Use the original image size
                PageSize = svgImage.Size
            };

            // Prepare PNG save options and attach rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save rasterized PNG
            svgImage.Save(svgOutputPath, pngOptions);
        }

        // -------------------------------------------------
        // Extract frames from APNG and save each as PNG
        // -------------------------------------------------
        using (ApngImage apngImage = (ApngImage)Image.Load(apngInputPath))
        {
            // Iterate over each frame (page) in the APNG
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Each page is a RasterImage representing a frame
                using (RasterImage frame = (RasterImage)apngImage.Pages[i])
                {
                    // Build output file name for the frame
                    string framePath = Path.Combine(apngFramesOutputDir, $"frame_{i:D4}.png");

                    // Save the frame as PNG using default options
                    frame.Save(framePath, new PngOptions());
                }
            }
        }
    }
}