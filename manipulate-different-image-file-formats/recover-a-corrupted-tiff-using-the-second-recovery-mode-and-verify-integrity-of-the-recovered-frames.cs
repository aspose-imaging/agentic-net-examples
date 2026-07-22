using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Corrupted\\corrupted.tif";
        string outputPath = "Recovered\\recovered.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath, loadOptions))
            {
                Console.WriteLine($"Recovered frame count: {tiffImage.Frames.Length}");
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    var frame = tiffImage.Frames[i];
                    Console.WriteLine($"Frame {i}: {frame.Width}x{frame.Height}");
                }

                tiffImage.Save(outputPath);
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
 * 1. When a medical imaging system receives a corrupted multi‑page TIFF from a scanner, a developer can use this code to recover the TIFF using Aspose.Imaging’s ConsistentRecover mode and verify each frame’s dimensions before saving a usable file.
 * 2. When a digital archiving workflow encounters damaged TIFF files from legacy cameras, the code helps restore the image sequence by loading with DataRecoveryMode.ConsistentRecover, checking the recovered frame count, and re‑saving the file for downstream processing.
 * 3. When a document management application needs to display thumbnails of each page in a corrupted multi‑frame TIFF, a developer can run this routine to recover the frames, read their width and height, and generate reliable thumbnails.
 * 4. When a GIS (Geographic Information System) imports large satellite TIFF mosaics that may be partially corrupted, this snippet enables recovery of the image tiles, validates each tile’s size, and writes a clean TIFF for further analysis.
 * 5. When an e‑commerce platform processes vendor‑supplied product catalogs stored as multi‑page TIFFs that sometimes get corrupted during transfer, the code can automatically recover the pages, confirm their integrity, and store a corrected TIFF for web publishing.
 */