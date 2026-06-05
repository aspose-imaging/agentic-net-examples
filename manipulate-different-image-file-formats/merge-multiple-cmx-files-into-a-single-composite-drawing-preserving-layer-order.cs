using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CMX files and output PNG file
            string[] inputPaths = new[] { "input1.cmx", "input2.cmx", "input3.cmx" };
            string outputPath = "output.png";

            // Validate input files
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

            // Collect sizes of all CMX images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string inputPath in inputPaths)
            {
                using (CmxImage cmx = (CmxImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    sizes.Add(new Aspose.Imaging.Size(cmx.Width, cmx.Height));
                }
            }

            // Determine canvas size (maximum width and height)
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (var sz in sizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                if (sz.Height > canvasHeight) canvasHeight = sz.Height;
            }

            // Create temporary raster images from each CMX
            List<string> tempRasterPaths = new List<string>();
            foreach (string inputPath in inputPaths)
            {
                using (CmxImage cmx = (CmxImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

                    // Options for rasterizing CMX to PNG
                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(tempPath, false),
                        VectorRasterizationOptions = new CmxRasterizationOptions()
                    };

                    cmx.Save(tempPath, pngOptions);
                    tempRasterPaths.Add(tempPath);
                }
            }

            // Create the output canvas (PNG)
            FileCreateSource canvasSource = new FileCreateSource(outputPath, false);
            PngOptions canvasOptions = new PngOptions { Source = canvasSource };
            using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(canvasOptions, canvasWidth, canvasHeight))
            {
                // Merge each rasterized CMX onto the canvas preserving order
                foreach (string rasterPath in tempRasterPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(rasterPath))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    }
                }

                // Save the final composite image
                canvas.Save();
            }

            // Clean up temporary raster files
            foreach (string tempPath in tempRasterPaths)
            {
                try { File.Delete(tempPath); } catch { }
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
 * 1. When a CAD workflow requires merging several CorelDRAW CMX files into one composite PNG while preserving the original layer stacking order.
 * 2. When an automated report generator needs to combine multiple CMX drawings of different dimensions into a single raster image for web preview.
 * 3. When a batch processing script must validate the existence of CMX source files, calculate the maximum canvas size, and rasterize each file before compositing them.
 * 4. When a .NET application has to create a temporary raster representation of each CMX, overlay them in the correct sequence, and export the final image as a PNG for archival.
 * 5. When a graphics pipeline needs to ensure the output directory exists, handle file‑system errors, and produce a single PNG that reflects the combined layers of multiple CMX inputs.
 */