using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Input\multi.emf";
            string outputDirectory = @"C:\Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the EMF document
            using (Image image = Image.Load(inputPath))
            {
                // Check if the loaded image supports multiple pages
                if (image is IMultipageImage multipageImage)
                {
                    int pageCount = multipageImage.PageCount;

                    for (int i = 0; i < pageCount; i++)
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure TIFF save options
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            // Example: use LZW compression
                            Compression = TiffCompressions.Lzw,

                            // Set high resolution (e.g., 300 DPI)
                            ResolutionSettings = new ResolutionSetting(300, 300)
                        };

                        // Restrict saving to the current page only
                        var multiPageOpts = new MultiPageOptions();
                        multiPageOpts.Pages = new int[] { i };
                        tiffOptions.MultiPageOptions = multiPageOpts;

                        // Save the current page as a separate TIFF file
                        image.Save(outputPath, tiffOptions);
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image does not support multiple pages.");
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
 * 1. When a developer must extract each page of a multi‑page EMF vector drawing and save them as high‑resolution (e.g., 300 DPI) TIFF files for archival or printing, this code provides a C# solution using Aspose.Imaging.
 * 2. When an engineering application needs to convert complex EMF schematics into separate TIFF images with LZW compression for faster loading in a web viewer, the example demonstrates the required steps.
 * 3. When a document‑management system requires batch processing of EMF reports into individual TIFF pages at a specific DPI to meet regulatory image‑quality standards, the code shows how to automate the conversion in .NET.
 * 4. When a GIS or mapping tool must preserve the detail of vector‑based EMF map layers by rendering each page to a 300 DPI TIFF for downstream raster analysis, this snippet handles the conversion.
 * 5. When a medical‑imaging workflow needs to transform multi‑page EMF charts into separate high‑resolution TIFF files for integration with DICOM archives, the sample illustrates the necessary C# implementation.
 */