// HOW-TO: Rotate CMX Vector 90 Degrees Clockwise and Save as EMF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\sample_rotated.emf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX vector image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate the image 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Set up EMF rasterization options using the image size
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Create EMF save options with the rasterization settings
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
 * 1. When a CAD application needs to display a CMX drawing rotated for landscape orientation and export it as a Windows Metafile for compatibility with legacy reporting tools.
 * 2. When a batch processing script must convert a library of CMX icons to EMF after rotating them to match a new UI layout.
 * 3. When a developer integrates Aspose.Imaging into a document generation system that requires rotated vector graphics in EMF format for inclusion in Word documents.
 * 4. When an automated build pipeline has to re‑orient technical illustrations stored as CMX files before embedding them into PDF reports that use EMF placeholders.
 * 5. When a GIS tool needs to adjust the orientation of vector map symbols saved as CMX and output them as EMF for use in Windows‑based mapping applications.
 */
