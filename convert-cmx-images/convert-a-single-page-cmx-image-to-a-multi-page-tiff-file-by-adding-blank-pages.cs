// HOW-TO: Convert CMX to Multi‑Page TIFF with Blank Pages in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputPath = "output/output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int width = cmx.Width;
                int height = cmx.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    int additionalPages = 2; // number of blank pages to add
                    for (int i = 0; i < additionalPages; i++)
                    {
                        TiffFrame blankFrame = new TiffFrame(tiffOptions, width, height);
                        tiff.AddFrame(blankFrame);
                    }

                    tiff.Save(outputPath);
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
 * 1. When you need to embed a single‑page CMX drawing into a multi‑page TIFF document for archival or printing, adding placeholder pages for later content.
 * 2. When generating a TIFF file that must match a fixed page count, such as a form template, and you start from a CMX source image.
 * 3. When converting legacy CorelDRAW CMX artwork to a TIFF stack for use in document management systems that require blank pages for pagination.
 * 4. When automating a workflow that creates multi‑page TIFFs from CMX files and needs extra empty pages for annotations or signatures.
 * 5. When integrating Aspose.Imaging in a C# application to produce a TIFF file with a specific number of pages, beginning with a CMX image and appending blank frames.
 */
