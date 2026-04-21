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
    static void Main()
    {
        // Hardcoded input JPEG file paths
        string[] inputPaths = new[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output path
        string outputPath = "output/merged.jpg";

        // Ensure all input files exist
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

        // Desired uniform width for each image
        int uniformWidth = 200;

        // First pass: calculate resized dimensions
        List<Aspose.Imaging.Size> resizedSizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                int newHeight = img.Height * uniformWidth / img.Width;
                resizedSizes.Add(new Aspose.Imaging.Size(uniformWidth, newHeight));
            }
        }

        // Determine canvas size for horizontal merge
        int canvasWidth = resizedSizes.Sum(s => s.Width);
        int canvasHeight = resizedSizes.Max(s => s.Height);

        // Prepare JPEG options with bound source
        Source fileSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = fileSource,
            Quality = 90
        };

        // Create bound JPEG canvas
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string path = inputPaths[i];
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Resize to uniform width while preserving aspect ratio
                    int newHeight = img.Height * uniformWidth / img.Width;
                    img.Resize(uniformWidth, newHeight);

                    // Copy pixels onto canvas at the current offset
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));

                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (output file already bound via source)
            canvas.Save();
        }
    }
}