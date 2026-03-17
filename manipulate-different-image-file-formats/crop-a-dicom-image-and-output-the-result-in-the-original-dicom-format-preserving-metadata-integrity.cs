using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

// Load the DICOM image from file
string inputPath = @"c:\temp\sample.dcm";
using (Image image = Image.Load(inputPath))
{
    // Cast to DicomImage to access DICOM‑specific functionality
    DicomImage dicomImage = (DicomImage)image;

    // Define the cropping rectangle (central area of the image)
    Rectangle cropArea = new Rectangle(
        dicomImage.Width / 4,          // X coordinate
        dicomImage.Height / 4,         // Y coordinate
        dicomImage.Width / 2,          // Width
        dicomImage.Height / 2);        // Height

    // Perform the crop operation
    dicomImage.Crop(cropArea);

    // Prepare DICOM save options and preserve original metadata
    DicomOptions saveOptions = new DicomOptions
    {
        KeepMetadata = true
    };

    // Save the cropped image back to DICOM format
    string outputPath = @"c:\temp\sample_cropped.dcm";
    using (Stream outStream = File.Open(outputPath, FileMode.Create))
    {
        // Use the full bounds of the cropped image as the destination rectangle
        Rectangle bounds = new Rectangle(0, 0, dicomImage.Width, dicomImage.Height);
        dicomImage.Save(outStream, saveOptions, bounds);
    }
}