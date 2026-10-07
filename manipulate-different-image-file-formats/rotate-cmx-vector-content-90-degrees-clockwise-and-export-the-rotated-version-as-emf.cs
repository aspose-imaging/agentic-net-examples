// HOW-TO: Rotate CMX Vector 90 Degrees Clockwise and Save as EMF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.cmx";
            string outputPath = "output.emf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                var options = new EmfOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to display a CMX drawing in a Windows application that only supports EMF, they can rotate the vector and convert it.
 * 2. When preparing printed reports that require landscape orientation, rotating the CMX artwork 90° and saving as EMF ensures correct layout.
 * 3. When integrating legacy CAD data into a .NET reporting engine that consumes EMF, the code provides a quick way to re‑orient and export the graphics.
 * 4. When automating batch processing of CMX files to match a corporate branding guideline that mandates a specific orientation, this snippet can be used in a scheduled job.
 * 5. When a user uploads a CMX file to a web service and expects a rotated EMF preview for thumbnail generation, the code performs the transformation on the server.
 */
