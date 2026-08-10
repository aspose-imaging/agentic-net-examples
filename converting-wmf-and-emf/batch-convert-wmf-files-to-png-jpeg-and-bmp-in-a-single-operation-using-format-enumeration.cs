// HOW-TO: Batch Convert WMF Files to PNG, JPEG, and BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base, input and output directories (relative paths)
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists; if not, create and exit
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

            // Get all WMF files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.wmf");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the WMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare vector rasterization options common to all output formats
                    var vectorOptions = new WmfRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size
                    };

                    // Determine base file name without extension
                    string baseFileName = Path.GetFileNameWithoutExtension(inputPath);

                    // Convert to PNG
                    {
                        string outputPath = Path.Combine(outputDirectory, baseFileName + ".png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = vectorOptions
                        };
                        image.Save(outputPath, pngOptions);
                    }

                    // Convert to JPEG
                    {
                        string outputPath = Path.Combine(outputDirectory, baseFileName + ".jpg");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        var jpegOptions = new JpegOptions
                        {
                            VectorRasterizationOptions = vectorOptions
                        };
                        image.Save(outputPath, jpegOptions);
                    }

                    // Convert to BMP
                    {
                        string outputPath = Path.Combine(outputDirectory, baseFileName + ".bmp");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        var bmpOptions = new BmpOptions
                        {
                            VectorRasterizationOptions = vectorOptions
                        };
                        image.Save(outputPath, bmpOptions);
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
 * 1. When you need to automatically transform a collection of legacy WMF vector graphics into web‑friendly raster formats such as PNG, JPEG, and BMP for display in browsers.
 * 2. When a document processing pipeline must generate multiple image versions from WMF diagrams to support different downstream applications like reporting, printing, and thumbnail creation.
 * 3. When you are building a batch migration tool that converts archived WMF assets to modern image formats without manually opening each file.
 * 4. When an e‑learning platform requires converting instructor‑provided WMF illustrations into PNG for high‑quality online viewing and JPEG for email attachments.
 * 5. When a Windows desktop application needs to export user‑drawn WMF sketches into BMP for legacy system compatibility while also providing PNG and JPEG alternatives.
 */
