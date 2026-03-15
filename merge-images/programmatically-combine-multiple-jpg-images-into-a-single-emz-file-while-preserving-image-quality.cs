using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect at least one input JPG and an output EMZ path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input1.jpg> [<input2.jpg> ...] <output.emz>");
            return;
        }

        string outputPath = args[args.Length - 1];
        string[] inputPaths = args.Take(args.Length - 1).ToArray();

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int totalWidth = sizes.Sum(s => s.Width);
        int maxHeight = sizes.Max(s => s.Height);

        // Temporary canvas file (JPEG) to hold merged raster image
        string tempCanvasPath = Path.Combine(Path.GetTempPath(), "merged_canvas.jpg");

        // Create JPEG canvas bound to the temporary file
        Source canvasSource = new FileCreateSource(tempCanvasPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = canvasSource, Quality = 100 };
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
        {
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
            // Save the bound canvas to the temporary file
            canvas.Save();
        }

        // Load the merged raster image and save it as compressed EMZ
        using (Image merged = Image.Load(tempCanvasPath))
        {
            EmfOptions emfOptions = new EmfOptions() { Compress = true };
            var vectorOptions = new EmfRasterizationOptions() { PageSize = merged.Size };
            emfOptions.VectorRasterizationOptions = vectorOptions;
            merged.Save(outputPath, emfOptions);
        }

        // Clean up temporary canvas file
        if (File.Exists(tempCanvasPath))
        {
            File.Delete(tempCanvasPath);
        }
    }
}