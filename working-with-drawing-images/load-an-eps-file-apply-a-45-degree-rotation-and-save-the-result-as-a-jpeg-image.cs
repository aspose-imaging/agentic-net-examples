// HOW-TO: Rotate EPS Image 45 Degrees and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\source.eps";
        string outputPath = @"C:\Images\result.jpg";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                // Rotate the image by 45 degrees around its center
                image.Rotate(45f);

                // Save the rotated image as JPEG
                var jpegOptions = new JpegOptions(); // default JPEG options
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to display a vector EPS logo at a specific angle on a web page that only supports JPEG images.
 * 2. When converting printed artwork stored as EPS into a rotated raster JPEG for inclusion in a PDF brochure.
 * 3. When preprocessing EPS diagrams for a machine‑learning pipeline that requires JPEG inputs with a fixed orientation.
 * 4. When generating thumbnails of EPS files with a 45° rotation for a gallery view in a C# desktop application.
 * 5. When automating batch processing of EPS drawings to create rotated JPEG previews for an e‑commerce product catalog.
 */
