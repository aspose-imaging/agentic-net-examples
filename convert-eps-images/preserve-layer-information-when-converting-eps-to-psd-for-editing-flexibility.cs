using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Prepare PSD save options
                var psdOptions = new PsdOptions();

                // Configure vector rasterization to preserve vector data as layers
                psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                };

                // Enable vectorization options (required for layer preservation)
                psdOptions.VectorizationOptions = new PsdVectorizationOptions();

                // Save as PSD preserving layer information
                epsImage.Save(outputPath, psdOptions);
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
 * 1. When a graphic design workflow needs to convert an EPS illustration into a PSD file so that each vector element becomes an editable Photoshop layer.
 * 2. When an automated build script must batch‑process EPS assets and generate PSDs with preserved layers for downstream compositing in Adobe Photoshop.
 * 3. When a web application allows users to upload EPS logos and then provides a downloadable PSD version that retains the original vector shapes as separate layers for further editing.
 * 4. When a digital publishing system has to convert print‑ready EPS files into layered PSDs to enable designers to tweak colors, masks, or effects without rasterizing the whole image.
 * 5. When a C#‑based image processing service needs to keep the EPS background color and page dimensions intact while saving to PSD with vector rasterization options for accurate layer preservation.
 */