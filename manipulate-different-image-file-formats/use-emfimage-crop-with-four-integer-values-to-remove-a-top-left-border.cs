using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_cropped.emf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access EMF‑specific members
                EmfImage emfImage = (EmfImage)image;

                // Define border sizes to remove from the top‑left corner
                int leftBorder = 20;   // pixels to remove from the left side
                int topBorder = 15;    // pixels to remove from the top side

                // Crop using shifts: left, right, top, bottom
                emfImage.Crop(leftBorder, 0, topBorder, 0);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a developer needs to remove unwanted printer margins from a vector‑based EMF report before embedding it in a PDF document.
 * 2. When an application must trim a fixed‑size left and top border from scanned EMF diagrams to align them with a template in a C# WinForms UI.
 * 3. When a batch‑processing service has to clean up legacy EMF icons by cropping the extra space on the top‑left corner using Aspose.Imaging for .NET.
 * 4. When a GIS tool requires precise cropping of EMF map overlays to eliminate offset padding so the layers line up correctly in a visualisation.
 * 5. When a document‑generation system automatically crops the header area of EMF charts to fit within a predefined layout without altering the rest of the image.
 */