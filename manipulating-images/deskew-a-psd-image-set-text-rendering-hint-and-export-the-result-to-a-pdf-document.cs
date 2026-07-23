using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.psd";
        string outputPath = "Output/result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PSD image
            using (Image psdImage = Image.Load(inputPath))
            {
                // Save to a temporary TIFF for deskewing
                string tempTiffPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.tif");
                Directory.CreateDirectory(Path.GetDirectoryName(tempTiffPath));

                using (var tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    psdImage.Save(tempTiffPath, tiffOptions);
                }

                // Load the temporary TIFF and deskew
                using (Image tiffImage = Image.Load(tempTiffPath))
                {
                    ((TiffImage)tiffImage).NormalizeAngle(false, Color.White);

                    // Prepare PDF options with text rendering hint
                    using (var pdfOptions = new PdfOptions())
                    {
                        pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = tiffImage.Width,
                            PageHeight = tiffImage.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };

                        tiffImage.Save(outputPath, pdfOptions);
                    }
                }

                // Optionally delete the temporary TIFF file
                if (File.Exists(tempTiffPath))
                {
                    File.Delete(tempTiffPath);
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
 * 1. When a graphic designer needs to correct the orientation of a scanned Photoshop PSD file and deliver a clean, deskewed PDF to a client.
 * 2. When an e‑learning platform automatically converts uploaded PSD lesson slides into PDF handouts while applying a single‑bit‑per‑pixel text rendering hint for crisp on‑screen readability.
 * 3. When a printing service batch‑processes PSD artwork, normalizes its angle via an intermediate TIFF, and generates PDF proofs with a white background and no smoothing to meet exact print specifications.
 * 4. When a document management system ingests PSD files, removes any skew, and stores them as searchable PDF documents with consistent page dimensions and preserved text quality.
 * 5. When a legal firm receives PSD evidence, needs to deskew the image, preserve precise text rendering, and export the result to PDF for secure archival and review.
 */