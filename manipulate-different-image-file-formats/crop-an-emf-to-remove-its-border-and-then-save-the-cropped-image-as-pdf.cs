using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.pdf";

        try
        {
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
                // Cast to EmfImage
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not an EMF image.");
                    return;
                }

                // Define a rectangle that removes a 10‑pixel border from each side
                var cropRect = new Aspose.Imaging.Rectangle(
                    x: 10,
                    y: 10,
                    width: emfImage.Width - 20,
                    height: emfImage.Height - 20);

                // Crop the image
                emfImage.Crop(cropRect);

                // Save the cropped image as PDF
                emfImage.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to remove unwanted white space from vector‑based EMF diagrams before embedding them in a PDF report.
 * 2. When an application must batch‑process legacy EMF icons, trim their borders, and generate printable PDF catalogs.
 * 3. When a Windows desktop tool converts user‑drawn EMF charts into PDF slides while ensuring the content fits tightly without extra margins.
 * 4. When a document‑generation service sanitizes incoming EMF files by cropping peripheral artifacts and saves the clean image as a PDF for archiving.
 * 5. When a C# backend service prepares EMF logos for marketing materials, cropping the edges and exporting them as high‑quality PDF assets.
 */