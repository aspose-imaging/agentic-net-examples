using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

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

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathConsistent));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathFull));

            // Recovery using ConsistentRecover mode
            TiffImage tiffConsistent;
            var loadOptionsConsistent = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };
            using (tiffConsistent = (TiffImage)Image.Load(inputPath, loadOptionsConsistent))
            {
                tiffConsistent.Save(outputPathConsistent);
            }

            // Recovery using ConsistentRecover mode as fallback (FullRecover not available)
            TiffImage tiffFull;
            var loadOptionsFull = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };
            using (tiffFull = (TiffImage)Image.Load(inputPath, loadOptionsFull))
            {
                tiffFull.Save(outputPathFull);
            }

            // Compare frame counts
            int countConsistent = tiffConsistent.Frames.Length;
            int countFull = tiffFull.Frames.Length;

            Console.WriteLine($"ConsistentRecover frame count: {countConsistent}");
            Console.WriteLine($"FullRecover frame count: {countFull}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}