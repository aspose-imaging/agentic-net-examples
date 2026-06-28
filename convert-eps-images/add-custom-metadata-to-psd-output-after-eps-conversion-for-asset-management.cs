using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/result.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var epsImage = (EpsImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb
                };

                epsImage.Save(outputPath, psdOptions);
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
 * 1. When a print studio needs to convert vector EPS artwork to layered PSD files while embedding copyright and project identifiers for downstream Photoshop editing and digital asset tracking.
 * 2. When an e‑commerce platform automates the creation of product mockups by converting supplier EPS logos to PSD format and adding SKU and brand metadata for catalog management.
 * 3. When a marketing team integrates a C# workflow that transforms EPS illustrations into PSD files with RLE compression and inserts campaign tags so that assets can be searched in a DAM system.
 * 4. When a publishing company processes incoming EPS illustrations, converts them to PSD with RGB color mode, and writes author and revision metadata to maintain version control across editorial tools.
 * 5. When a software vendor builds an automated pipeline that reads EPS files, saves them as PSD using Aspose.Imaging, and appends custom metadata such as creation date and licensing information for compliance auditing.
 */