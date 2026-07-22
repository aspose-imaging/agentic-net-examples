using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CDR files
            string[] inputFiles = new string[]
            {
                @"C:\Input\file1.cdr",
                @"C:\Input\file2.cdr"
                // Add more input paths as needed
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Output";

            // Prepare TIFF save options with LZW compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.ByteOrder = Aspose.Imaging.FileFormats.Tiff.Enums.TiffByteOrder.BigEndian;
            tiffOptions.Compression = Aspose.Imaging.FileFormats.Tiff.Enums.TiffCompressions.Lzw;
            tiffOptions.Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb;
            tiffOptions.PlanarConfiguration = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPlanarConfigs.Contiguous;
            tiffOptions.Predictor = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPredictor.Horizontal;

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output TIFF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".tif";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR image with default load options
                using (Aspose.Imaging.FileFormats.Cdr.CdrImage cdrImage = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Image.Load(inputPath, new CdrLoadOptions()))
                {
                    // Save as TIFF using the prepared options
                    cdrImage.Save(outputPath, tiffOptions);
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
 * 1. When a design studio needs to archive a collection of CorelDRAW (.cdr) illustrations as lossless, LZW‑compressed TIFF files for long‑term storage or print‑ready distribution.
 * 2. When an e‑learning platform automatically converts uploaded CDR graphics into TIFF images to embed in course PDFs while preserving color fidelity using Aspose.Imaging for .NET.
 * 3. When a document management system processes batches of CDR files from a shared folder and saves them as high‑quality TIFFs with LZW compression to reduce file size before indexing.
 * 4. When a GIS application imports vector drawings from CorelDRAW and needs to generate raster TIFF tiles in bulk, using C# and Aspose.Imaging to ensure consistent byte order and planar configuration.
 * 5. When a print shop receives multiple client CDR files and runs a nightly C# script to produce ready‑to‑print TIFFs with LZW compression, streamlining the workflow and minimizing manual conversion steps.
 */