using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\corrupted.tif";
            string outputConsistent = @"C:\Temp\recovered_consistent.tif";
            string outputMaximal = @"C:\Temp\recovered_maximal.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // ---------- Consistent recovery ----------
            var loadOptionsConsistent = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover
            };

            using (TiffImage imageConsistent = (TiffImage)Image.Load(inputPath, loadOptionsConsistent))
            {
                int frameCountConsistent = imageConsistent.Frames.Length;
                Console.WriteLine($"Consistent recovery frame count: {frameCountConsistent}");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputConsistent));
                // Save recovered image
                imageConsistent.Save(outputConsistent);
            }

            // ---------- Maximal recovery ----------
            var loadOptionsMaximal = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.MaximalRecover
            };

            using (TiffImage imageMaximal = (TiffImage)Image.Load(inputPath, loadOptionsMaximal))
            {
                int frameCountMaximal = imageMaximal.Frames.Length;
                Console.WriteLine($"Maximal recovery frame count: {frameCountMaximal}");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputMaximal));
                // Save recovered image
                imageMaximal.Save(outputMaximal);
            }

            // Comparison already printed above
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}