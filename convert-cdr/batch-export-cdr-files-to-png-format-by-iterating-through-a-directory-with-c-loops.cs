using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputCdr";
            string outputDirectory = @"C:\OutputPng";

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
                    // Cache the whole document to avoid repeated I/O
                    cdrImage.CacheData();

                    // Process each page in the CDR file
                    for (int pageIndex = 0; pageIndex < cdrImage.PageCount; pageIndex++)
                    {
                        // Retrieve the page and cache its data
                        CdrImagePage page = (CdrImagePage)cdrImage.Pages[pageIndex];
                        page.CacheData();

                        // Build the output PNG file path
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}.page{pageIndex}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        PngOptions pngOptions = new PngOptions();
                        page.Save(outputPath, pngOptions);
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