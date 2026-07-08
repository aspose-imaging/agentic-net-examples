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

        try
        {
            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
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
                    // Ensure all pages are cached to avoid repeated I/O
                    cdrImage.CacheData();

                    // Iterate through each page of the CDR document
                    for (int i = 0; i < cdrImage.PageCount; i++)
                    {
                        // Retrieve the specific page
                        CdrImagePage page = (CdrImagePage)cdrImage.Pages[i];

                        // Build the output PNG file path
                        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + $"_page{i}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Define PNG save options (default options are sufficient)
                        PngOptions pngOptions = new PngOptions();

                        // Save the page as a PNG image
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

/*
 * Real-World Use Cases:
 * 1. When a design studio needs to convert a large collection of CorelDRAW (CDR) files into web‑ready PNG thumbnails for an online portfolio, they can use this C# batch export loop.
 * 2. When an automated build pipeline must generate PNG previews of each page in multi‑page CDR documents for quality‑assurance reporting, the code iterates through the input folder and saves each page as a separate PNG.
 * 3. When a document management system has to migrate legacy CDR assets to a PNG format that browsers support, developers can run this Aspose.Imaging C# script to process all files in a directory at once.
 * 4. When a print‑to‑screen workflow requires extracting every page of a CDR file and storing them as high‑resolution PNG images for downstream raster processing, the loop with CdrImagePage.Save handles the conversion.
 * 5. When a batch‑processing tool needs to ensure that output folders exist and convert each CDR file’s pages to PNG without manual intervention, this code provides the necessary file‑system checks and image‑format conversion in C#.
 */