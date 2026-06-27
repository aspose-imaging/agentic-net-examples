using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CMX files and output path
            string[] inputPaths = new[] { "input1.cmx", "input2.cmx", "input3.cmx" };
            string outputPath = "output.png";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first CMX to determine canvas size
            using (CmxImage firstCmx = (CmxImage)Image.Load(inputPaths[0]))
            {
                int canvasWidth = firstCmx.Width;
                int canvasHeight = firstCmx.Height;

                // Create a raster canvas bound to the output file
                Source canvasSource = new FileCreateSource(outputPath, false);
                PngOptions canvasOptions = new PngOptions() { Source = canvasSource };
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
                {
                    // Merge each CMX onto the canvas preserving order
                    foreach (string cmxPath in inputPaths)
                    {
                        using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
                        {
                            // Rasterize CMX to a memory stream as PNG
                            using (MemoryStream ms = new MemoryStream())
                            {
                                cmx.Save(ms, new PngOptions());
                                ms.Position = 0;

                                // Load rasterized image
                                using (RasterImage raster = (RasterImage)Image.Load(ms))
                                {
                                    // Copy raster pixels onto the canvas at (0,0)
                                    Rectangle bounds = new Rectangle(0, 0, raster.Width, raster.Height);
                                    canvas.SaveArgb32Pixels(bounds, raster.LoadArgb32Pixels(raster.Bounds));
                                }
                            }
                        }
                    }

                    // Save the composite image
                    canvas.Save();
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
 * 1. When a CAD system exports multiple CMX vector drawings that need to be combined into a single PNG preview while preserving the original layer stacking order.
 * 2. When an engineering workflow requires merging separate component diagrams stored as CMX files into one composite image for inclusion in a PDF report.
 * 3. When a GIS application must overlay several CMX map layers and export the result as a raster PNG for web display.
 * 4. When a manufacturing process needs to concatenate sequential CMX schematics into a single high‑resolution PNG for quality‑control documentation.
 * 5. When a software tool automates the creation of a composite thumbnail by rasterizing and stacking multiple CMX files in C# before saving to disk.
 */