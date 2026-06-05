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
            // Hardcoded input and output paths
            string inputPath = "input\\input.tif";
            string outputPath = "output\\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image from a memory stream
            using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(inputPath)))
            using (TiffImage tiffImage = (TiffImage)Image.Load(ms))
            {
                // Create options for the new frame (same size as existing image)
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Photometric = TiffPhotometrics.Rgb;

                // Create a new blank frame
                TiffFrame newFrame = new TiffFrame(frameOptions, tiffImage.Width, tiffImage.Height);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the modified TIFF to the output path
                tiffImage.Save(outputPath);
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
 * 1. When a document management system needs to append a blank page to an existing multi‑page TIFF scanned document without writing the file to disk first.
 * 2. When a medical imaging application must load a DICOM‑converted TIFF into memory, add an extra frame for annotations, and save the updated file for archival.
 * 3. When a printing workflow requires inserting a placeholder page into a multi‑page TIFF invoice batch using C# and Aspose.Imaging’s memory‑stream loading.
 * 4. When a web service receives a TIFF image as a byte array, needs to programmatically add a new frame (e.g., a logo) before returning the modified image to the client.
 * 5. When an automated archival script processes TIFF files, adds a blank frame for future metadata insertion, and saves the result directly to a network folder.
 */