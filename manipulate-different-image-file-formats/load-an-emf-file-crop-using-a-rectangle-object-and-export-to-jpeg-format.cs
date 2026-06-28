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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access Crop method
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid EMF image.");
                    return;
                }

                // Define the cropping rectangle (example values)
                var cropRect = new Rectangle(50, 50, 200, 150);
                emfImage.Crop(cropRect);

                // Save as JPEG
                var jpegOptions = new JpegOptions();
                emfImage.Save(outputPath, jpegOptions);
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
 * 1. When a desktop file explorer needs to generate thumbnail previews of vector EMF drawings, it can load the EMF, crop the region of interest, and save it as a JPEG thumbnail.
 * 2. When a reporting tool must embed a specific portion of a large EMF chart into a PDF report, it can extract the desired rectangle from the EMF and convert it to JPEG for embedding.
 * 3. When a web service receives user‑uploaded EMF logos and must display a cropped preview on a website, it can use this code to crop the logo and output a JPEG image.
 * 4. When an automated batch process has to convert legacy EMF diagrams into JPEG images of a specific size for archival, it can programmatically crop each diagram before saving.
 * 5. When a mobile app syncs vector graphics from a Windows system and needs a rasterized, cropped JPEG version for faster loading on the device, this code performs the conversion.
 */