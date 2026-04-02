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
        // Hardcoded input JPEG file paths
        string[] inputPaths = new string[] { "input1.jpg", "input2.jpg", "input3.jpg" };

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate dimensions for the horizontal canvas
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Create a memory stream to hold the merged JPEG
        using (MemoryStream outputStream = new MemoryStream())
        {
            // Configure JPEG options with the stream as the source
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new StreamSource(outputStream, true),
                Quality = 90
            };

            // Create a bound JPEG canvas
            using (JpegImage canvas = new JpegImage(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the canvas to the bound stream
                canvas.Save();
            }

            // Reset stream position for further reading if needed
            outputStream.Position = 0;

            // Example: write the size of the merged image data
            Console.WriteLine($"Merged JPEG size in bytes: {outputStream.Length}");
        }
    }
}