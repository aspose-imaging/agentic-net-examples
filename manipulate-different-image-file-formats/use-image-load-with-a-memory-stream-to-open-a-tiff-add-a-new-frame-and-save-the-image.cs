// HOW-TO: Load TIFF From Memory Stream, Add Blank Frame, and Save in C# (Aspose.Imaging for .NET)
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
        // Hardcoded input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TIFF image from a memory stream
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            {
                using (Image image = Image.Load(memoryStream))
                {
                    // Ensure the loaded image is a TIFF image
                    if (image is TiffImage tiffImage)
                    {
                        // Create a new blank frame (100x100 pixels) with default options
                        TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                        TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                        // Add the new frame to the TIFF image
                        tiffImage.AddFrame(newFrame);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the modified TIFF image
                        TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                        tiffImage.Save(outputPath, saveOptions);
                    }
                    else
                    {
                        Console.Error.WriteLine("The loaded image is not a TIFF image.");
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
 * 1. When you need to programmatically insert an empty page into an existing multi‑page TIFF without writing the file to disk first.
 * 2. When you want to process a TIFF received as a byte array (for example from a web API) and modify its frames entirely in memory.
 * 3. When you must ensure the output directory exists before saving a modified TIFF to avoid runtime errors.
 * 4. When you are using Aspose.Imaging in C# to add custom frames to scanned documents for archival or printing purposes.
 * 5. When you need to verify that a loaded image is a TIFF before performing TIFF‑specific operations such as adding frames.
 */
