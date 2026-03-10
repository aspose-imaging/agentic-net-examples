using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;   // for BmpOptions
using Aspose.Imaging.FileFormats.Pdf;   // for PdfOptions

public class JpgToPdfConverter
{
    /// <summary>
    /// Merges multiple JPG files into a single PDF document.
    /// Each JPG is first saved as a BMP (DIB compatible) in memory,
    /// then the BMP images are added as separate pages of the PDF.
    /// </summary>
    /// <param name="jpgPaths">Array of full paths to source JPG files.</param>
    /// <param name="outputPdfPath">Full path where the resulting PDF will be saved.</param>
    public static void ConvertJpgsToPdf(string[] jpgPaths, string outputPdfPath)
    {
        // Hold the raster images that will become PDF pages
        var pdfPages = new List<RasterImage>();

        // Load each JPG, convert to BMP (DIB) and keep the raster image in memory
        foreach (string jpgPath in jpgPaths)
        {
            // Load JPG using Aspose.Imaging's load rule
            using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
            {
                // Save the JPG as BMP into a memory stream (BMP = DIB format)
                using (MemoryStream dibStream = new MemoryStream())
                {
                    BmpOptions bmpOptions = new BmpOptions();   // create rule for BMP saving
                    jpgImage.Save(dibStream, bmpOptions);
                    dibStream.Position = 0;                     // reset stream for reading

                    // Load the BMP back as a raster image – this will be a PDF page
                    RasterImage dibImage = (RasterImage)Image.Load(dibStream);
                    pdfPages.Add(dibImage);                     // keep reference for later
                }
            }
        }

        if (pdfPages.Count == 0)
            throw new InvalidOperationException("No JPG files were provided.");

        // Prepare PDF saving options
        PdfOptions pdfOptions = new PdfOptions
        {
            // Use Flate compression for the embedded images
            Compression = PdfImageCompressionOptions.Flate,

            // Multi‑page options – each raster image becomes a separate PDF page
            MultiPageOptions = new MultiPageOptions
            {
                Pages = pdfPages
            }
        };

        // Save the first page image as a PDF; the MultiPageOptions will cause all
        // images in the collection to be written as subsequent pages.
        pdfPages[0].Save(outputPdfPath, pdfOptions);

        // Dispose all temporary raster images
        foreach (RasterImage page in pdfPages)
        {
            page.Dispose();
        }
    }
}