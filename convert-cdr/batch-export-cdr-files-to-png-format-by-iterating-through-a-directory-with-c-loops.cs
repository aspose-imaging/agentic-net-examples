using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputCdr";
        string outputDirectory = @"C:\OutputPng";

        // Get all CDR files in the input directory
        foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.cdr"))
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Ensure all pages are cached to avoid lazy loading during save
                foreach (CdrImagePage page in cdrImage.Pages)
                {
                    page.CacheData();
                }

                // Export each page to a separate PNG file
                for (int pageIndex = 0; pageIndex < cdrImage.PageCount; pageIndex++)
                {
                    CdrImagePage page = (CdrImagePage)cdrImage.Pages[pageIndex];

                    // Build the output file path
                    string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}.page{pageIndex}.png";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}