using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG file paths
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output PNG path
        string outputPath = "merged_output.png";

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

        // Load images in parallel
        List<RasterImage> loadedImages = new List<RasterImage>();
        System.Threading.Tasks.Parallel.ForEach(inputPaths, path =>
        {
            RasterImage img = (RasterImage)Image.Load(path);
            lock (loadedImages)
            {
                loadedImages.Add(img);
            }
        });

        // Calculate canvas size for vertical merge
        int canvasWidth = loadedImages.Max(img => img.Width);
        int canvasHeight = loadedImages.Sum(img => img.Height);

        // Prepare PNG options with bound source
        Source pngSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = pngSource };

        // Create canvas and merge images vertically
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (RasterImage img in loadedImages)
            {
                Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                offsetY += img.Height;
            }

            // Save the bound canvas (no need to specify path again)
            canvas.Save();
        }

        // Dispose loaded images
        foreach (RasterImage img in loadedImages)
        {
            img.Dispose();
        }
    }
}