// HOW-TO: Cancel Long Running Horizontal JPEG Merge With CancellationToken In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
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
            string inputDirectory = "InputImages";
            string outputPath = "Output/merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare cancellation token
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
                Console.WriteLine("Cancellation requested.");
            };

            // Get JPEG files
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            if (imageFiles.Length == 0)
            {
                Console.Error.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Collect sizes
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string file in imageFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    sizes.Add(img.Size);
                }

                if (cts.Token.IsCancellationRequested)
                {
                    Console.WriteLine("Operation cancelled before size calculation.");
                    return;
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            // Create JPEG canvas
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string file in imageFiles)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("Operation cancelled during merging.");
                        return;
                    }

                    using (RasterImage img = (RasterImage)Image.Load(file))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the merged image
                canvas.Save();
            }

            Console.WriteLine($"Merged image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine multiple JPEG photos side‑by‑side into a single panoramic image but want the ability to stop the process if it takes too long.
 * 2. When a server‑side batch job merges large numbers of JPEG files and must respect user‑initiated cancellation to free resources.
 * 3. When building a desktop utility that creates a wide‑format collage from user‑selected images and needs to handle Ctrl‑C or close requests gracefully.
 * 4. When processing high‑resolution product images for an e‑commerce catalog and you must abort the merge if the operation exceeds a time budget.
 * 5. When integrating image merging into a CI/CD pipeline and you want the build to cancel the task on failure or timeout.
 */
