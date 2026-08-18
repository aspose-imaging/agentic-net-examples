// HOW-TO: Create JPEG2000 from BMP with Custom Bits Per Sample in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\source.bmp";
            string outputPath = @"C:\Images\output.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image bmpImage = Image.Load(inputPath))
            {
                // Cast to RasterImage for conversion
                RasterImage raster = bmpImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image.");
                    return;
                }

                // Create JPEG2000 image from raster with custom bits per sample (e.g., 12 bits)
                int customBitsPerSample = 12;
                using (Jpeg2000Image jp2Image = new Jpeg2000Image(raster, customBitsPerSample))
                {
                    // Save JPEG2000 image with default options
                    jp2Image.Save(outputPath, new Jpeg2000Options());

                    // Verify output file size
                    long fileSize = new FileInfo(outputPath).Length;
                    Console.WriteLine($"JPEG2000 file saved. Size: {fileSize} bytes.");
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
 * 1. When you need to convert legacy BMP files to high‑quality JPEG2000 for archival while controlling bit depth.
 * 2. When an application must generate JPEG2000 images with a specific bits‑per‑sample value for medical imaging standards.
 * 3. When you want to programmatically verify the size of the generated JPEG2000 file to ensure it meets storage constraints.
 * 4. When integrating image conversion into a batch process that reads BMP files from disk and outputs JPEG2000 to a designated folder.
 * 5. When you need to handle missing input files or create output directories automatically during image format conversion in C#.
 */
