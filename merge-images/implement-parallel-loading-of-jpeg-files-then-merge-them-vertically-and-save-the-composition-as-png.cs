using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputDirectory = "Input";
        string outputPath = "Output\\merged.png";

        // Validate input directory
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Get JPEG files
        string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
        if (files.Length == 0)
        {
            Console.WriteLine("No JPEG files found.");
            return;
        }

        // Load images in parallel
        var loadedImages = new List<RasterImage>();
        object lockObj = new object();

        System.Threading.Tasks.Parallel.ForEach(files, filePath =>
        {
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            var img = (RasterImage)Image.Load(filePath);
            lock (lockObj)
            {
                loadedImages.Add(img);
            }
        });

        // Calculate canvas size for vertical merge
        int canvasWidth = loadedImages.Max(img => img.Width);
        int canvasHeight = loadedImages.Sum(img => img.Height);

        // Create PNG canvas
        Source outSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = outSource };

        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (var img in loadedImages)
            {
                var bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                offsetY += img.Height;
                img.Dispose();
            }

            // Save the merged image
            canvas.Save();
        }
    }
}