using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;

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

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;

                // Rasterize SVG to a raster image in memory (PNG)
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = width,
                            PageHeight = height,
                            BackgroundColor = Color.White
                        }
                    };
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Animation settings
                    const int animationDuration = 2000; // total duration in ms
                    const int frameDuration = 100;      // each frame duration in ms
                    int numFrames = animationDuration / frameDuration;

                    // Create APNG with desired options
                    ApngOptions apngCreateOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        DefaultFrameTime = (uint)frameDuration,
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(apngCreateOptions, width, height))
                    {
                        apng.RemoveAllFrames();

                        for (int i = 0; i < numFrames; i++)
                        {
                            // Reload the base raster image for each frame
                            ms.Position = 0;
                            using (RasterImage frame = (RasterImage)Image.Load(ms))
                            {
                                // Compute rotation angle for this frame
                                float angle = (float)(360.0 * i / numFrames);
                                // Rotate the frame around its center
                                frame.Rotate(angle, true, Color.Transparent);
                                // Add the rotated frame to the APNG
                                apng.AddFrame(frame);
                            }
                        }

                        // Save the animated PNG
                        apng.Save();
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