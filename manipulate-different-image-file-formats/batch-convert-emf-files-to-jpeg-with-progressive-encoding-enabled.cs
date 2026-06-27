using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputEmf";
            string outputFolder = @"C:\OutputJpeg";

            // Get all EMF files in the input folder
            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output JPEG path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure JPEG options with progressive compression
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        CompressionType = JpegCompressionMode.Progressive,
                        Quality = 100 // optional: set quality to maximum
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
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
 * 1. When a Windows desktop application must generate web‑ready preview images from a collection of vector EMF charts, converting them to progressive JPEGs for faster page load.
 * 2. When an automated reporting pipeline needs to archive high‑resolution EMF diagrams as space‑efficient JPEG files with progressive compression to reduce storage while preserving visual quality.
 * 3. When a migration script moves legacy EMF assets from a file server to a cloud‑based CMS that only accepts JPEG images, requiring batch conversion with Aspose.Imaging in C#.
 * 4. When a digital asset management system processes incoming EMF logos and creates progressive JPEG thumbnails for responsive design across browsers.
 * 5. When a document processing service extracts embedded EMF graphics from PDFs and saves them as progressive JPEGs for downstream image analysis or OCR tasks.
 */