// HOW-TO: Merge Multiple JPEG Images Horizontally and Add Timestamp to Filename in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

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
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight)
                    canvasHeight = sz.Height;
            }

            // Generate output filename with timestamp based on first input image
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string firstFileName = Path.GetFileNameWithoutExtension(inputPaths[0]);
            string extension = Path.GetExtension(inputPaths[0]);
            string outputDirectory = "Output";
            string outputFileName = $"{firstFileName}_{timestamp}{extension}";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare JPEG options with bound source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = source,
                Quality = 100
            };

            // Create canvas bound to the output file
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

                // Save the merged image (canvas is already bound to outputPath)
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
 * 1. When you need to combine several product photos into a single side‑by‑side JPEG for an online catalog while ensuring each output file has a unique timestamped name.
 * 2. When generating daily composite screenshots from multiple cameras and storing them with time‑stamped filenames to avoid overwriting previous merges.
 * 3. When creating a batch process that stitches together scanned document pages into a panoramic JPEG and automatically names the result with the current date and time.
 * 4. When building a C# service that merges user‑uploaded JPEG avatars into a single banner image and saves it with a unique timestamp to track each version.
 * 5. When automating the preparation of marketing assets by horizontally merging promotional JPEGs and appending a timestamp to the filename for version control.
 */
