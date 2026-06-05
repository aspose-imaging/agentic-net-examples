using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

namespace BatchCdrToPng
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputCdr";
            string outputDirectory = @"C:\OutputPng";

            try
            {
                // Get all CDR files in the input directory
                foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.cdr"))
                {
                    // Verify the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Load the CDR image
                    using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                    {
                        // Ensure all pages are cached (optional but improves performance)
                        cdrImage.CacheData();

                        int pageIndex = 0;
                        foreach (CdrImagePage page in cdrImage.Pages)
                        {
                            // Prepare output file path for each page
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.png";
                            string outputPath = Path.Combine(outputDirectory, outputFileName);

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            page.Save(outputPath, new PngOptions());

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