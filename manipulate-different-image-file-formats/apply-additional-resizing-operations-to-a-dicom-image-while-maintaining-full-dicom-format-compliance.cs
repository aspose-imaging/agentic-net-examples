using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomResizeExample
{
    static void Main()
    {
        // Path to the folder containing the source DICOM file.
        string dir = @"c:\temp\";

        // Load the DICOM image.
        using (DicomImage dicom = (DicomImage)Image.Load(dir + "sample.dicom"))
        {
            // 1. Upscale the image by 150% using Bilinear resampling.
            int upWidth = (int)(dicom.Width * 1.5);
            int upHeight = (int)(dicom.Height * 1.5);
            dicom.Resize(upWidth, upHeight, ResizeType.BilinearResample);

            // 2. Downscale the image proportionally so that the width becomes 200 pixels,
            //    preserving the aspect ratio, using Nearest‑Neighbour resampling.
            dicom.ResizeWidthProportionally(200, ResizeType.NearestNeighbourResample);

            // 3. (Optional) Adjust the image resolution to 300 dpi for both axes.
            dicom.SetResolution(300.0, 300.0);

            // Save the processed image back to DICOM format.
            // The file extension determines the output format; using ".dcm" keeps it DICOM.
            dicom.Save(dir + "sample_resized.dcm");
        }
    }
}