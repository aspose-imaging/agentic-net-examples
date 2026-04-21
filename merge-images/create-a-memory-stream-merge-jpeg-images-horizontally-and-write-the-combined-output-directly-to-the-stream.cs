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
        try
        {
            // Hardcoded input JPEG file paths
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };

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
                    Source = new StreamSource(outputStream, true)
                };

                // Create a bound JPEG canvas
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

                    // Save the canvas to the bound stream
                    canvas.Save();
                }

                // At this point, outputStream contains the merged JPEG data
                // Example: write the stream to a file (optional)
                // Directory.CreateDirectory("Output");
                // File.WriteAllBytes("Output\\merged.jpg", outputStream.ToArray());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}