using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input SVG and output APNG paths
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

            // Load the SVG vector graphic
            using (Image svgImage = Image.Load(inputPath))
            {
                // Determine frame dimensions (use SVG size)
                int width = svgImage.Width;
                int height = svgImage.Height;

                // Create APNG options with desired frame time and color type
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // 100 ms per frame
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG image canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    // Remove the default empty frame
                    apngImage.RemoveAllFrames();

                    // Number of frames to generate
                    int frameCount = 5;

                    for (int i = 0; i < frameCount; i++)
                    {
                        // Create a raster canvas for the current frame
                        using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha
                        }, width, height))
                        {
                            // Draw background
                            Graphics graphics = new Graphics(canvas);
                            graphics.Clear(Color.White);

                            // Draw the SVG onto the canvas
                            graphics.DrawImage(svgImage, new Point(0, 0));

                            // Add the raster frame to the APNG
                            apngImage.AddFrame(canvas);
                        }
                    }

                    // Save the animated APNG
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a scalable SVG logo into a lightweight animated APNG for web banners, preserving vector quality while defining exact frame dimensions and background color.
 * 2. When building a cross‑platform mobile app that displays animated icons generated from SVG assets, the code can create APNG sequences with consistent frame timing and true‑color with alpha support.
 * 3. When an e‑learning platform wants to embed step‑by‑step illustrations where each step is a frame derived from an SVG diagram, this C# routine produces an APNG with precise frame size and background transparency.
 * 4. When a game developer requires animated UI elements, such as a rotating badge, and wants to generate the APNG frames programmatically from a single SVG source using Aspose.Imaging for .NET.
 * 5. When a marketing automation tool needs to batch‑process SVG graphics into animated APNG files with a uniform background color and fixed frame duration for email campaigns.
 */