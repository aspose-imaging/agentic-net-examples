using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output DICOM file paths
        string inputPath = args.Length > 0 ? args[0] : "input.dcm";
        string outputPath = args.Length > 1 ? args[1] : "output_resized.dcm";

        // Load the DICOM image
        using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
        {
            // Upscale by 2x using NearestNeighbour resampling
            dicomImage.Resize(dicomImage.Width * 2, dicomImage.Height * 2, ResizeType.NearestNeighbourResample);

            // Downscale by 2x using Bilinear resampling
            dicomImage.Resize(dicomImage.Width / 2, dicomImage.Height / 2, ResizeType.BilinearResample);

            // Increase width proportionally (height adjusted automatically) using HighQuality resampling
            dicomImage.ResizeWidthProportionally(dicomImage.Width * 3, ResizeType.HighQualityResample);

            // Decrease height proportionally (width adjusted automatically) using NearestNeighbour resampling
            dicomImage.ResizeHeightProportionally(dicomImage.Height / 2, ResizeType.NearestNeighbourResample);

            // Save the resized image back to DICOM format, preserving compliance
            var dicomOptions = new DicomOptions();
            dicomImage.Save(outputPath, dicomOptions);
        }
    }
}