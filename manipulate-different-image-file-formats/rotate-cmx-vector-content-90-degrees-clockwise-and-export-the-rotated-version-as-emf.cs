using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\sample_rotated.emf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX vector image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Set up EMF rasterization options using the image size
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Create EMF save options with the rasterization settings
                var emfOptions = new EmfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rotated image as EMF
                image.Save(outputPath, emfOptions);
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
 * 1. When a developer needs to rotate a CMX vector drawing 90 degrees clockwise and export it as an EMF file for inclusion in a Windows Forms report.
 * 2. When a .NET application must convert legacy CorelDRAW CMX graphics into scalable EMF format after applying a 90‑degree clockwise rotation for correct orientation in Office documents.
 * 3. When an automated image‑processing pipeline requires loading a CMX file, rotating the vector content, and saving the result as an EMF to preserve vector quality for printing.
 * 4. When a developer is building a batch conversion tool that processes multiple CMX files, applies a 90‑degree clockwise RotateFlip operation, and outputs EMF files for use in GIS mapping software.
 * 5. When a C# service needs to ensure that a CMX logo is rotated to match branding guidelines and then delivered as an EMF vector image for high‑resolution rendering in PDFs.
 */