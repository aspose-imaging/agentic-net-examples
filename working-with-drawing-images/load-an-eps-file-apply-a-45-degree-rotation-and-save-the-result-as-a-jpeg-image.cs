using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Rotate the image by 45 degrees
                epsImage.Rotate(45f);

                // Save the rotated image as JPEG
                var jpegOptions = new JpegOptions();
                epsImage.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a graphic designer needs to convert a vector EPS logo into a rotated JPEG thumbnail for a web page preview.
 * 2. When an e‑commerce platform must display product brochures originally saved as EPS files at a 45‑degree angle in a JPEG carousel.
 * 3. When a publishing workflow requires batch processing of EPS illustrations, rotating them for layout alignment and saving them as JPEGs for quick preview.
 * 4. When a mobile app backend receives EPS assets from users, rotates them to match orientation guidelines, and stores them as JPEG images for faster delivery.
 * 5. When a document management system automates the conversion of EPS diagrams into rotated JPEG snapshots for indexing and search.
 */