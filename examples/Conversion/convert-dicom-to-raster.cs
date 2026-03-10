using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

namespace DicomConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input DICOM file path
            string inputPath = @"C:\Images\sample.dcm";

            // Output raster image path (PNG format in this example)
            string outputPath = @"C:\Images\sample.png";

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific members if needed
                DicomImage dicomImage = (DicomImage)image;

                // Optional: perform any raster operations on the DICOM image here
                // e.g., dicomImage.Grayscale();

                // Save the DICOM image as a raster PNG file
                dicomImage.Save(outputPath, new PngOptions());
            }
        }
    }
}