using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputDirectory = "InputImages";
        string outputPath = "Output/merged.jpg";

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Get JPEG files from the input directory
        string[] imagePaths = Directory.GetFiles(inputDirectory, "*.jpg");
        imagePaths = imagePaths.Concat(Directory.GetFiles(inputDirectory, "*.jpeg")).ToArray();

        if (imagePaths.Length == 0)
        {
            Console.WriteLine("No JPEG files found in the input directory.");
            return;
        }

        // Validate each input file exists and collect sizes
        List<Size> sizes = new List<Size>();
        foreach (string path in imagePaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }

            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Prepare JPEG options with bound source
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = new FileCreateSource(outputPath, false),
            Quality = 100
        };

        // Create a bound JPEG canvas
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound image (output path already set in options)
            canvas.Save();
        }
    }
}