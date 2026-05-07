using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG files and output path
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "merged.jpg";
            int uniformWidth = 200; // Desired width for each image

            // Validate each input file exists
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

            // First pass: determine resized heights and collect sizes
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (var path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    int newHeight = img.Height * uniformWidth / img.Width;
                    sizes.Add(new Aspose.Imaging.Size(uniformWidth, newHeight));
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = uniformWidth * inputPaths.Length;
            int canvasHeight = 0;
            foreach (var sz in sizes)
            {
                if (sz.Height > canvasHeight)
                    canvasHeight = sz.Height;
            }

            // Create JPEG canvas bound to the output file
            FileCreateSource outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outSource, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;

                // Second pass: load, resize, and copy each image onto the canvas
                foreach (var path in inputPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                    {
                        int newHeight = img.Height * uniformWidth / img.Width;
                        img.Resize(uniformWidth, newHeight);

                        var bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));

                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas (output file)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}