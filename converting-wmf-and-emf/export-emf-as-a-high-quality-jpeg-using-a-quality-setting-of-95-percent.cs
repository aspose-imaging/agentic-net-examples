// HOW-TO: Export EMF to High Quality JPEG with 95% Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.emf";
            string outputPath = "output\\sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with quality 95
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 95
                };

                // Save as high‑quality JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert vector EMF drawings into raster JPEG files for web display while preserving visual fidelity, they can use this code.
 * 2. When an application must generate printable thumbnails of EMF diagrams with a specific JPEG compression level of 95 percent, this snippet provides the required workflow.
 * 3. When integrating Aspose.Imaging into a C# service that archives engineering schematics as high‑quality JPEG images for archival storage, the code handles the conversion and quality setting.
 * 4. When a desktop tool requires batch processing of multiple EMF files into JPEGs with consistent 95 percent quality to maintain brand standards, the example shows how to load, configure, and save each image.
 * 5. When a reporting system needs to embed EMF charts into PDF or HTML reports as JPEG images without noticeable loss, this approach ensures the images are exported at a high quality setting.
 */
