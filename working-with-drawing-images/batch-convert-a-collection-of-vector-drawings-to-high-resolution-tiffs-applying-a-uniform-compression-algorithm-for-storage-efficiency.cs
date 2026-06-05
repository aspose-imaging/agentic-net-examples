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
        try
        {
            // Define input and output directories relative to the current working directory
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files from the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tif");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image
                using (Image image = Image.Load(inputPath))
                {
                    // Common TIFF options: high resolution and LZW compression
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        Compression = TiffCompressions.Lzw,
                        ResolutionSettings = new ResolutionSetting(300, 300) // 300 DPI for high resolution
                    };

                    // If the source is a vector image, set rasterization options
                    if (image is VectorImage)
                    {
                        tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };
                    }

                    // Save as TIFF with the configured options
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
 * 1. When a developer must archive a large collection of SVG or AI vector drawings as high‑resolution, lossless TIFF files with uniform LZW compression to meet regulatory storage requirements.
 * 2. When an e‑commerce platform needs to batch convert designer‑provided EPS product illustrations into 300 dpi TIFFs for print‑ready catalogs while minimizing file size.
 * 3. When a medical imaging system requires converting vector‑based anatomical diagrams into high‑quality TIFFs with CCITT Group 4 compression for integration into PACS archives.
 * 4. When a digital asset management tool automates the migration of legacy vector assets into searchable TIFF thumbnails, applying consistent compression to reduce storage costs.
 * 5. When a publishing workflow needs to transform a folder of mixed vector formats (SVG, WMF, EMF) into high‑resolution TIFFs for pre‑press proofing, ensuring all files use the same compression algorithm for consistent file handling.
 */