using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input directory and output directory
        string inputDir = @"C:\InputDjvu";
        string outputDir = @"C:\OutputPdf";

        // List of twenty DjVu files to convert (hard‑coded names)
        string[] inputFiles = new string[20]
        {
            "file1.djvu", "file2.djvu", "file3.djvu", "file4.djvu", "file5.djvu",
            "file6.djvu", "file7.djvu", "file8.djvu", "file9.djvu", "file10.djvu",
            "file11.djvu", "file12.djvu", "file13.djvu", "file14.djvu", "file15.djvu",
            "file16.djvu", "file17.djvu", "file18.djvu", "file19.djvu", "file20.djvu"
        };

        for (int i = 0; i < inputFiles.Length; i++)
        {
            // Build full input and output paths
            string inputPath = Path.Combine(inputDir, inputFiles[i]);
            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputFiles[i]) + ".pdf");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Save the whole DjVu document as a PDF with default options
                djvuImage.Save(outputPath, new PdfOptions());
            }
        }
    }
}