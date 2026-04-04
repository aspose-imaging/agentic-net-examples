using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image (vector source)
        using (Image svgImage = Image.Load(inputPath) as SvgImage)
        {
            if (svgImage == null)
            {
                Console.Error.WriteLine("Failed to load SVG image.");
                return;
            }

            // Configure vector rasterization options with smoothing (anti‑aliasing)
            VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
            {
                // Use the original SVG size
                PageSize = svgImage.Size,
                // Apply anti‑aliasing to improve smoothness
                SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                // Optional: set a background color if desired
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Prepare GIF save options and attach the rasterization settings
            GifOptions gifOptions = new GifOptions
            {
                VectorRasterizationOptions = rasterOptions,
                // Optional: enable interlaced GIF for progressive rendering
                Interlaced = true
            };

            // Save the rasterized result as a GIF file
            svgImage.Save(outputPath, gifOptions);
        }
    }
}