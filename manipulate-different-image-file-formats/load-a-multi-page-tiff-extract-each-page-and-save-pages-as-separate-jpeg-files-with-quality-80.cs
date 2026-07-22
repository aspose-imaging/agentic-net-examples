using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = "input.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate over each frame (page)
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Hardcoded output path for each page
                    string outputPath = $"output_page_{i + 1}.jpg";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                    // JPEG save options with quality 80
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 80
                    };

                    // Save the current frame as a JPEG file
                    tiffImage.Frames[i].Save(outputPath, jpegOptions);
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
 * 1. When a medical imaging system stores patient scans as multi‑page TIFF files and a developer uses Aspose.Imaging for .NET to extract each page and save JPEG previews at quality 80 for a web portal.
 * 2. When a document management workflow receives scanned contracts in a multi‑page TIFF and needs to use C# with Aspose.Imaging to split the file into individual JPEG pages (quality 80) for email attachments.
 * 3. When a publishing pipeline receives high‑resolution TIFF artwork and a developer leverages Aspose.Imaging for .NET to convert each page into a JPEG image with quality 80 for fast thumbnail generation.
 * 4. When a GIS application exports multi‑band satellite imagery as a TIFF and the code uses Aspose.Imaging in C# to break it into separate JPEG tiles (quality 80) for mobile map display.
 * 5. When an archival tool processes historical newspaper archives stored as multi‑page TIFFs and employs Aspose.Imaging for .NET to save each page as a JPEG (quality 80) to feed an OCR engine.
 */