using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Set up EMF rasterization options using the image size
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Create EMF save options
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
 * 1. When a developer needs to convert legacy CorelDRAW CMX drawings into scalable Windows Metafile (EMF) format while rotating the artwork 90° clockwise for proper orientation in a reporting tool.
 * 2. When an automated batch process must reorient technical diagrams stored as CMX files before embedding them into a PowerPoint presentation that only accepts EMF vector images.
 * 3. When a CAD integration service requires rotating imported CMX vector schematics and exporting them as EMF so they can be rendered accurately in a .NET WinForms application.
 * 4. When a document generation system has to adjust the layout of CMX logos by rotating them and saving as EMF to maintain vector quality in printable PDFs.
 * 5. When a migration script needs to transform archived CMX assets, apply a 90‑degree clockwise rotation, and store the result as EMF for compatibility with modern Windows applications.
 */