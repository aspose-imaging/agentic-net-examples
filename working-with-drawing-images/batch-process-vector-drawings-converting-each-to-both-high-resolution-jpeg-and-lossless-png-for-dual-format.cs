// HOW-TO: Batch Convert Vector Images to High-Resolution JPEG and PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base, input and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Validate input directory
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

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory);
            foreach (var inputPath in files)
            {
                // Verify the file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the vector image
                using (Image image = Image.Load(inputPath))
                {
                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string jpegOutputPath = Path.Combine(outputDirectory, fileName + ".jpg");
                    string pngOutputPath = Path.Combine(outputDirectory, fileName + ".png");

                    // Ensure output subdirectories exist
                    Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));
                    Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

                    // Configure JPEG options (high quality)
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 100,
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        }
                    };

                    // Configure PNG options (lossless)
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        }
                    };

                    // Save as JPEG
                    image.Save(jpegOutputPath, jpegOptions);
                    // Save as PNG
                    image.Save(pngOutputPath, pngOptions);
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
 * 1. When a marketing team needs both web‑ready JPEGs and print‑quality PNGs from a folder of SVG logos.
 * 2. When an e‑commerce platform must generate high‑resolution product images in JPEG for browsers and lossless PNGs for catalog PDFs.
 * 3. When a developer automates the conversion of vector illustrations into dual formats for mobile app assets and desktop documentation.
 * 4. When a digital archive requires batch exporting of vector drawings to JPEG for quick preview and PNG for archival preservation.
 * 5. When a content management system must process incoming vector files and store them as JPEG thumbnails and PNG originals for downstream workflows.
 */
