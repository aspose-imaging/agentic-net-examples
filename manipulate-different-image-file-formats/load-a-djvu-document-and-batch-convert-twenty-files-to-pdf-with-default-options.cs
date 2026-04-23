using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory and file names (20 DjVu files)
            string inputDirectory = @"C:\InputDjvu";
            string[] inputFiles = new string[]
            {
                "file1.djvu","file2.djvu","file3.djvu","file4.djvu","file5.djvu",
                "file6.djvu","file7.djvu","file8.djvu","file9.djvu","file10.djvu",
                "file11.djvu","file12.djvu","file13.djvu","file14.djvu","file15.djvu",
                "file16.djvu","file17.djvu","file18.djvu","file19.djvu","file20.djvu"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\OutputPdf";

            foreach (string fileName in inputFiles)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputDirectory, fileName);
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(fileName) + ".pdf");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu document and save as PDF using default options
                using (FileStream inputStream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(inputStream))
                {
                    djvuImage.Save(outputPath, new PdfOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}