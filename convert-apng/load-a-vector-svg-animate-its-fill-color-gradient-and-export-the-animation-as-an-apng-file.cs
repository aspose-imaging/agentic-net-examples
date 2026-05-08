using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
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
            string inputPath = "input.svg";
            string outputPath = "output.apng";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG vector image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to a PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, new PngOptions());
                    ms.Position = 0;

                    // Load rasterized image
                    using (RasterImage baseRaster = (RasterImage)Image.Load(ms))
                    {
                        // Animation parameters
                        const int totalFrames = 10;
                        const uint frameDuration = 100; // milliseconds per frame

                        // Create APNG with bound output file
                        ApngOptions createOptions = new ApngOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            DefaultFrameTime = frameDuration,
                            ColorType = PngColorType.TruecolorWithAlpha
                        };

                        using (ApngImage apng = (ApngImage)Image.Create(createOptions, baseRaster.Width, baseRaster.Height))
                        {
                            // Remove the default single frame
                            apng.RemoveAllFrames();

                            // Add frames with varying gamma to simulate fill color animation
                            for (int i = 0; i < totalFrames; i++)
                            {
                                apng.AddFrame(baseRaster);
                                ApngFrame lastFrame = (ApngFrame)apng.Pages[apng.PageCount - 1];
                                float gamma = (float)i / totalFrames; // 0.0 to 0.9
                                lastFrame.AdjustGamma(gamma);
                            }

                            // Save the APNG (output is already bound via FileCreateSource)
                            apng.Save();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}