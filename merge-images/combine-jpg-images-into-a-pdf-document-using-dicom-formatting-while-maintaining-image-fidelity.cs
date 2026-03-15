using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the source JPG images
        string[] imagePaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output PDF file path
        string outputPdfPath = "combined.pdf";

        // Load the first image to determine canvas size
        int canvasWidth;
        int canvasHeight;
        using (RasterImage firstImage = (RasterImage)Image.Load(imagePaths[0]))
        {
            canvasWidth = firstImage.Width;
            canvasHeight = firstImage.Height;
        }

        // Create a DICOM multi‑page image canvas (in memory)
        using (DicomImage dicomCanvas = (DicomImage)Image.Create(new DicomOptions(), canvasWidth, canvasHeight))
        {
            bool isFirstPage = true;

            foreach (string path in imagePaths)
            {
                using (RasterImage raster = (RasterImage)Image.Load(path))
                {
                    // Ensure each image matches the canvas size
                    if (raster.Width != canvasWidth || raster.Height != canvasHeight)
                    {
                        raster.Resize(canvasWidth, canvasHeight, ResizeType.NearestNeighbourResample);
                    }

                    // Load pixel data
                    int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);

                    if (isFirstPage)
                    {
                        // First page already exists in the canvas
                        dicomCanvas.SaveArgb32Pixels(dicomCanvas.Bounds, pixels);
                        isFirstPage = false;
                    }
                    else
                    {
                        // Add a new page and set its pixel data
                        DicomPage page = dicomCanvas.AddPage();
                        page.SaveArgb32Pixels(page.Bounds, pixels);
                    }
                }
            }

            // Save the multi‑page DICOM image as a PDF document
            dicomCanvas.Save(outputPdfPath, new PdfOptions());
        }
    }
}