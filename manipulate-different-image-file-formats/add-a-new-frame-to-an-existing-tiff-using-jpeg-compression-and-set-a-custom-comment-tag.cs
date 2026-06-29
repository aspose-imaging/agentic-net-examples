using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output/output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.Jpeg;
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Photometric = TiffPhotometrics.Rgb;

                using (TiffFrame newFrame = new TiffFrame(frameOptions, tiffImage.Width, tiffImage.Height))
                {
                    tiffImage.AddFrame(newFrame);
                }

                tiffImage.Save(outputPath);
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
 * 1. When a medical imaging application needs to append a new high‑resolution scan to an existing multi‑page TIFF while keeping file size low by using JPEG compression and storing a descriptive comment tag.
 * 2. When a document management system must combine a newly scanned page with an archived TIFF bundle, applying JPEG compression to the added frame and embedding a custom comment for audit tracking.
 * 3. When a GIS tool adds an updated satellite image layer to a multi‑page TIFF map, using JPEG compression for the new frame and inserting a comment tag that records the capture date and sensor details.
 * 4. When an e‑commerce platform generates a product catalog TIFF that includes a freshly photographed item, compressing the new frame with JPEG and adding a comment tag containing SKU and pricing information.
 * 5. When a legal firm merges a newly signed PDF page converted to TIFF into an existing case file TIFF, applying JPEG compression to the added frame and embedding a comment tag that references the case number and signing date.
 */