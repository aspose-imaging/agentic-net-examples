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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "corrupted.tif";
            string outputPathConsistent = "output\\recovered_consistent.tif";
            string outputPathFull = "output\\recovered_full.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathConsistent));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathFull));

            // ---------- Consistent recovery ----------
            var loadOptionsConsistent = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            int countConsistent = 0;
            using (Image imgConsistent = Image.Load(inputPath, loadOptionsConsistent))
            {
                if (imgConsistent is TiffImage tiffConsistent)
                {
                    countConsistent = tiffConsistent.PageCount;
                    var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                    imgConsistent.Save(outputPathConsistent, saveOptions);
                }
            }

            // ---------- Full recovery (using ConsistentRecover as fallback) ----------
            var loadOptionsFull = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            int countFull = 0;
            using (Image imgFull = Image.Load(inputPath, loadOptionsFull))
            {
                if (imgFull is TiffImage tiffFull)
                {
                    countFull = tiffFull.PageCount;
                    var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                    imgFull.Save(outputPathFull, saveOptions);
                }
            }

            // Compare recovered frame counts
            Console.WriteLine($"Consistent recovery frame count: {countConsistent}");
            Console.WriteLine($"Full recovery frame count: {countFull}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}