using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Configure vector rasterization to render text as shapes
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Aspose.Imaging.Color.White,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                };

                // Set TIFF save options with the vector rasterization options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save as TIFF
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
 * 1. When a print shop needs to preserve editable text from a Photoshop PSD that contains embedded EMF captions and deliver a high‑resolution, lossless TIFF for pre‑press workflows.
 * 2. When a digital archiving system must convert legacy PSD files with vector‑based EMF annotations into TIFF images while keeping the text as scalable shapes for future OCR processing.
 * 3. When a web service generates thumbnails of PSD designs and must ensure that any embedded EMF text is rasterized as crisp vector shapes in the output TIFF to maintain visual fidelity across browsers.
 * 4. When a desktop application automates batch conversion of PSD assets containing EMF labels into TIFF files for inclusion in a PDF portfolio, requiring the text to be rendered as vector shapes to avoid pixelation.
 * 5. When a document management solution needs to ingest PSD files with embedded EMF text and store them as TIFFs with white background and single‑bit per pixel text rendering for consistent archival quality.
 */