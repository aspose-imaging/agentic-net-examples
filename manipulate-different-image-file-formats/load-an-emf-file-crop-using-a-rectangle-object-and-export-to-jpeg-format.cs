using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.jpg";

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
                // Example crop rectangle: top-left quarter of the image
                Rectangle cropRect = new Rectangle(0, 0, emfImage.Width / 2, emfImage.Height / 2);
                emfImage.Crop(cropRect);

                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

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
 * 1. When a developer needs to generate a thumbnail of a specific region from a Windows Metafile (EMF) for a web preview, they can load the EMF, crop a rectangle, and save it as a JPEG.
 * 2. When an application must extract the logo area from a vector‑based EMF logo file and convert it to a high‑quality JPEG for email signatures, this code performs the crop and conversion.
 * 3. When a reporting tool has to embed only the top‑left quarter of a large EMF chart into a PDF as a raster image, the developer can use this snippet to crop and export to JPEG.
 * 4. When a document management system needs to create a preview image of a selected page region from an EMF diagram for thumbnail galleries, the code loads, crops, and saves the region as a JPEG.
 * 5. When a migration script must convert legacy EMF icons into compressed JPEG assets while keeping only the relevant icon area, this code provides the necessary cropping and format conversion.
 */