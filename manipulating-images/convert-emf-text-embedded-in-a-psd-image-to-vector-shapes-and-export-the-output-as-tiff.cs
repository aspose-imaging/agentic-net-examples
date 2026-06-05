using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\input.psd";
            string outputPath = @"C:\Images\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Configure vector rasterization to render embedded EMF text as shapes
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    RenderMode = EmfRenderMode.Auto,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Set up TIFF save options with the vector rasterization options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save the result as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to preserve the editability of text from a Photoshop PSD that contains embedded EMF captions while converting the file to a high‑resolution TIFF for archival or printing, they can use this code to rasterize the EMF text as vector shapes.
 * 2. When an automated workflow must generate print‑ready TIFF files from PSD assets that include vector‑based annotations stored as EMF, this snippet ensures the annotations are rendered accurately as scalable shapes.
 * 3. When a .NET application processes user‑uploaded PSD designs and must output a TIFF that complies with a publishing system’s requirement for vector‑based text rendering, the code provides the necessary conversion.
 * 4. When a batch‑processing tool needs to convert a library of PSD files with embedded EMF logos into TIFFs while maintaining crisp text edges and avoiding anti‑aliasing artifacts, this example shows how to configure the rasterization options.
 * 5. When integrating Aspose.Imaging into a C# service that generates searchable PDFs from PSD sources, converting the PSD to TIFF with vectorized EMF text first ensures the text can later be extracted reliably.
 */