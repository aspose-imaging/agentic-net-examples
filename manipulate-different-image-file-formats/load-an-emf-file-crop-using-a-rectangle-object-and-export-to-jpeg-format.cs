using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.emf";
        string outputPath = "Output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Define the crop rectangle (x, y, width, height)
                Rectangle cropRect = new Rectangle(50, 50, 200, 150);
                emfImage.Crop(cropRect);

                JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When a developer needs to extract a specific portion of a vector‑based EMF diagram and deliver it as a lightweight JPEG thumbnail for a web preview.
 * 2. When an application must convert legacy Windows Metafile (EMF) reports into JPEG images while trimming margins to fit a printable label size.
 * 3. When a document‑management system has to generate cropped JPEG snapshots of EMF logos for inclusion in email signatures.
 * 4. When a GIS tool requires converting and cropping EMF map overlays into JPEG tiles for faster client‑side rendering.
 * 5. When a batch‑processing service automates the transformation of EMF icons into cropped JPEG assets for mobile app UI assets.
 */