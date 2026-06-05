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
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\Result\rotated.jpg";

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
                var jpegOptions = new JpegOptions();
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
 * 1. When a print shop needs to convert client‑provided EPS logos into rotated JPEG thumbnails for web previews, they can use this C# Aspose.Imaging code.
 * 2. When an e‑commerce platform must display product diagrams originally supplied as EPS files at a 45‑degree angle in JPEG format on mobile devices, the snippet provides a quick solution.
 * 3. When a marketing automation script has to batch‑process EPS artwork, rotate it for a stylized banner, and store the result as JPEG for email campaigns, this code handles the conversion.
 * 4. When a GIS application receives EPS map overlays that must be oriented diagonally and saved as JPEG tiles for fast rendering, developers can apply the shown rotation routine.
 * 5. When a desktop publishing tool needs to preview EPS illustrations with a 45° tilt in a JPEG preview pane, the provided C# example performs the necessary image processing.
 */