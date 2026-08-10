// HOW-TO: Create Rotating SVG Animation and Save as APNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image svgImg = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)svgImg;
                int width = svgImage.Width;
                int height = svgImage.Height;

                // Animation parameters
                const int animationDurationMs = 2000; // total duration
                const int frameDurationMs = 100;      // per frame
                int frameCount = animationDurationMs / frameDurationMs;

                // Prepare APNG creation options
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = (uint)frameDurationMs,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    apng.RemoveAllFrames();

                    // Vector rasterization options for rendering SVG onto raster frames
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = new Size(width, height)
                    };

                    for (int i = 0; i < frameCount; i++)
                    {
                        float angle = (float)(360.0 * i / frameCount);

                        // Create a raster canvas for the current frame
                        PngOptions pngOpts = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        using (RasterImage frame = (RasterImage)Image.Create(pngOpts, width, height))
                        {
                            // Draw the SVG onto the raster canvas
                            Graphics graphics = new Graphics(frame);
                            graphics.Clear(Color.Transparent);
                            graphics.DrawImage(svgImage, new Point(0, 0));

                            // Rotate the raster image
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
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to turn a static SVG logo into a rotating animated PNG for web banners.
 * 2. When you want to generate a lightweight APNG sprite from vector graphics for mobile app UI animations.
 * 3. When you must programmatically create frame‑by‑frame rotation of an SVG diagram for an instructional tutorial.
 * 4. When you require server‑side rendering of vector icons into an animated PNG with precise frame timing using C#.
 * 5. When you are building a reporting tool that outputs rotating SVG charts as APNG files for cross‑browser compatibility.
 */
