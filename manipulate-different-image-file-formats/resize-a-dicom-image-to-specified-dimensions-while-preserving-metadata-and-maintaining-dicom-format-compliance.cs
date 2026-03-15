// Specify the source DICOM file, target dimensions and output file
string sourcePath = @"C:\temp\sample.dicom";
string outputPath = @"C:\temp\sample_resized.dicom";
int targetWidth = 512;   // desired width
int targetHeight = 512;  // desired height

// Load the DICOM image using the generic Image.Load method
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(sourcePath))
{
    // Cast the loaded image to DicomImage to access DICOM‑specific operations
    Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage =
        (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

    // Resize the image. Choose a resampling algorithm (e.g., BilinearResample)
    dicomImage.Resize(targetWidth, targetHeight, Aspose.Imaging.ResizeType.BilinearResample);

    // Save the resized image back to DICOM format.
    // DicomOptions ensures that all original DICOM metadata is retained.
    var dicomSaveOptions = new Aspose.Imaging.ImageOptions.DicomOptions();
    dicomImage.Save(outputPath, dicomSaveOptions);
}