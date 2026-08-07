using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Svg;
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

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;

                // Create APNG options and bind to output file
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // 100 ms per frame
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG image canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    apngImage.RemoveAllFrames();

                    int frameCount = 20;
                    int offsetStep = width / frameCount;

                    for (int i = 0; i < frameCount; i++)
                    {
                        // Create a raster frame
                        using (RasterImage frame = (RasterImage)Image.Create(new PngOptions { ColorType = PngColorType.TruecolorWithAlpha }, width, height))
                        {
                            // Draw the SVG onto the raster frame with a horizontal offset
                            Graphics graphics = new Graphics(frame);
                            graphics.Clear(Color.Transparent);
                            int offsetX = i * offsetStep;
                            graphics.DrawImage(svgImage, new Point(offsetX, 0));

                            // Add the raster frame to the APNG
                            apngImage.AddFrame(frame);
                        }
                    }

                    // Save the APNG (output path already bound via Source)
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
 * 1. When a developer needs to turn a vector SVG illustration into a looping animated PNG for a website banner, this C# code animates the SVG elements frame‑by‑frame and saves the result as an APNG file.
 * 2. When a mobile app requires lightweight, high‑quality animated icons derived from SVG assets, the code rasterizes each animation step and outputs a true‑color APNG compatible with iOS and Android.
 * 3. When an e‑learning platform wants to embed scalable graphics with motion (e.g., moving arrows or highlights) into course slides, the code converts the SVG into a time‑based APNG that preserves transparency.
 * 4. When a game developer wants to generate animated sprite sheets from SVG artwork on the fly, this snippet creates individual raster frames and compiles them into a single APNG for efficient rendering.
 * 5. When a marketing automation tool must programmatically produce personalized animated greetings from SVG templates, the code animates the vector elements and exports a ready‑to‑use APNG for email campaigns.
 */