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
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\output\sample_cropped.png";

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
                // Cast to EmfImage to access EMF-specific methods
                EmfImage emfImage = (EmfImage)image;

                // Define border sizes to remove (e.g., 20 pixels from left and top)
                int leftShift = 20;   // remove 20 pixels from the left
                int rightShift = 0;   // keep right side unchanged
                int topShift = 20;    // remove 20 pixels from the top
                int bottomShift = 0;  // keep bottom side unchanged

                // Crop the image using the shift overload
                emfImage.Crop(leftShift, rightShift, topShift, bottomShift);

                // Save the cropped image (PNG format inferred from extension)
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
 * 1. When a developer needs to remove unwanted printer margins from a scanned EMF diagram before converting it to a PNG for web display.
 * 2. When an application generates EMF charts with a default 20‑pixel padding and the developer wants to trim the top‑left border to align the chart with other UI elements.
 * 3. When a batch‑processing tool must crop the left and top edges of legacy EMF assets to fit them into a fixed‑size thumbnail grid.
 * 4. When a reporting system exports vector graphics as EMF and then crops the top‑left corner to eliminate extra whitespace before embedding the image in a PDF.
 * 5. When a C# service receives user‑uploaded EMF files and needs to programmatically remove a 20‑pixel border so the resulting PNG matches the layout of a mobile app screen.
 */