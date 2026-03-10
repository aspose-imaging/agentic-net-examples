using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input JPG files to merge
            string[] jpgPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Output PDF file
            string outputPdfPath = "merged_output.pdf";

            // Collect sizes of all JPG images
            List<Size> sizes = new List<Size>();
            foreach (string path in jpgPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for vertical stacking
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                canvasHeight += sz.Height;
            }

            // Create TIFF options for the canvas
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource("temp_canvas.tif", false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create a TIFF canvas
            using (RasterImage canvas = (RasterImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                // Merge each JPG onto the canvas vertically
                foreach (string path in jpgPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the merged canvas as PDF
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPdfPath, pdfOptions);
            }

            // Clean up temporary TIFF file
            if (File.Exists("temp_canvas.tif"))
            {
                File.Delete("temp_canvas.tif");
            }
        }
    }
}