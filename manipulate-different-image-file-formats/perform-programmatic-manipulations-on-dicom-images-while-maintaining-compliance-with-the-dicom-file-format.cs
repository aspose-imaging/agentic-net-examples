using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input DICOM file path
        string inputPath = "input.dcm";
        // Output DICOM file path
        string outputPath = "output_compressed.dcm";

        // Load the DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Cache image data for better performance
            if (!dicomImage.IsCached)
                dicomImage.CacheData();

            // Adjust brightness (+30)
            dicomImage.AdjustBrightness(30);

            // Resize to half of original size using nearest neighbour resampling
            int newWidth = dicomImage.Width / 2;
            int newHeight = dicomImage.Height / 2;
            dicomImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Configure DICOM save options with grayscale color type and JPEG compression
            var options = new DicomOptions
            {
                ColorType = ColorType.Grayscale8Bit,
                Compression = new Compression
                {
                    Type = CompressionType.Jpeg,
                    Jpeg = new JpegOptions
                    {
                        CompressionType = JpegCompressionMode.Baseline,
                        SampleRoundingMode = SampleRoundingMode.Truncate,
                        Quality = 70
                    }
                }
            };

            // Save the modified image as DICOM with the specified options
            dicomImage.Save(outputPath, options);
        }
    }
}