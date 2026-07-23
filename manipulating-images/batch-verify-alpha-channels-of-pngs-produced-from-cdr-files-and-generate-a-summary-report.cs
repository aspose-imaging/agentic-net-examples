using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing PNGs generated from CDR files
            string inputDir = @"C:\Images\CDR_PNGs";
            // Hardcoded output report file path
            string outputReport = @"C:\Images\AlphaReport.txt";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputReport));

            // Create or overwrite the report file
            using (var writer = new StreamWriter(outputReport, false))
            {
                writer.WriteLine("FileName,HasAlpha");

                // Retrieve all PNG files recursively
                string[] pngFiles = Directory.GetFiles(inputDir, "*.png", SearchOption.AllDirectories);
                foreach (var filePath in pngFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    bool hasAlpha = false;

                    // Load the image and check for an alpha channel
                    using (Image image = Image.Load(filePath))
                    {
                        // RasterImage provides HasAlpha for all raster formats
                        if (image is RasterImage raster)
                        {
                            hasAlpha = raster.HasAlpha;
                        }
                        else if (image is PngImage png)
                        {
                            hasAlpha = png.HasAlpha;
                        }
                    }

                    // Write the result to the report
                    writer.WriteLine($"{Path.GetFileName(filePath)},{hasAlpha}");
                }
            }

            Console.WriteLine($"Alpha channel verification completed. Report saved to {outputReport}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to ensure that all PNG images exported from CorelDRAW (CDR) files retain their transparency before publishing them on a website, they can use this code to batch‑verify the alpha channel and create a concise report.
 * 2. When a CI/CD pipeline must automatically validate that newly generated PNG assets contain an alpha channel so that downstream graphics tools work correctly, the script can scan the output folder and log the results.
 * 3. When a quality‑assurance team wants to audit a large collection of PNGs produced by a design workflow for missing transparency, this C# example quickly identifies files without an alpha channel and records them in a text file.
 * 4. When a migration project moves graphics from legacy CDR sources to a modern asset library and needs to flag images that lost their alpha information during conversion, the code provides a fast batch check and summary.
 * 5. When a developer is building a custom image‑processing utility that must report which PNGs generated from CDR files contain an alpha channel for further processing steps, this snippet offers a ready‑to‑use solution in Aspose.Imaging for .NET.
 */