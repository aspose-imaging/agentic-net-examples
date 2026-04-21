using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };
        string outputPath = "output/merged.jpg";

        try
        {
            // Validate each input file
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
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for vertical merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (var sz in sizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                canvasHeight += sz.Height;
            }

            // Create JPEG canvas with bound source
            FileCreateSource src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                for (int i = 0; i < inputPaths.Length; i++)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPaths[i]))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }

                    // Log progress percentage after each image is added
                    int percent = (i + 1) * 100 / inputPaths.Length;
                    Console.WriteLine($"Progress: {percent}%");
                }

                // Save the bound canvas (source already set)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}