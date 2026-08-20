// HOW-TO: Render EMF to PNG Bitmap Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.emf";
            string outputPath = "Output/sample.png";

            // Validate input file existence
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
                // Cast to EmfImage to access size
                EmfImage emfImage = (EmfImage)image;

                // Set up rasterization options for EMF
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Color.White
                };

                // Configure PNG save options with vector rasterization
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rendered bitmap as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to display a Windows Metafile (EMF) on a web page that only supports PNG images.
 * 2. When converting vector-based EMF icons into raster PNG files for use in mobile applications.
 * 3. When generating thumbnail previews of EMF documents for a document management system.
 * 4. When batch‑processing EMF reports to create high‑quality PNG assets for email newsletters.
 * 5. When preserving the original EMF dimensions while rasterizing it to a PNG for printing workflows.
 */
