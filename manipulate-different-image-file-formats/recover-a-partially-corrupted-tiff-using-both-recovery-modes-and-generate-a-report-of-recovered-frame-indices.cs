using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPathConsistent = "output_consistent.tif";
        string outputPathFull = "output_full.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Recovery using ConsistentRecover mode
        var loadOptionsConsistent = new LoadOptions
        {
            DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
            DataBackgroundColor = Color.White
        };

        using (TiffImage tiffConsistent = (TiffImage)Image.Load(inputPath, loadOptionsConsistent))
        {
            var recoveredIndicesConsistent = new List<int>();
            for (int i = 0; i < tiffConsistent.Frames.Length; i++)
            {
                if (tiffConsistent.Frames[i] != null)
                {
                    recoveredIndicesConsistent.Add(i);
                }
            }

            Console.WriteLine("Consistent recovery recovered frames: " + string.Join(", ", recoveredIndicesConsistent));

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathConsistent));
            tiffConsistent.Save(outputPathConsistent);
        }

        // Recovery using ConsistentRecover mode as fallback (FullRecover not available)
        var loadOptionsFull = new LoadOptions
        {
            DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
            DataBackgroundColor = Color.White
        };

        using (TiffImage tiffFull = (TiffImage)Image.Load(inputPath, loadOptionsFull))
        {
            var recoveredIndicesFull = new List<int>();
            for (int i = 0; i < tiffFull.Frames.Length; i++)
            {
                if (tiffFull.Frames[i] != null)
                {
                    recoveredIndicesFull.Add(i);
                }
            }

            Console.WriteLine("Full recovery recovered frames: " + string.Join(", ", recoveredIndicesFull));

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathFull));
            tiffFull.Save(outputPathFull);
        }
    }
}