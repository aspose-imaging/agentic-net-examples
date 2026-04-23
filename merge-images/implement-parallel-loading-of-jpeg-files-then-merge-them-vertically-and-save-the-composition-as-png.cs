using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG file paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hardcoded output PNG path
            string outputPath = "output.png";

            // Validate input files
            foreach (var path in inputPaths)
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
            List<RasterImage> images = new List<RasterImage>();
            System.Threading.Tasks.Parallel.ForEach(inputPaths, path =>
            {
                var img = (RasterImage)Image.Load(path);
                lock (images)
                {
                    images.Add(img);
                }
            });

            // Calculate canvas size for vertical merge
            int canvasWidth = images.Max(img => img.Width);
            int canvasHeight = images.Sum(img => img.Height);

            // Create PNG canvas bound to the output file
            Source source = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = source };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (var img in images)
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
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}