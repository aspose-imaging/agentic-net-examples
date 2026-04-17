using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Drawing;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG and output APNG paths
        string inputPath = @"C:\Images\vector_graphic.svg";
        string outputPath = @"C:\Images\animated_output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG as a raster image (Aspose.Imaging can rasterize SVG on load)
        using (RasterImage svgRaster = (RasterImage)Image.Load(inputPath))
        {
            // Define frame duration (in milliseconds) and total animation length
            const int frameDuration = 100; // 100 ms per frame
            const int totalFrames = 10;    // 10 frames animation

            // Prepare APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                // Destination file creation source
                Source = new FileCreateSource(outputPath, false),
                // Default duration for each frame
                DefaultFrameTime = (uint)frameDuration,
                // Use truecolor with alpha for full color support
                ColorType = PngColorType.TruecolorWithAlpha,
                // Optional: set background color for the whole animation
                BackgroundColor = Color.LightGray,
                // Enable background color usage
                HasBackgroundColor = true
            };

            // Create the APNG image with the same dimensions as the SVG raster
            using (ApngImage apng = (ApngImage)Image.Create(createOptions, svgRaster.Width, svgRaster.Height))
            {
                // Remove the default single frame that exists after creation
                apng.RemoveAllFrames();

                // Add frames – for demonstration we reuse the same raster and modify gamma to create variation
                for (int i = 0; i < totalFrames; i++)
                {
                    // Add a copy of the SVG raster as a new frame
                    apng.AddFrame(svgRaster);

                    // Retrieve the frame just added
                    ApngFrame frame = (ApngFrame)apng.Pages[apng.PageCount - 1];

                    // Adjust gamma to create a simple visual effect across frames
                    float gamma = 0.5f + (i * 0.1f);
                    frame.AdjustGamma(gamma);
                }

                // Save the animated PNG to the specified output path
                apng.Save();
            }
        }
    }
}