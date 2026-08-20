// HOW-TO: Convert CMX to TIFF with Default Compression in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.cmx";
            string outputPath = @"C:\temp\output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare default TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as a single‑page TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When a CAD system exports a single‑page CMX drawing and you need to archive it as a TIFF file for compatibility with document management tools.
 * 2. When a printing workflow requires converting legacy CMX artwork to TIFF before sending it to a RIP or print server that only accepts TIFF input.
 * 3. When you want to generate a thumbnail preview in a web application by first converting a CMX file to a TIFF image using Aspose.Imaging in C#.
 * 4. When migrating a batch of single‑page CMX files to a standardized TIFF format for long‑term storage without worrying about custom compression settings.
 * 5. When integrating a C# service that receives CMX uploads and must store them as TIFFs to be displayed in a .NET reporting component.
 */
