using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "merged_output.jpg";

            // Validate input files
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

            // First pass: collect sizes
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions (vertical merge with 10‑pixel padding)
            int padding = 10;
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height) + padding * (inputPaths.Length - 1);

            // Create JPEG canvas bound to the output file
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                // Fill background with white
                Graphics graphics = new Graphics(canvas);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                graphics.FillRectangle(whiteBrush, canvas.Bounds);

                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                        Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, pixels);
                        offsetY += img.Height + padding;
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
 * 1. When generating a printable photo album in a C# web application, a developer can use this code to vertically merge JPEG pages with a 10‑pixel white padding so each picture is visually separated on the final album page.
 * 2. When creating a multi‑page invoice PDF that includes scanned JPEG receipts, the code can combine the receipt images vertically with a 10‑pixel gap to improve readability before embedding the result into the PDF.
 * 3. When building an automated email newsletter that showcases product screenshots, a developer can merge the JPEG screenshots into a single image with a 10‑pixel padding to prevent the screenshots from touching each other.
 * 4. When preparing a dataset of vertically stacked JPEG samples for machine‑learning training, the padding ensures consistent spacing between images, making the merged image easier to annotate using Aspose.Imaging in C#.
 * 5. When developing a desktop utility that consolidates security camera snapshots taken at different times, the vertical merge with a 10‑pixel separator helps users quickly distinguish each snapshot in the combined JPEG output.
 */