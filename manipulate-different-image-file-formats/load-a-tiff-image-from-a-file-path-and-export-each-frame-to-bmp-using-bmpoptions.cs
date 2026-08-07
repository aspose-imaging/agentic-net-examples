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
        string inputPath = "input.tif";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the TIFF image
            using (TiffImage tiffImage = Image.Load(inputPath) as TiffImage)
            {
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("Failed to load TIFF image.");
                    return;
                }

                // Iterate through each frame and save as BMP
                TiffFrame[] frames = tiffImage.Frames;
                for (int i = 0; i < frames.Length; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as BMP using BmpOptions
                    frames[i].Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to extract individual pages from a multi‑page TIFF document and save them as separate BMP files for legacy Windows applications.
 * 2. When an imaging pipeline requires converting high‑resolution scanned TIFF images into BMP format to ensure compatibility with a third‑party OCR engine that only accepts BMP input.
 * 3. When a batch‑processing tool must archive each frame of a TIFF satellite image as BMP thumbnails for quick preview in a web gallery.
 * 4. When a medical imaging system has to transform each slice of a DICOM‑exported TIFF stack into BMP files for integration with older diagnostic software.
 * 5. When a developer is building a document‑conversion service that separates TIFF layers into BMP images to allow downstream editing in graphics editors that do not support TIFF.
 */