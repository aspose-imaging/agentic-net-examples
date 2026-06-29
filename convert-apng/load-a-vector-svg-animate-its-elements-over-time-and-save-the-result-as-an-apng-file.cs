using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Bmp;
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
            // Load SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;

                // Prepare APNG creation options
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // 100 ms per frame
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    apng.RemoveAllFrames();

                    int frameCount = 10;
                    for (int i = 0; i < frameCount; i++)
                    {
                        // Create a blank canvas for the frame
                        using (RasterImage canvas = (RasterImage)Image.Create(
                            new BmpOptions { Source = new FileCreateSource(Path.GetTempFileName(), false) },
                            width, height))
                        {
                            // Clear canvas
                            Graphics graphics = new Graphics(canvas);
                            graphics.Clear(Color.Transparent);

                            // Rasterize SVG to a temporary raster image
                            using (MemoryStream ms = new MemoryStream())
                            {
                                PngOptions pngOptions = new PngOptions
                                {
                                    VectorRasterizationOptions = new SvgRasterizationOptions
                                    {
                                        PageWidth = width,
                                        PageHeight = height
                                    }
                                };
                                svgImage.Save(ms, pngOptions);
                                ms.Position = 0;

                                using (RasterImage rasterSvg = (RasterImage)Image.Load(ms))
                                {
                                    // Apply simple translation animation
                                    int offsetX = i * 10; // move 10 pixels per frame
                                    int offsetY = 0;

                                    graphics.DrawImage(rasterSvg, new Point(offsetX, offsetY));
                                }
                            }

                            // Add the composed frame to APNG
                            apng.AddFrame(canvas);
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
 * 1. When a developer wants to convert a vector logo in SVG format into an animated PNG (APNG) for use in web banners that require smooth frame‑by‑frame animation.
 * 2. When a game developer needs to programmatically animate SVG icons and export them as APNG sprites to reduce asset size while preserving transparency.
 * 3. When a marketing automation script must generate time‑based product showcase animations from SVG illustrations and save them as APNG files for email newsletters.
 * 4. When a desktop application needs to create animated status indicators by rasterizing SVG elements frame by frame and bundling them into an APNG with a custom frame delay.
 * 5. When a reporting tool has to embed animated vector diagrams into PDF reports by first converting the SVG to an APNG using C# and Aspose.Imaging.
 */