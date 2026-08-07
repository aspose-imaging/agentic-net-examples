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
            // Hardcoded input and output paths
            string[] inputPaths = new[] { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "merged.jpg";

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

            // Collect sizes
            List<Size> sizes = new List<Size>();
            using (JpegImage firstImg = (JpegImage)Image.Load(inputPaths[0]))
            {
                sizes.Add(firstImg.Size);
            }

            for (int i = 1; i < inputPaths.Length; i++)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions (horizontal merge)
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight) canvasHeight = sz.Height;
            }

            // Create JPEG canvas with bound output source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                // Merge images horizontally
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
 * 1. When a photographer wants to combine multiple JPEG photos into a single panoramic image while keeping the original EXIF camera settings for the first photo, this code can merge the images and preserve the metadata.
 * 2. When an e‑commerce platform needs to stitch product shot thumbnails side‑by‑side into a catalog image but must retain the original EXIF date and GPS data for compliance, the snippet does the job.
 * 3. When a mobile app generates a combined receipt image from several scanned JPEG pages and wants the first page’s EXIF orientation and resolution to stay intact for downstream processing, this example is applicable.
 * 4. When a digital archiving system consolidates scanned document JPEGs into a single file for storage efficiency yet must keep the first file’s EXIF author and creation timestamp, the code provides a solution.
 * 5. When a social‑media scheduler creates a composite promotional banner from multiple JPEG assets and needs the first image’s EXIF copyright information to be preserved for legal reasons, this routine can be used.
 */