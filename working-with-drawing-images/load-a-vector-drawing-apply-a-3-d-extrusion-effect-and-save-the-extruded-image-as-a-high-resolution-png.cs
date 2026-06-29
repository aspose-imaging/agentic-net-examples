using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to high‑resolution PNG in memory
                PngOptions rasterOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size,
                        BackgroundColor = Color.White
                    }
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, rasterOptions);
                    ms.Position = 0;

                    // Load rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        int extrusionDepth = 20; // pixels
                        int canvasWidth = raster.Width + extrusionDepth;
                        int canvasHeight = raster.Height + extrusionDepth;

                        // Prepare output PNG canvas bound to file
                        PngOptions canvasOptions = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            ResolutionSettings = new ResolutionSetting(300, 300)
                        };

                        using (Image canvas = Image.Create(canvasOptions, canvasWidth, canvasHeight))
                        {
                            // Draw extrusion layers
                            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                            graphics.Clear(Color.White);

                            for (int offset = extrusionDepth; offset > 0; offset--)
                            {
                                graphics.DrawImage(raster, new Point(offset, offset));
                            }

                            // Draw the original image on top
                            graphics.DrawImage(raster, new Point(0, 0));

                            // Save the final image
                            canvas.Save();
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
 * 1. When a web application needs to convert user‑uploaded SVG logos into high‑resolution PNG thumbnails with a 3‑D extrusion for product catalogs.
 * 2. When an e‑learning platform wants to generate printable course materials by rasterizing SVG diagrams into 300 dpi PNG images with depth shading for a realistic look.
 * 3. When a marketing automation tool creates promotional banners that require SVG icons to be extruded and saved as high‑quality PNGs for email campaigns.
 * 4. When a desktop publishing software adds a “3‑D effect” button that transforms vector illustrations into embossed PNG assets for print‑ready PDFs.
 * 5. When a game development pipeline needs to turn SVG UI elements into high‑resolution PNG sprites with extrusion depth to simulate depth in 2‑D overlays.
 */