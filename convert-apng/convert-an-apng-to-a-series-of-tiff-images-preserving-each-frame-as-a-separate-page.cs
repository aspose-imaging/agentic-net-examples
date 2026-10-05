// HOW-TO: Convert APNG Animation to Multi‑Page TIFF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.apng";
            string outputPath = "Output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
                apng.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive animated PNG frames as separate pages in a TIFF document for printing or long‑term storage.
 * 2. When a web service must convert user‑uploaded APNG files into multi‑page TIFFs for compatibility with legacy imaging systems.
 * 3. When generating a PDF from images and you first need each APNG frame saved as a TIFF page to be later merged.
 * 4. When performing batch processing of animation assets and require each frame to be accessible as individual TIFF layers for further editing.
 * 5. When integrating with medical or GIS software that only accepts TIFF stacks, and you must transform APNG animations into that format using C#.
 */
