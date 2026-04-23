using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string baseDir = Directory.GetCurrentDirectory();
                string inputDir = Path.Combine(baseDir, "Input");
                string outputDir = Path.Combine(baseDir, "Output");

                // Ensure output directory exists
                Directory.CreateDirectory(outputDir);

                // Prepare list of 30 DjVu files
                var inputFiles = new List<string>();
                for (int i = 1; i <= 30; i++)
                {
                    inputFiles.Add(Path.Combine(inputDir, $"file{i}.djvu"));
                }

                foreach (var inputPath in inputFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Load DjVu document
                    using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                    {
                        int pageIndex = 0;
                        foreach (var page in djvuImage.Pages)
                        {
                            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                            string outputPath = Path.Combine(outputDir, $"{fileNameWithoutExt}_page{pageIndex}.tiff");

                            // Ensure output directory for this file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save page as TIFF
                            using (var tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default))
                            {
                                page.Save(outputPath, tiffOptions);
                            }

                            pageIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}