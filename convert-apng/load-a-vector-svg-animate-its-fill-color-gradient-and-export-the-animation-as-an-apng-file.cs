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
        try
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

            // Load the SVG vector image
            using (Image svgImage = Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;

                // Prepare APNG creation options
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100 // 100 ms per frame
                };

                // Create the APNG image bound to the output file
                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    // Remove the default empty frame
                    apng.RemoveAllFrames();

                    int frameCount = 10;
                    for (int i = 0; i < frameCount; i++)
                    {
                        // Compute a gradient color (from red to blue)
                        int red = 255 - (i * 255 / (frameCount - 1));
                        int blue = i * 255 / (frameCount - 1);
                        Aspose.Imaging.Color gradientColor = Aspose.Imaging.Color.FromArgb(255, red, 0, blue);

                        // Set up rasterization options with the gradient background
                        var rasterOptions = new SvgRasterizationOptions
                        {
                            PageWidth = width,
                            PageHeight = height,
                            BackgroundColor = gradientColor
                        };

                        // Render SVG to a raster image in memory
                        using (MemoryStream ms = new MemoryStream())
                        {
                            var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                            svgImage.Save(ms, pngOptions);
                            ms.Position = 0;

                            using (RasterImage frame = (RasterImage)Image.Load(ms))
                            {
                                // Add the rendered frame to the APNG
                                apng.AddFrame(frame);
                            }
                        }
                    }

                    // Save the APNG file (output is already bound via FileCreateSource)
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
 * 1. When a developer wants to create a lightweight animated logo for a website by transitioning the SVG’s fill color from red to blue and delivering it as an APNG to ensure broad browser compatibility.
 * 2. When an e‑learning platform needs to generate dynamic illustration sequences where a vector diagram’s color gradient changes over time, using C# and Aspose.Imaging to convert the SVG frames into an animated PNG.
 * 3. When a mobile app requires a high‑resolution, scalable icon that animates its background gradient without relying on JavaScript, the code can load the SVG, animate the fill, and export an APNG for offline use.
 * 4. When a marketing automation tool must produce personalized product badges that cycle through brand colors, developers can programmatically adjust the SVG fill gradient and save the result as an APNG for email campaigns.
 * 5. When a data‑visualization dashboard wants to illustrate trend progression by smoothly shifting a vector chart’s color scheme, the C# snippet can animate the SVG fill and output an APNG for embedding in reports.
 */