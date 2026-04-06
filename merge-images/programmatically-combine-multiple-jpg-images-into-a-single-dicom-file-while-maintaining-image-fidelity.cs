using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Hardcoded output DICOM file
        string outputPath = "combined.dcm";

        // Validate input files
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load first image to obtain canvas size
        int canvasWidth;
        int canvasHeight;
        using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
        {
            canvasWidth = first.Width;
            canvasHeight = first.Height;
        }

        // Prepare DICOM options with output source
        DicomOptions dicomOptions = new DicomOptions
        {
            Source = new FileCreateSource(outputPath, false),
            ColorType = Aspose.Imaging.FileFormats.Dicom.ColorType.Rgb24Bit
        };

        // Create DICOM image (first page will be the canvas)
        using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicom = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Create(dicomOptions, canvasWidth, canvasHeight))
        {
            bool firstPage = true;
            foreach (string imgPath in inputPaths)
            {
                using (RasterImage raster = (RasterImage)Image.Load(imgPath))
                {
                    // Ensure the image matches canvas size; if not, resize
                    if (raster.Width != canvasWidth || raster.Height != canvasHeight)
                    {
                        raster.Resize(canvasWidth, canvasHeight, ResizeType.NearestNeighbourResample);
                    }

                    int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);

                    if (firstPage)
                    {
                        // Write pixels to the initial DICOM page (the canvas)
                        dicom.SaveArgb32Pixels(dicom.Bounds, pixels);
                        firstPage = false;
                    }
                    else
                    {
                        // Add a new page and write pixels
                        Aspose.Imaging.FileFormats.Dicom.DicomPage page = dicom.AddPage();
                        page.SaveArgb32Pixels(page.Bounds, pixels);
                    }
                }
            }

            // Save the bound DICOM image
            dicom.Save();
        }
    }
}