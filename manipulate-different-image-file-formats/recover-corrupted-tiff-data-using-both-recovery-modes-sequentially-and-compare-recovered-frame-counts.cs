using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        string inputPath = "corrupted.tif";
        string outputPathConsistent = "recovered_consistent.tif";
        string outputPathFull = "recovered_full.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPathConsistent) ?? string.Empty);
        Directory.CreateDirectory(Path.GetDirectoryName(outputPathFull) ?? string.Empty);

        int frameCountConsistent = 0;
        int frameCountFull = 0;

        using (Image imgConsistent = Image.Load(inputPath, new LoadOptions
        {
            DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
            DataBackgroundColor = Color.White
        }))
        {
            TiffImage tiffConsistent = (TiffImage)imgConsistent;
            frameCountConsistent = tiffConsistent.Frames.Length;
            tiffConsistent.Save(outputPathConsistent);
        }

        using (Image imgFull = Image.Load(inputPath, new LoadOptions
        {
            DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
            DataBackgroundColor = Color.White
        }))
        {
            TiffImage tiffFull = (TiffImage)imgFull;
            frameCountFull = tiffFull.Frames.Length;
            tiffFull.Save(outputPathFull);
        }

        Console.WriteLine($"ConsistentRecover frame count: {frameCountConsistent}");
        Console.WriteLine($"FullRecover frame count: {frameCountFull}");
    }
}