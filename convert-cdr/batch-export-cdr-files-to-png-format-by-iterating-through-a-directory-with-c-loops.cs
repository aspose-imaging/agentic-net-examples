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
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
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
                    // Ensure all pages are cached to avoid lazy loading during save
                    cdrImage.CacheData();
                    foreach (CdrImagePage page in cdrImage.Pages)
                    {
                        page.CacheData();

                        // Build output file name for each page
                        string outputFileName = Path.Combine(
                            outputDirectory,
                            $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.PageNumber}.png");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFileName));

                        // Save the page as PNG
                        PngOptions pngOptions = new PngOptions();
                        page.Save(outputFileName, pngOptions);
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

/*
 * Real-World Use Cases:
 * 1. When a design studio needs to convert a batch of CorelDRAW (.cdr) artwork files into PNG thumbnails for a web gallery, they can use this C# loop to process each file and each page.
 * 2. When an automated build pipeline must generate PNG previews of multi‑page CDR documents for documentation or QA, the code iterates through a directory and saves each page as a separate PNG.
 * 3. When a migration project moves legacy CDR assets to a PNG‑based asset management system, developers can run this script to bulk export every CDR file and its pages to PNG files.
 * 4. When a cloud service receives uploaded CDR files and must provide downloadable PNG versions for end‑users, the code demonstrates how to load, cache, and save each page in C#.
 * 5. When a batch‑processing tool needs to create high‑resolution PNG sprites from a collection of CDR source files for game development, this loop automates the conversion of each page to PNG.
 */