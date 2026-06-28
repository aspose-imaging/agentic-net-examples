using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory);

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterCachedImage image = (RasterCachedImage)Image.Load(inputPath))
                {
                    if (!image.IsCached)
                        image.CacheData();

                    byte threshold = 128;
                    image.BinarizeFixed(threshold);

                    image.Save(outputPath);

                    Console.WriteLine($"{fileName}, {threshold}, False");
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
 * 1. A developer processes a batch of scanned PDF page images in PNG format to create high‑contrast black‑and‑white versions for OCR by applying a fixed threshold of 128 and saving the results to an output folder.
 * 2. An automated workflow converts a collection of JPEG photographs taken under varying lighting conditions into binary masks for machine‑vision inspection, using Aspose.Imaging’s RasterCachedImage to ensure the image data is cached before binarization.
 * 3. A desktop application generates printable line‑art from a set of BMP drawings by loading each file, performing a fixed‑threshold binarization, and exporting the simplified images to a designated directory for downstream publishing.
 * 4. A document management system prepares TIFF scans for archival by converting each page to a binary image with a 128 threshold, guaranteeing consistent file size and faster retrieval while logging the processed file name and threshold used.
 * 5. An image‑processing script cleans up a folder of mixed‑format (PNG, JPEG, TIFF) screenshots by applying a uniform binarization step, caching the raster data for performance, and recording whether any feathering was applied (always false in this case).
 */