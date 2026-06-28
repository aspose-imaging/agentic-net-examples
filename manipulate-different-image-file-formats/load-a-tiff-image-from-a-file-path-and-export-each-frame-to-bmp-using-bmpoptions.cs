using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputDirectory = @"C:\Images\Frames";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access frames
                TiffImage tiffImage = image as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a TIFF image.");
                    return;
                }

                // Options for BMP export
                BmpOptions bmpOptions = new BmpOptions();

                // Export each frame to a separate BMP file
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    TiffFrame frame = tiffImage.Frames[i];
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as BMP
                    frame.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging system receives multi‑page TIFF scans and needs to convert each page to BMP for display in a legacy viewer.
 * 2. When a document management workflow extracts individual pages from a multi‑frame TIFF invoice and saves them as BMP files for OCR processing.
 * 3. When a printing service separates each frame of a high‑resolution TIFF artwork into BMP images to apply per‑page color corrections before rasterization.
 * 4. When a GIS application converts each layer stored as a frame in a geospatial TIFF file into BMP tiles for use in a web‑based map viewer.
 * 5. When an archival tool migrates old multi‑page TIFF archives to BMP format to ensure compatibility with Windows thumbnail generators.
 */