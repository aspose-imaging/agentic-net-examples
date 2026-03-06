string dir = @"c:\temp\";

// Load the DICOM image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "sample.dicom"))
{
    // Cast to DicomImage to access DICOM‑specific members
    Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

    // Apply Gaussian blur filter to the whole image (radius = 5, sigma = 4.0)
    dicomImage.Filter(dicomImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image (here as PNG for easy viewing)
    dicomImage.Save(dir + "sample.GaussianBlur.png",
        new Aspose.Imaging.ImageOptions.PngOptions());
}