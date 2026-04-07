using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = "image1.jpg";
        string inputPath2 = "image2.jpg";
        string inputPath3 = "image3.jpg";
        string outputPath = "merged.jpg";

        // Validate input files
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }
        if (!File.Exists(inputPath3))
        {
            Console.Error.WriteLine($"File not found: {inputPath3}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect image sizes
        var sizes = new List<Size>();
        try
        {
            using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
                sizes.Add(img1.Size);
            using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
                sizes.Add(img2.Size);
            using (RasterImage img3 = (RasterImage)Image.Load(inputPath3))
                sizes.Add(img3.Size);
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            Console.Error.WriteLine($"Error loading images: {ex.Message}");
            return;
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Create output source and JPEG options
        FileCreateSource source = new FileCreateSource(outputPath, false);
        JpegOptions options = new JpegOptions() { Source = source, Quality = 90 };

        // Merge images horizontally and save
        try
        {
            using (JpegImage canvas = (JpegImage)Image.Create(options, newWidth, newHeight))
            {
                int offsetX = 0;
                string[] inputPaths = new[] { inputPath1, inputPath2, inputPath3 };
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                // Save the bound image
                canvas.Save();
            }
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            Console.Error.WriteLine($"Error during merging or saving: {ex.Message}");
            return;
        }
    }
}