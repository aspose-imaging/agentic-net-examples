using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG file paths
            string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };

            // Validate each input file exists
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

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create a memory stream to hold the merged JPEG
            using (MemoryStream outputStream = new MemoryStream())
            {
                // Configure JPEG options with the stream as the source
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new StreamSource(outputStream, false)
                };

                // Create a JPEG canvas bound to the memory stream
                using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
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

                    // Save the bound image to the stream
                    canvas.Save();
                }

                // Output the size of the combined image in bytes
                Console.WriteLine($"Combined image size (bytes): {outputStream.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}