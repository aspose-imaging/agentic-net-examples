using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;

class DicomGrayscaleConverter
{
    static void Main()
    {
        // Path to the folder containing the DICOM file
        string dir = @"c:\temp\";

        // Load the DICOM image from file
        using (Image image = Image.Load(dir + "sample.dicom"))
        {
            // Cast the generic Image to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Convert the image to grayscale while keeping all DICOM metadata intact
            dicomImage.Grayscale();

            // Save the result back to DICOM format (preserves original metadata)
            dicomImage.Save(dir + "sample_grayscale.dcm");
        }
    }
}