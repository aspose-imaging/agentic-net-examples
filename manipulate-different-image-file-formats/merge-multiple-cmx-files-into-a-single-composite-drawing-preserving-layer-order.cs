// HOW-TO: Merge Multiple CMX Files into One PNG Preserving Layer Order in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CMX file paths
            string[] inputPaths = new[]
            {
                @"C:\Images\input1.cmx",
                @"C:\Images\input2.cmx",
                @"C:\Images\input3.cmx"
            };

            // Hardcoded output PNG path
            string outputPath = @"C:\Images\merged_output.png";

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // First pass: determine maximum canvas size
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (CmxImage cmx = (CmxImage)Image.Load(path))
                {
                    sizes.Add(cmx.Size);
                }
            }

            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create output source and PNG options
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = outputSource };

            // Create raster canvas bound to the output file
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Second pass: rasterize each CMX and merge onto canvas
                foreach (string path in inputPaths)
                {
                    using (CmxImage cmx = (CmxImage)Image.Load(path))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Rasterize CMX to PNG in memory
                            cmx.Save(ms, new PngOptions());
                            ms.Position = 0;

                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                // Merge raster onto canvas at (0,0)
                                Rectangle bounds = new Rectangle(0, 0, raster.Width, raster.Height);
                                canvas.SaveArgb32Pixels(bounds, raster.LoadArgb32Pixels(raster.Bounds));
                            }
                        }
                    }
                }

                // Save the composite image (already bound to output source)
                canvas.Save();
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
 * 1. When a CAD system exports separate CMX drawings for each component and you need to combine them into a single PNG for web preview while keeping the original layer stacking.
 * 2. When an automated reporting tool must generate a composite image from several CMX design files to embed in a PDF report without losing the order of visual elements.
 * 3. When a batch processing script has to consolidate multiple CMX pages into one high‑resolution PNG for archival or printing, ensuring the layers appear exactly as designed.
 * 4. When a GIS application receives individual CMX layers representing map features and you need to merge them into a single PNG overlay while preserving their drawing order.
 * 5. When a legacy workflow requires converting a series of CMX files into a single raster image for use in a mobile app, and the correct layer sequence is critical for proper display.
 */
