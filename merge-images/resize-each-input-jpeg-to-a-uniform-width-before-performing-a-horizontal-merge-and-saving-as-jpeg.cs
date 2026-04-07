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
        string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
        string outputPath = "output.jpg";
        int uniformWidth = 200; // Desired width for each image

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

        // First pass: calculate resized heights and collect sizes
        List<Size> resizedSizes = new List<Size>();
        foreach (var path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                int newHeight = img.Height * uniformWidth / img.Width;
                resizedSizes.Add(new Size(uniformWidth, newHeight));
            }
        }

        // Determine canvas dimensions
        int totalWidth = resizedSizes.Sum(s => s.Width);
        int maxHeight = resizedSizes.Max(s => s.Height);

        // Create JPEG canvas bound to the output file
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 90 };
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string path = inputPaths[i];
                Size targetSize = resizedSizes[i];

                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    img.Resize(targetSize.Width, targetSize.Height, ResizeType.NearestNeighbourResample);
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas
            canvas.Save();
        }
    }
}