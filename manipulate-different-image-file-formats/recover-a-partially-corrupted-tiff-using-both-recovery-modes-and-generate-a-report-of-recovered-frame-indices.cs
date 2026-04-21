using System;
using System.IO;
using System.Collections.Generic;
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
            string inputPath = "input\\corrupted.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPathConsistent = "output\\recovered_consistent.tif";
            string reportPathConsistent = "output\\report_consistent.txt";
            string outputPathDefault = "output\\recovered_default.tif";
            string reportPathDefault = "output\\report_default.txt";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathConsistent));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathDefault));

            // Recovery using ConsistentRecover mode
            var loadOptionsConsistent = new LoadOptions { DataRecoveryMode = DataRecoveryMode.ConsistentRecover };
            using (TiffImage tiffConsistent = (TiffImage)Image.Load(inputPath, loadOptionsConsistent))
            {
                tiffConsistent.Save(outputPathConsistent);

                var recoveredIndicesConsistent = new List<string>();
                for (int i = 0; i < tiffConsistent.Frames.Length; i++)
                {
                    if (tiffConsistent.Frames[i] != null)
                        recoveredIndicesConsistent.Add(i.ToString());
                }
                File.WriteAllLines(reportPathConsistent, recoveredIndicesConsistent);
            }

            // Recovery using default load options (no explicit recovery mode)
            var loadOptionsDefault = new LoadOptions();
            using (TiffImage tiffDefault = (TiffImage)Image.Load(inputPath, loadOptionsDefault))
            {
                tiffDefault.Save(outputPathDefault);

                var recoveredIndicesDefault = new List<string>();
                for (int i = 0; i < tiffDefault.Frames.Length; i++)
                {
                    if (tiffDefault.Frames[i] != null)
                        recoveredIndicesDefault.Add(i.ToString());
                }
                File.WriteAllLines(reportPathDefault, recoveredIndicesDefault);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}