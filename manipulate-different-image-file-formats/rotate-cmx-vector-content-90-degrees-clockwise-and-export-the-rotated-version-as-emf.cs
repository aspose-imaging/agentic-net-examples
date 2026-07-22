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
            string inputPath = "C:\\Images\\sample.cmx";
            string outputPath = "C:\\Images\\sample_rotated.emf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Set up EMF export options with appropriate page size
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };
                var emfOptions = new EmfOptions
                {
                    VectorRasterizationOptions = vectorOptions
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
 * 1. When a CAD application needs to convert legacy CorelDRAW CMX drawings to Windows Metafile (EMF) format while rotating the artwork 90° clockwise for proper orientation in reports.
 * 2. When an automated batch‑processing service must re‑orient scanned vector diagrams stored as CMX files and export them as EMF for inclusion in Microsoft Office documents.
 * 3. When a document‑generation system programmatically rotates a CMX logo 90 degrees to match a page layout and saves it as an EMF vector image for high‑quality printing.
 * 4. When a migration tool updates legacy vector assets by loading CMX files in C#, applying a clockwise rotation, and converting them to EMF to preserve scalability in modern Windows applications.
 * 5. When a GIS workflow requires rotating a CMX map layer 90° clockwise before rasterizing it to an EMF file for seamless integration with other vector‑based GIS layers.
 */