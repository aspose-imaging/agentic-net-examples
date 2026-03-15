using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Expect at least two arguments: input JPG files followed by output DICOM file path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input1.jpg> <input2.jpg> ... <output.dcm>");
            return;
        }

        // Last argument is the output DICOM file
        string outputPath = args[args.Length - 1];

        // Collect input image paths (all arguments except the last one)
        List<string> inputPaths = new List<string>();
        for (int i = 0; i < args.Length - 1; i++)
        {
            inputPaths.Add(args[i]);
        }

        // Load the first image to obtain canvas dimensions
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            int canvasWidth = firstImage.Width;
            int canvasHeight = firstImage.Height;

            // Prepare DICOM options (use 24‑bit RGB to preserve fidelity)
            DicomOptions dicomOptions = new DicomOptions { ColorType = ColorType.Rgb24Bit };

            // Create a DICOM image canvas
            using (DicomImage dicom = (DicomImage)Image.Create(dicomOptions, canvasWidth, canvasHeight))
            {
                // Copy pixels of the first JPG into the first DICOM page
                int[] firstPixels = firstImage.LoadArgb32Pixels(firstImage.Bounds);
                dicom.SaveArgb32Pixels(dicom.Bounds, firstPixels);

                // Process remaining JPG images and add them as additional pages
                for (int i = 1; i < inputPaths.Count; i++)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                    {
                        // Ensure the image size matches the canvas; resize if necessary
                        if (img.Width != canvasWidth || img.Height != canvasHeight)
                        {
                            img.Resize(canvasWidth, canvasHeight, ResizeType.NearestNeighbourResample);
                        }

                        // Add a new page to the DICOM image and copy pixel data
                        DicomPage page = dicom.AddPage();
                        int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                        page.SaveArgb32Pixels(page.Bounds, pixels);
                    }
                }

                // Save the multi‑page DICOM file
                dicom.Save(outputPath, dicomOptions);
            }
        }
    }
}