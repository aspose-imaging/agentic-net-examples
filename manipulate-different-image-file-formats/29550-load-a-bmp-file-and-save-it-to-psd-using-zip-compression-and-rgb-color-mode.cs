using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.psd";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options: RLE compression and RGB color mode
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb
                };

                // Save the image as PSD with the specified options
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy BMP graphics into Photoshop‑compatible PSD files using Aspose.Imaging for .NET with RLE compression and RGB color mode, this code provides a straightforward C# solution.
 * 2. When an automated build pipeline must batch‑process BMP assets and generate compressed PSD files for a design workflow, the example shows how to load, configure PsdOptions, and save the images in C#.
 * 3. When a desktop application requires on‑the‑fly conversion of user‑uploaded BMP images to PSD format while preserving color fidelity and reducing file size via RLE compression, the snippet demonstrates the necessary steps.
 * 4. When a migration script has to move image resources from a Windows‑based BMP repository to a Photoshop‑oriented PSD library, this code illustrates how to verify file existence, create output directories, and apply RGB color mode using Aspose.Imaging.
 * 5. When a developer is implementing a C# service that needs to generate PSD previews from BMP source files for a web portal, the example shows how to load the BMP, set CompressionMethod.RLE, and save the result as an RGB PSD.
 */