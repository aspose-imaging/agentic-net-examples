// HOW-TO: Rotate JPEG by 33 Degrees with Gray Background and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output\\rotated.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                image.Rotate(33f, true, Aspose.Imaging.Color.Gray);
                image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to generate a rotated thumbnail of a JPEG for a web gallery while preserving a neutral gray fill and outputting a BMP for legacy systems.
 * 2. When a desktop application must reorient scanned photos by a specific angle and store them in BMP for compatibility with older Windows imaging tools.
 * 3. When an automated batch process has to rotate product images by 33 degrees and convert them to BMP to meet a printing pipeline’s file requirements.
 * 4. When you are preparing assets for a game engine that only accepts BMP files and requires a consistent background color after rotation.
 * 5. When a document management system must normalize image orientation and convert various formats to BMP with a gray background for archival consistency.
 */
