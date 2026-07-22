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
        string inputPath = "input.emf";
        string outputPath = "output\\cropped.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access EMF-specific methods
                EmfImage emfImage = (EmfImage)image;

                // Crop rectangle: x, y, width, height (example values)
                int cropX = 50;
                int cropY = 50;
                int cropWidth = 200;
                int cropHeight = 150;
                emfImage.Crop(cropX, cropY, cropWidth, cropHeight);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the cropped image as PNG
                emfImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to extract a specific region from a Windows Metafile (EMF) and deliver it as a web‑friendly PNG for a reporting dashboard, they can use this code to load, crop with integer coordinates, and save the result.
 * 2. When an application must convert legacy vector graphics stored in EMF files into raster PNG thumbnails of defined size for preview panes, this snippet shows how to perform the crop and conversion in C# with Aspose.Imaging.
 * 3. When a document‑generation system has to isolate a logo or diagram inside an EMF file and embed the cropped PNG into PDF invoices, the code demonstrates the required loading, integer‑based cropping, and PNG saving steps.
 * 4. When a batch‑processing tool processes a folder of EMF assets and needs to remove unwanted margins by cropping to exact pixel bounds before archiving them as PNG images, this example provides the necessary C# workflow.
 * 5. When a GIS or CAD integration needs to display a selected portion of an EMF map as a PNG overlay on a web map, the developer can employ this code to load the EMF, crop using integer coordinates, and output the PNG.
 */