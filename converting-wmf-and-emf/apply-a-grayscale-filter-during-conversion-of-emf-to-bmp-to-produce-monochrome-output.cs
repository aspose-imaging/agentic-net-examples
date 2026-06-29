using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input.emf";
        string outputPath = @"C:\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Set rasterization options for BMP conversion
                var rasterOptions = new BmpOptions
                {
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size
                    }
                };

                // Save as BMP
                emfImage.Save(outputPath, rasterOptions);
            }

            // Load the generated BMP to apply grayscale
            using (Image bmpImage = Image.Load(outputPath))
            {
                // Cast to BMP image type which supports Grayscale()
                if (bmpImage is BmpImage bmp)
                {
                    bmp.Grayscale(); // Convert to grayscale
                    bmp.Save(outputPath); // Overwrite with grayscale version
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a BMP image; cannot apply grayscale.");
                }
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
 * 1. When a developer needs to generate monochrome preview thumbnails of vector EMF diagrams for a Windows desktop application, they can use this code to rasterize the EMF to BMP and apply a grayscale filter.
 * 2. When a reporting system must embed low‑resolution black‑and‑white versions of EMF logos into PDF or Word documents, the code converts the vector graphics to BMP and forces grayscale for consistent printing.
 * 3. When an automated batch job processes a legacy archive of EMF files and stores them as grayscale BMP images for archival storage or OCR preprocessing, this snippet provides the conversion pipeline.
 * 4. When a web service receives user‑uploaded EMF drawings and needs to return a grayscale BMP preview for faster loading on bandwidth‑limited devices, the code performs the rasterization and color reduction in C#.
 * 5. When a quality‑control tool validates that all exported graphics from a CAD system are saved as monochrome BMP files to meet regulatory standards, the developer can employ this code to enforce the grayscale conversion during EMF‑to‑BMP transformation.
 */