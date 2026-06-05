using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CDR files
            string[] inputPaths = new string[]
            {
                @"C:\input\file1.cdr",
                @"C:\input\file2.cdr"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\output";

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output TIFF path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".tif");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR image with default load options
                using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                {
                    var loadOptions = new CdrLoadOptions();

                    using (CdrImage cdrImage = new CdrImage(stream, loadOptions))
                    {
                        // Configure TIFF save options with LZW compression
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            BitsPerSample = new ushort[] { 8, 8, 8 },
                            ByteOrder = TiffByteOrder.BigEndian,
                            Compression = TiffCompressions.Lzw,
                            Photometric = TiffPhotometrics.Rgb,
                            PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                            Predictor = TiffPredictor.Horizontal
                        };

                        // Save as TIFF
                        cdrImage.Save(outputPath, tiffOptions);
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
 * 1. When a print shop needs to archive multiple CorelDRAW (.cdr) designs as lossless TIFF files with LZW compression for long‑term storage.
 * 2. When a document management system must batch‑convert incoming CDR artwork into TIFF images to embed them in PDFs without losing color fidelity.
 * 3. When an e‑commerce platform automatically transforms supplier‑provided CDR product illustrations into web‑ready TIFF files with LZW compression for high‑quality thumbnails.
 * 4. When a GIS application imports vector CDR maps and saves them as tiled TIFF files using LZW to reduce file size while preserving raster detail.
 * 5. When a legal firm digitizes case‑related CDR diagrams and stores them as compressed TIFFs to meet court‑mandated electronic evidence standards.
 */