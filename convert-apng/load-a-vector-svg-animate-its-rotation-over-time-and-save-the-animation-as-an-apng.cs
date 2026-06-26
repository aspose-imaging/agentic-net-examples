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
            string inputPath = "input.svg";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    apngImage.RemoveAllFrames();

                    int frameCount = 36;
                    for (int i = 0; i < frameCount; i++)
                    {
                        float angle = i * 360f / frameCount;

                        using (MemoryStream ms = new MemoryStream())
                        {
                            PngOptions pngOptions = new PngOptions
                            {
                                VectorRasterizationOptions = new SvgRasterizationOptions
                                {
                                    PageWidth = width,
                                    PageHeight = height,
                                    BackgroundColor = Color.Transparent
                                }
                            };
                            vectorImage.Save(ms, pngOptions);
                            ms.Position = 0;

                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                raster.Rotate(angle, true, Color.Transparent);
                                apngImage.AddFrame(raster);
                            }
                        }
                    }

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
 * 1. When a developer wants to turn a scalable vector logo (SVG) into a rotating animated PNG (APNG) for use on a website’s loading screen, they can use this code to rasterize each frame and export the animation.
 * 2. When an e‑learning platform needs to display a rotating diagram that scales without loss of quality across devices, the code lets them generate an APNG from an SVG with precise frame timing.
 * 3. When a mobile app requires a lightweight, transparent‑background loading spinner created from a vector asset, this snippet shows how to produce a 36‑frame APNG using Aspose.Imaging in C#.
 * 4. When a marketing team wants to embed a rotating product illustration in an email newsletter without relying on JavaScript, developers can use this example to convert the SVG into an animated PNG that most email clients support.
 * 5. When a game developer needs to pre‑render a rotating SVG sprite sheet as an APNG for UI animations, the code demonstrates how to rasterize each rotation angle and assemble the frames with Aspose.Imaging.
 */