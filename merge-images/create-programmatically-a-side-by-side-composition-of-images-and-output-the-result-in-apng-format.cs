using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string[] inputPaths = { "input1.png", "input2.png", "input3.png" };
        string outputPath = "output.apng";

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

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal composition
        int totalWidth = sizes.Sum(s => s.Width);
        int maxHeight = sizes.Max(s => s.Height);

        // Create a temporary raster canvas to hold the merged image
        string tempCanvasPath = Path.GetTempFileName();
        Source tempSource = new FileCreateSource(tempCanvasPath, false);
        PngOptions tempOptions = new PngOptions { Source = tempSource };
        using (RasterImage canvas = (RasterImage)Image.Create(tempOptions, totalWidth, maxHeight))
        {
            // Merge input images side by side onto the canvas
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Prepare APNG options
            Source outputSource = new FileCreateSource(outputPath, false);
            ApngOptions apngOptions = new ApngOptions
            {
                Source = outputSource,
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 1000 // 1 second per frame (single frame)
            };

            // Create APNG image and add the merged canvas as the sole frame
            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, totalWidth, maxHeight))
            {
                apng.RemoveAllFrames();
                apng.AddFrame(canvas);
                apng.Save();
            }
        }

        // Cleanup temporary canvas file
        try { File.Delete(tempCanvasPath); } catch { }
    }
}