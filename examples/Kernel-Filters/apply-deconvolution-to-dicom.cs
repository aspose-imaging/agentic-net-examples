string dataDir = @"c:\temp\";

using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.dicom"))
{
    // Cast the generic Image to DicomImage to access DICOM‑specific functionality
    Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

    // Create deconvolution filter options (Gaussian‑Wiener) – radius 5, sigma 4.0
    var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0);

    // Apply the filter to the entire image area
    dicomImage.Filter(dicomImage.Bounds, deconvOptions);

    // Save the processed image as PNG
    dicomImage.Save(dataDir + "sample.GaussWienerDeconvolution.png", new Aspose.Imaging.ImageOptions.PngOptions());
}