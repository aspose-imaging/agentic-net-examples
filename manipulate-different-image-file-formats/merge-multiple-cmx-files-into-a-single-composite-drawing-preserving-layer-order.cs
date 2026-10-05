// HOW-TO: Merge Multiple CMX Files Into One PNG Preserving Layer Order In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            List<string> inputPaths = new List<string>
            {
                "input1.cmx",
                "input2.cmx",
                "input3.cmx"
            };
            string outputPath = "output.png";

            // Verify input files exist
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

            // Determine canvas size (maximum width and height among all CMX files)
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

            // Create output canvas bound to the output file
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outputSource };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Merge each CMX onto the canvas preserving order
                foreach (string path in inputPaths)
                {
                    using (CmxImage cmx = (CmxImage)Image.Load(path))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Render CMX to a temporary PNG in memory
                            PngOptions tempOptions = new PngOptions();
                            cmx.Save(ms, tempOptions);
                            ms.Position = 0;

                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                Rectangle bounds = new Rectangle(0, 0, raster.Width, raster.Height);
                                canvas.SaveArgb32Pixels(bounds, raster.LoadArgb32Pixels(raster.Bounds));
                            }
                        }
                    }
                }

                // Save the bound canvas
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
 * 1. When you need to combine several CMX vector drawings from different sources into a single raster image for printing or web display.
 * 2. When you want to create a composite blueprint by stacking CMX layers in their original order to maintain design hierarchy.
 * 3. When an automated pipeline must convert a collection of CMX files into one PNG thumbnail while preserving visual stacking.
 * 4. When a CAD integration tool has to merge multiple CMX components into a single image for reporting or documentation.
 * 5. When you need to generate a combined preview of multiple CMX diagrams without manually opening each file.
 */
