using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output\cropped.emf";

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
                // Cast to EmfImage to access EMF‑specific members
                EmfImage emfImage = (EmfImage)image;

                // Crop: remove 50 pixels from left and top borders, keep right and bottom unchanged
                int leftShift = 50;   // pixels to remove from the left side
                int rightShift = 0;   // no removal from the right side
                int topShift = 50;    // pixels to remove from the top side
                int bottomShift = 0;  // no removal from the bottom side

                emfImage.Crop(leftShift, rightShift, topShift, bottomShift);

                // Save the cropped image
                emfImage.Save(outputPath);
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
 * 1. When generating printable reports that embed EMF logos, a developer can use EmfImage.Crop to trim a 50‑pixel top‑left margin so the logo aligns perfectly with the page header.
 * 2. When converting legacy EMF diagrams for a web dashboard, cropping the unwanted top‑left border ensures the vector graphic fits within the responsive container without extra whitespace.
 * 3. When preprocessing scanned EMF signatures for digital contracts, removing the top‑left border with EmfImage.Crop improves OCR accuracy by eliminating irrelevant background pixels.
 * 4. When creating a batch script to standardize UI icons stored as EMF files, cropping a consistent left and top offset guarantees uniform icon placement across different screen resolutions.
 * 5. When integrating EMF charts into a C# WinForms application, cropping the top‑left edge prevents overlap with surrounding controls, delivering a cleaner visual layout.
 */