using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                // Resize using Lanczos resampling (double the size)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Embed digital signature with a password longer than four characters
                image.EmbedDigitalSignature("securePassword123");

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When a developer needs to double the size of a high‑resolution TIFF scan for detailed printing while adding a password‑protected digital signature to ensure authenticity, this code provides a straightforward solution.
 * 2. When a medical imaging system must enlarge DICOM‑converted TIFF X‑ray images using Lanczos resampling for better visual analysis and embed a secure signature to comply with data integrity regulations, the example can be applied.
 * 3. When a document management application requires up‑scaling archived TIFF files for web preview and wants to embed a digital signature with a strong password to prevent tampering, this snippet handles both tasks.
 * 4. When a GIS workflow needs to resize large satellite TIFF tiles with high‑quality Lanczos interpolation and then lock the files with a password‑protected digital signature before distribution, the code meets the requirement.
 * 5. When an e‑commerce platform processes product catalog TIFF images, enlarges them for high‑resolution displays, and embeds a secure digital signature to verify the source, developers can reuse this example.
 */