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
            // Hardcoded input and output paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
            string outputPath = "merged_with_border.jpg";

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            const int border = 5;

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions with border
            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);
            int canvasWidth = totalWidth + 2 * border;
            int canvasHeight = maxHeight + 2 * border;

            // Create JPEG canvas bound to the output file
            Source fileSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = fileSource, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = border;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle destRect = new Rectangle(offsetX, border, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound image
                canvas.Save();
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
 * 1. When a developer needs to create a product catalog thumbnail that combines several JPEG product photos side‑by‑side and adds a consistent 5‑pixel border for visual separation, this code automates the merge and border addition using Aspose.Imaging for .NET.
 * 2. When generating a social‑media collage of event snapshots in C#, the code merges the JPEG images horizontally and applies a uniform border to ensure the final image meets platform layout guidelines.
 * 3. When building an automated report generator that stitches together chart images into a single JPEG banner, the developer can use this snippet to align the charts, add a 5‑pixel border, and save the result with high quality.
 * 4. When preparing a printable banner that combines multiple advertisement JPEGs, the code provides a quick way to merge the images, pad them with a border for bleed, and output a ready‑to‑print file.
 * 5. When creating a web‑gallery preview that displays a series of JPEG thumbnails in a single row with a subtle border to improve readability, this example shows how to perform the merge and border rendering in a C# application.
 */