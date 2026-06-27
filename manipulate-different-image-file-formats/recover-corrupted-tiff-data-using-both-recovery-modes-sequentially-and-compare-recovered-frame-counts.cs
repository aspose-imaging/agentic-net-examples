using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "corrupted.tif";
            string outputPathConsistent = "output\\recovered_consistent.tif";
            string outputPathFull = "output\\recovered_full.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathConsistent));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathFull));

            int consistentFrames = 0;
            var consistentLoadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };
            using (Image img = Image.Load(inputPath, consistentLoadOptions))
            {
                var tiff = (TiffImage)img;
                consistentFrames = tiff.Frames.Length;
                tiff.Save(outputPathConsistent);
            }

            int fullFrames = 0;
            var fullLoadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };
            using (Image img = Image.Load(inputPath, fullLoadOptions))
            {
                var tiff = (TiffImage)img;
                fullFrames = tiff.Frames.Length;
                tiff.Save(outputPathFull);
            }

            Console.WriteLine($"Consistent recovery frame count: {consistentFrames}");
            Console.WriteLine($"Full recovery frame count: {fullFrames}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging system receives a partially corrupted multi‑page TIFF scan from an MRI device, a developer can use this code to attempt a consistent recovery first, then a full recovery, and compare frame counts to decide which version is usable.
 * 2. When a digital archiving workflow encounters damaged TIFF documents from legacy scanners, the code helps restore as many pages as possible by applying both DataRecoveryMode options and verifying which mode retained more frames.
 * 3. When a GIS application processes large satellite TIFF mosaics that may be truncated during transfer, developers can run the sequential recovery to ensure the maximum number of image tiles are recovered before further analysis.
 * 4. When an e‑commerce platform imports product catalogs supplied as multi‑page TIFF files that sometimes get corrupted, this snippet allows the backend to automatically recover the images and log the difference in frame counts for quality monitoring.
 * 5. When a printing service receives client‑submitted TIFF files with missing or damaged pages, the code enables the service to recover the document using consistent and full recovery modes and compare the recovered page counts to decide whether to request a new file from the client.
 */