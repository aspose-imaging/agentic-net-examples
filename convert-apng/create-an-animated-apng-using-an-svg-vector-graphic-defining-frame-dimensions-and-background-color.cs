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
            string inputPath = "input.svg";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG vector graphic
            using (Image svgImage = Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;

                // Render SVG to a raster image (PNG in memory)
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, new PngOptions());
                    ms.Position = 0;
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Create APNG with desired frame size and background color
                        ApngOptions createOptions = new ApngOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            DefaultFrameTime = 100, // 100 ms per frame
                            ColorType = PngColorType.TruecolorWithAlpha
                        };

                        using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
                        {
                            apngImage.BackgroundColor = Color.White;
                            apngImage.RemoveAllFrames();

                            int totalFrames = 5;
                            for (int i = 0; i < totalFrames; i++)
                            {
                                // Add the same raster frame; adjust gamma for variation
                                apngImage.AddFrame(raster);
                                ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                                lastFrame.AdjustGamma(i);
                            }

                            // Save the APNG (output is already bound via FileCreateSource)
                            apngImage.Save();
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

/*
 * Real-World Use Cases:
 * 1. When a developer wants to convert a scalable SVG logo into a lightweight animated APNG banner with a white background for use on a website.
 * 2. When an e‑learning platform needs to generate frame‑by‑frame animations from vector illustrations by rendering SVG to raster frames and assembling them into an APNG with defined frame time.
 * 3. When a mobile app requires a high‑resolution animated icon created from an SVG asset, preserving transparency, setting explicit width and height, and applying a solid background color.
 * 4. When a marketing automation tool programmatically creates product showcase animations by loading SVG files, rasterizing them, and exporting a multi‑frame APNG with consistent frame dimensions.
 * 5. When a game UI designer needs to export vector‑based health‑bar animations as an APNG file, specifying background color and frame timing using C# and Aspose.Imaging.
 */