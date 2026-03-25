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

        // Load the SVG image
        using (Image svgImage = Image.Load(inputPath))
        {
            int width = svgImage.Width;
            int height = svgImage.Height;

            // Animation parameters
            const int animationDuration = 1000; // total duration in ms
            const int frameDuration = 100;      // each frame duration in ms
            int numFrames = animationDuration / frameDuration;

            // Create APNG options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)frameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
            {
                apngImage.RemoveAllFrames();

                for (int i = 0; i < numFrames; i++)
                {
                    // Rasterize the SVG to a raster image for the current frame
                    PngOptions pngOptions = new PngOptions();
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageWidth = width,
                        PageHeight = height,
                        BackgroundColor = Color.White
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage frameRaster = (RasterImage)Image.Load(ms))
                        {
                            // Add the raster frame to the APNG
                            apngImage.AddFrame(frameRaster);

                            // Adjust gamma to simulate a gradual fill color change
                            ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                            float gamma = (float)i / (numFrames - 1); // 0.0 to 1.0
                            lastFrame.AdjustGamma(gamma);
                        }
                    }
                }

                // Save the APNG animation
                apngImage.Save();
            }
        }
    }
}