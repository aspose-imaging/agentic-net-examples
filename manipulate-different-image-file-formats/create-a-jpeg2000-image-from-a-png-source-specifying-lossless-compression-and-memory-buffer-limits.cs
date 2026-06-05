using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"c:\temp\input.png";
            string outputPath = @"c:\temp\output.j2k";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source PNG image
            using (PngImage pngImage = (PngImage)Image.Load(inputPath))
            {
                // Create a JPEG2000 image from the PNG raster image
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(pngImage))
                {
                    // Configure JPEG2000 options for lossless compression and buffer size hint
                    Jpeg2000Options options = new Jpeg2000Options
                    {
                        // Irreversible = false (default) ensures lossless DWT 5-3 compression
                        Irreversible = false,
                        // Example buffer size hint (in bytes); adjust as needed
                        BufferSizeHint = 10 * 1024 * 1024 // 10 MB
                    };

                    // Save the JPEG2000 image with the specified options
                    jpeg2000Image.Save(outputPath, options);
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
 * 1. When a developer needs to archive high‑resolution PNG graphics in a space‑efficient, lossless JPEG2000 format for long‑term storage or regulatory compliance.
 * 2. When a medical imaging application must convert diagnostic PNG scans to JPEG2000 without quality loss while controlling memory usage during the conversion.
 * 3. When a GIS system requires transforming PNG map tiles into JPEG2000 for faster streaming over limited bandwidth, ensuring lossless detail and setting a buffer limit to avoid out‑of‑memory errors.
 * 4. When an e‑learning platform wants to generate lossless JPEG2000 assets from PNG illustrations for inclusion in SCORM packages that support JPEG2000 compression.
 * 5. When a digital publishing workflow needs to batch‑process PNG artwork into JPEG2000 for print‑ready PDFs, using a buffer size hint to keep the conversion within server memory constraints.
 */