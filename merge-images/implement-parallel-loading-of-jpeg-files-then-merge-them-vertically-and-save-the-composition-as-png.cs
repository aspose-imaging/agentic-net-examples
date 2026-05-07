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
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");

            var loadedImages = new List<RasterImage>();
            var lockObj = new object();

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

            if (loadedImages.Count == 0)
            {
                Console.WriteLine("No images loaded.");
                return;
            }

            int maxWidth = loadedImages.Max(i => i.Width);
            int totalHeight = loadedImages.Sum(i => i.Height);

            string outputPath = Path.Combine(outputDirectory, "merged.png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, maxWidth, totalHeight))
            {
                int offsetY = 0;
                foreach (var img in loadedImages)
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
                canvas.Save();
            }

            foreach (var img in loadedImages)
            {
                img.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}