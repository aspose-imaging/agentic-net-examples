using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;

string inputPath = @"c:\temp\sample.dicom";
string outputPath = @"c:\temp\sample_gamma.dicom";

// Load the DICOM image
using (Image image = Image.Load(inputPath))
{
    // Cast to DicomImage to access DICOM‑specific methods
    DicomImage dicomImage = (DicomImage)image;

    // Apply gamma correction (same value for R, G, B channels)
    dicomImage.AdjustGamma(2.0f); // Adjust the gamma factor as needed

    // Save the image back in DICOM format to preserve file integrity
    dicomImage.Save(outputPath);
}