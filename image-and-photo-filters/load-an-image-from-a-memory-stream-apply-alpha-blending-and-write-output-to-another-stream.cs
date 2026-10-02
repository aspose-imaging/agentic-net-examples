// HOW-TO: Blend Red Overlay Onto JPEG Using Memory Streams In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] inputBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream inputStream = new MemoryStream(inputBytes))
            {
                using (RasterImage sourceImage = (RasterImage)Image.Load(inputStream))
                {
                    using (MemoryStream overlayStream = new MemoryStream())
                    {
                        BmpOptions bmpOptions = new BmpOptions
                        {
                            Source = new StreamSource(overlayStream)
                        };
                        using (RasterImage overlay = (RasterImage)Image.Create(bmpOptions, sourceImage.Width, sourceImage.Height))
                        {
                            Graphics graphics = new Graphics(overlay);
                            graphics.Clear(Aspose.Imaging.Color.Empty);
                            graphics.FillRectangle(new SolidBrush(Aspose.Imaging.Color.Red), new Rectangle(0, 0, overlay.Width, overlay.Height));

                            sourceImage.Blend(new Point(0, 0), overlay, 128);
                        }

                        using (MemoryStream outputStream = new MemoryStream())
                        {
                            PngOptions pngOptions = new PngOptions
                            {
                                Source = new StreamSource(outputStream)
                            };
                            sourceImage.Save(outputStream, pngOptions);
                            File.WriteAllBytes(outputPath, outputStream.ToArray());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to add a semi‑transparent red overlay to a JPEG that is loaded from a byte array and then save the result as a PNG in memory.
 * 2. When you want to perform alpha blending between a source image and a programmatically created bitmap without creating intermediate files on disk.
 * 3. When you are processing images received from a web service and must combine them with a colored mask before returning the data as a stream.
 * 4. When you are building a server‑side image conversion pipeline that converts uploaded JPEGs to PNGs with custom blending effects while keeping the entire workflow in memory.
 * 5. When you need to generate a PNG stream for further transmission (e.g., HTTP response) after applying a 50 % opacity blend of a red rectangle over the original image.
 */
