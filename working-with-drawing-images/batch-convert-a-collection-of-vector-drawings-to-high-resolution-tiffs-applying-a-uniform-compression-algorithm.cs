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
            // Hardcoded input files (vector drawings) and output directory
            string[] inputFiles = new string[]
            {
                @"C:\Images\Input\drawing1.svg",
                @"C:\Images\Input\drawing2.emf",
                @"C:\Images\Input\drawing3.cdr"
            };

            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists (creates parent if needed)
            Directory.CreateDirectory(outputDirectory);

            // Prepare TIFF save options with uniform compression (LZW)
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Compression = TiffCompressions.Lzw,
                BitsPerSample = new ushort[] { 8, 8, 8 },
                Photometric = TiffPhotometrics.Rgb,
                PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                ByteOrder = TiffByteOrder.LittleEndian
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Derive output file path (same name with .tif extension)
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".tif");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the vector image
                using (Image image = Image.Load(inputPath))
                {
                    // If the source is a vector image, set rasterization options for high resolution
                    if (image is VectorImage vectorImage)
                    {
                        // Example: render at 300 DPI (adjust as needed)
                        int targetWidth = (int)(vectorImage.Width * 300.0 / 72.0);
                        int targetHeight = (int)(vectorImage.Height * 300.0 / 72.0);

                        // Configure rasterization options
                        var rasterOptions = new VectorRasterizationOptions
                        {
                            PageSize = new Size(targetWidth, targetHeight),
                            BackgroundColor = Color.White,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };

                        tiffOptions.VectorRasterizationOptions = rasterOptions;
                    }

                    // Save as high‑resolution TIFF with the predefined options
                    image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert a batch of SVG, EMF, or CorelDRAW CDR vector drawings into high‑resolution TIFF files for archival or printing, while applying LZW compression to reduce storage size.
 * 2. When an engineering application must generate lossless, color‑accurate TIFF images from vector schematics for inclusion in PDF reports or CAD documentation.
 * 3. When a medical imaging system requires converting vector illustrations of anatomical diagrams into TIFF format with consistent photometric settings for integration with DICOM workflows.
 * 4. When an e‑commerce platform wants to create web‑ready, high‑resolution product catalog pages by converting designer‑provided vector assets into compressed TIFFs for downstream processing.
 * 5. When a legal firm needs to preserve client‑supplied vector evidence as TIFF files with uniform compression and byte order to meet court‑mandated electronic document standards.
 */