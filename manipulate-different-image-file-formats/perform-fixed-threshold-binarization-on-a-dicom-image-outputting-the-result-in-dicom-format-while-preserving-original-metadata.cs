// Define the folder containing the DICOM files
string dir = @"c:\temp\";

// Load the original DICOM image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "sample.dicom"))
{
    // Cast the generic Image to DicomImage to access DICOM‑specific methods
    Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

    // Apply fixed‑threshold binarization (threshold value 127)
    dicomImage.BinarizeFixed(127);

    // Save the processed image back to DICOM format, preserving metadata
    dicomImage.Save(dir + "sample.BinarizeFixed.dcm", new Aspose.Imaging.ImageOptions.DicomOptions());
}